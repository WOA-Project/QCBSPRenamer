using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace QCBSPRenamer
{
    internal class Program
    {
        private static string GetContentString(IArchive zipArchive, char archiveSep)
        {
            IArchiveEntry contentEntry = zipArchive.Entries.First(entry => !entry.IsDirectory && entry.Key.EndsWith("contents.xml") && entry.Key.Count(x => x == archiveSep) <= 1);

            using Stream contentsXmlFileStream = new MemoryStream();
            contentEntry.WriteTo(contentsXmlFileStream);
            contentsXmlFileStream.Seek(0, SeekOrigin.Begin);

            using BinaryReader br = new BinaryReader(contentsXmlFileStream);
            byte[] fileContent = br.ReadBytes((int)contentsXmlFileStream.Length);
            string strContent = Encoding.UTF8.GetString(fileContent);

            XmlSerializer ser = new(typeof(Contents));
            using XmlReader reader = XmlReader.Create(new StringReader(strContent));

            if (ser.Deserialize(reader) is Contents contents)
            {
                foreach (Build buildContent in contents.Builds_flat.Build)
                {
                    Console.WriteLine(buildContent.Name + "\t: " + buildContent.Build_id);
                }
                Console.WriteLine();

                Build commonBuild = contents.Builds_flat.Build.First(x => x.Name.Equals("common"));
                if (commonBuild.Build_id != ".")
                {
                    return commonBuild.Build_id;
                }
            }

            throw new Exception("Unexpected Contents.xml format!");
        }

        private static List<Dictionary<string, string>> GetContentsFromAbout(string[] lines)
        {
            bool IsCurrentlyInTrElement = false;
            int trStart = 0;

            List<string> currentHeaders = new();
            List<Dictionary<string, string>> elements = new();

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();

                if (!IsCurrentlyInTrElement)
                {
                    if (currentLine.Contains("<tr>"))
                    {
                        IsCurrentlyInTrElement = true;
                        trStart = i + 1;
                    }
                }
                else
                {
                    if (currentLine.Contains("</tr>"))
                    {
                        IsCurrentlyInTrElement = false;
                        List<string> elementsIntr = lines[trStart..(i - 1)].Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
                        trStart = 0; // Reset for good measure

                        // <th> -> header
                        // <td> -> element

                        bool header = elementsIntr.Any(x => x.Contains("<th"));
                        if (header)
                        {
                            currentHeaders.Clear();
                        }

                        Dictionary<string, string> contentElement = new Dictionary<string, string>();

                        for (int i1 = 0; i1 < elementsIntr.Count; i1++)
                        {
                            string element = elementsIntr[i1];
                            string normalizedElement = element.Split(">")[1].Split("<")[0].Trim();

                            if (header)
                            {
                                currentHeaders.Add(normalizedElement);
                            }
                            else
                            {
                                contentElement.Add(currentHeaders[i1], normalizedElement);
                            }
                        }

                        if (!header)
                        {
                            elements.Add(contentElement);
                        }
                    }
                }
            }

            return elements;
        }

        private static readonly string DistroPath = "Distro Path";
        private static readonly string BuildLabel = "Build/Label";

        private static string GetAboutString(IArchive zipArchive, char archiveSep)
        {
            IArchiveEntry contentEntry = zipArchive.Entries.First(entry => !entry.IsDirectory && entry.Key.EndsWith("about.html") && entry.Key.Count(x => x == archiveSep) <= 1);

            using Stream aboutHtmlFileStream = new MemoryStream();
            contentEntry.WriteTo(aboutHtmlFileStream);
            aboutHtmlFileStream.Seek(0, SeekOrigin.Begin);

            using BinaryReader reader = new BinaryReader(aboutHtmlFileStream);
            byte[] fileContent = reader.ReadBytes((int)aboutHtmlFileStream.Length);
            string strContent = Encoding.UTF8.GetString(fileContent);

            string[] lines = strContent.Replace("\r", "").Split("\n").ToArray();
            List<Dictionary<string, string>> content = GetContentsFromAbout(lines);

            foreach (Dictionary<string, string> buildContent in content)
            {
                if (buildContent.ContainsKey(DistroPath))
                {
                    Console.WriteLine(buildContent[DistroPath] + "\t: " + buildContent[BuildLabel]);
                }
            }
            Console.WriteLine();

            if (content.Any(x => x.ContainsKey(DistroPath) && x[DistroPath] == "common" && x[BuildLabel] != "."))
            {
                Dictionary<string, string> commonBuild = content.First(x => x.ContainsKey(DistroPath) && x[DistroPath] == "common");
                return commonBuild[BuildLabel];
            }

            if (content.Any(x => x.ContainsKey(BuildLabel) && x[BuildLabel].Contains("STD")))
            {
                Dictionary<string, string> commonBuild = content.First(x => x.ContainsKey(BuildLabel) && x[BuildLabel].Contains("STD"));
                return commonBuild[BuildLabel];
            }

            throw new Exception("Unexpected about.html format!");
        }

        private static string GetVersionString(IArchive zipArchive, char archiveSep)
        {
            IArchiveEntry[] files = zipArchive.Entries.Where(entry => !entry.IsDirectory &&
                entry.Key.Contains("WP" + archiveSep + "prebuilt" + archiveSep, StringComparison.InvariantCultureIgnoreCase) &&
                entry.Key.EndsWith(".inf", StringComparison.InvariantCultureIgnoreCase)).ToArray();

            HashSet<string> versionStrings = new();

            foreach (IArchiveEntry file in files)
            {
                using Stream infFileStream = new MemoryStream();
                file.WriteTo(infFileStream);
                infFileStream.Seek(0, SeekOrigin.Begin);

                using BinaryReader reader = new BinaryReader(infFileStream);
                byte[] fileContent = reader.ReadBytes((int)infFileStream.Length);
                string strContent = Encoding.UTF8.GetString(fileContent);

                string[] lines = strContent.Replace("\r", "").Split("\n").ToArray();

                string DriverVer = lines
                    .First(x => x
                    .Contains("DriverVer", StringComparison.InvariantCultureIgnoreCase))
                    .Split("=")[^1].Replace("\0", "")
                    .Trim();
                string buildNumber = DriverVer.Split(',')[1];

                string[] dateElements = DriverVer.Split(',')[0].Trim().Split('/');

                string date = $"{dateElements[2]}.{dateElements[0]}.{dateElements[1]}";
                string normalizedVersion = date + "-" + buildNumber;

                if (buildNumber.StartsWith("1.0."))
                {
                    versionStrings.Add(normalizedVersion);
                }
            }

            if (versionStrings.Count > 0)
            {
                string[] finalArrayOfVersions = versionStrings.Order().ToArray();
                return finalArrayOfVersions[^1];
            }

            throw new Exception("Unexpected INF format!");
        }

        private static string GetWPBSPVersionString(IArchive zipArchive, char archiveSep)
        {
            string buildId = "";
            string versionId = "";

            try
            {
                buildId = GetContentString(zipArchive, archiveSep);
            }
            catch
            {
            }

            if (string.IsNullOrEmpty(buildId))
            {
                try
                {
                    buildId = GetAboutString(zipArchive, archiveSep);
                }
                catch
                {
                }
            }

            if (string.IsNullOrEmpty(buildId))
            {
                throw new Exception("Unknown build id!");
            }

            try
            {
                versionId = GetVersionString(zipArchive, archiveSep);
            }
            catch
            {
            }

            if (string.IsNullOrEmpty(versionId))
            {
                return buildId;
            }

            return $"{versionId}.{buildId}";
        }

        private static string GetNewFileName(string archive)
        {
            using IArchive zipArchive = ZipArchive.Open(archive);

            string archiveName = Path.GetFileName(archive);
            string version = GetWPBSPVersionString(zipArchive, '/');

            string normalizedHashName = archiveName.Replace(version + "-", "");
            string newArchiveName = version + "-" + normalizedHashName;
            Console.WriteLine("Old: " + archiveName);
            Console.WriteLine("New: " + newArchiveName);

            return newArchiveName;
        }

        static void Main(string[] args)
        {
            string inputDirectory = args[0];
            string[] archives = Directory.EnumerateFiles(inputDirectory, "*.zip").ToArray();

            foreach (string archive in archives)
            {
                Console.WriteLine();
                Console.WriteLine("Processing: " + archive);
                Console.WriteLine();

                try
                {
                    string newArchiveName = GetNewFileName(archive);
                    File.Move(archive, Path.Combine(inputDirectory, newArchiveName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}