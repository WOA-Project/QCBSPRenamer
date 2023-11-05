using System.Xml.Serialization;

namespace QCBSPRenamer
{

    [XmlRoot(ElementName = "component")]
    public class Component
    {
        [XmlElement(ElementName = "name")]
        public string Name
        {
            get; set;
        }
        [XmlElement(ElementName = "flavor")]
        public string Flavor
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "pf")]
    public class Pf
    {
        [XmlElement(ElementName = "name")]
        public string Name
        {
            get; set;
        }
        [XmlElement(ElementName = "component")]
        public List<Component> Component
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "product_flavors")]
    public class Product_flavors
    {
        [XmlElement(ElementName = "pf")]
        public List<Pf> Pf
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "cmm_pf_var")]
        public string Cmm_pf_var
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "hlos_type")]
    public class Hlos_type
    {
        [XmlAttribute(AttributeName = "cmm_var")]
        public string Cmm_var
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "chipid")]
    public class Chipid
    {
        [XmlAttribute(AttributeName = "cmm_var")]
        public string Cmm_var
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "product_info")]
    public class Product_info
    {
        [XmlElement(ElementName = "product_name")]
        public string Product_name
        {
            get; set;
        }
        [XmlElement(ElementName = "hlos_type")]
        public Hlos_type Hlos_type
        {
            get; set;
        }
        [XmlElement(ElementName = "chipid")]
        public Chipid Chipid
        {
            get; set;
        }
        [XmlElement(ElementName = "additional_chipid")]
        public string Additional_chipid
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "partition")]
    public class Partition
    {
        [XmlAttribute(AttributeName = "fastboot_erase")]
        public string Fastboot_erase
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "partition_info")]
    public class Partition_info
    {
        [XmlElement(ElementName = "partition")]
        public List<Partition> Partition
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "download_file")]
    public class Download_file
    {
        [XmlElement(ElementName = "file_name")]
        public string File_name
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "ignore")]
        public string Ignore
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "storage_type")]
        public string Storage_type
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "minimized")]
        public string Minimized
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "fastboot")]
        public string Fastboot
        {
            get; set;
        }
        [XmlElement(ElementName = "file_path")]
        public File_path File_path
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "cmm_file_var")]
        public string Cmm_file_var
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "fastboot_complete")]
        public string Fastboot_complete
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "gpt_file")]
        public string Gpt_file
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "form_factor")]
        public string Form_factor
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "fat_file")]
        public string Fat_file
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "pil_split")]
        public string Pil_split
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "clean_for_release")]
        public string Clean_for_release
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "symbol")]
        public string Symbol
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "fastboot_rumi")]
        public string Fastboot_rumi
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "file_path")]
    public class File_path
    {
        [XmlAttribute(AttributeName = "flavor")]
        public string Flavor
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "partition_file")]
    public class Partition_file
    {
        [XmlElement(ElementName = "file_name")]
        public string File_name
        {
            get; set;
        }
        [XmlElement(ElementName = "file_path")]
        public string File_path
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "storage_type")]
        public string Storage_type
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "partition_patch_file")]
    public class Partition_patch_file
    {
        [XmlElement(ElementName = "file_name")]
        public string File_name
        {
            get; set;
        }
        [XmlElement(ElementName = "file_path")]
        public string File_path
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "storage_type")]
        public string Storage_type
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "build")]
    public class Build
    {
        [XmlElement(ElementName = "name")]
        public string Name
        {
            get; set;
        }
        [XmlElement(ElementName = "role")]
        public string Role
        {
            get; set;
        }
        [XmlElement(ElementName = "chipset")]
        public string Chipset
        {
            get; set;
        }
        [XmlElement(ElementName = "build_id")]
        public string Build_id
        {
            get; set;
        }
        [XmlElement(ElementName = "image_dir")]
        public string Image_dir
        {
            get; set;
        }
        [XmlElement(ElementName = "release_path")]
        public string Release_path
        {
            get; set;
        }
        [XmlElement(ElementName = "download_file")]
        public List<Download_file> Download_file
        {
            get; set;
        }
        [XmlElement(ElementName = "partition_file")]
        public List<Partition_file> Partition_file
        {
            get; set;
        }
        [XmlElement(ElementName = "partition_patch_file")]
        public List<Partition_patch_file> Partition_patch_file
        {
            get; set;
        }
        [XmlElement(ElementName = "buildfile_path")]
        public string Buildfile_path
        {
            get; set;
        }
        [XmlElement(ElementName = "build_command")]
        public string Build_command
        {
            get; set;
        }
        [XmlElement(ElementName = "windows_root_path")]
        public Windows_root_path Windows_root_path
        {
            get; set;
        }
        [XmlElement(ElementName = "linux_root_path")]
        public Linux_root_path Linux_root_path
        {
            get; set;
        }
        [XmlElement(ElementName = "file_ref")]
        public List<File_ref> File_ref
        {
            get; set;
        }
        [XmlElement(ElementName = "short_build_path")]
        public Short_build_path Short_build_path
        {
            get; set;
        }
        [XmlElement(ElementName = "device_programmer")]
        public Device_programmer Device_programmer
        {
            get; set;
        }
        [XmlElement(ElementName = "flash_programmer")]
        public Flash_programmer Flash_programmer
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "windows_root_path")]
    public class Windows_root_path
    {
        [XmlAttribute(AttributeName = "cmm_root_path_var")]
        public string Cmm_root_path_var
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "linux_root_path")]
    public class Linux_root_path
    {
        [XmlAttribute(AttributeName = "cmm_root_path_var")]
        public string Cmm_root_path_var
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "file_ref")]
    public class File_ref
    {
        [XmlElement(ElementName = "file_name")]
        public string File_name
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "ignore")]
        public string Ignore
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "minimized")]
        public string Minimized
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "fat_file")]
        public string Fat_file
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "sub_dir")]
        public string Sub_dir
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "debug_script")]
        public string Debug_script
        {
            get; set;
        }
        [XmlElement(ElementName = "file_path")]
        public File_path File_path
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "clean_for_release")]
        public string Clean_for_release
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "cmm_file_var")]
        public string Cmm_file_var
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "storage_type")]
        public string Storage_type
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "pil_split")]
        public string Pil_split
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "adspso_signed")]
        public string Adspso_signed
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "fat_file_btfm")]
        public string Fat_file_btfm
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "cdspso_signed")]
        public string Cdspso_signed
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "short_build_path")]
    public class Short_build_path
    {
        [XmlAttribute(AttributeName = "cmm_var")]
        public string Cmm_var
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "device_programmer")]
    public class Device_programmer
    {
        [XmlElement(ElementName = "file_name")]
        public string File_name
        {
            get; set;
        }
        [XmlElement(ElementName = "file_path")]
        public string File_path
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "minimized")]
        public string Minimized
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "flash_programmer")]
    public class Flash_programmer
    {
        [XmlElement(ElementName = "file_name")]
        public string File_name
        {
            get; set;
        }
        [XmlElement(ElementName = "file_path")]
        public string File_path
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "minimized")]
        public string Minimized
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "builds_flat")]
    public class Builds_flat
    {
        [XmlElement(ElementName = "build")]
        public List<Build> Build
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "version")]
    public class Version
    {
        [XmlAttribute(AttributeName = "cmm_var")]
        public string Cmm_var
        {
            get; set;
        }
        [XmlText]
        public string Text
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "tool")]
    public class Tool
    {
        [XmlElement(ElementName = "name")]
        public string Name
        {
            get; set;
        }
        [XmlElement(ElementName = "version")]
        public Version Version
        {
            get; set;
        }
        [XmlElement(ElementName = "path")]
        public string Path
        {
            get; set;
        }
        [XmlElement(ElementName = "build")]
        public string Build
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "external_tools")]
    public class External_tools
    {
        [XmlElement(ElementName = "tool")]
        public List<Tool> Tool
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "step")]
    public class Step
    {
        [XmlElement(ElementName = "params")]
        public string Params
        {
            get; set;
        }
        [XmlElement(ElementName = "exec_dir")]
        public string Exec_dir
        {
            get; set;
        }
        [XmlElement(ElementName = "tool_name")]
        public string Tool_name
        {
            get; set;
        }
        [XmlAttribute(AttributeName = "type")]
        public string Type
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "workflow")]
    public class Workflow
    {
        [XmlElement(ElementName = "tool")]
        public List<Tool> Tool
        {
            get; set;
        }
        [XmlElement(ElementName = "step")]
        public List<Step> Step
        {
            get; set;
        }
    }

    [XmlRoot(ElementName = "contents")]
    public class Contents
    {
        [XmlElement(ElementName = "product_flavors")]
        public Product_flavors Product_flavors
        {
            get; set;
        }
        [XmlElement(ElementName = "product_info")]
        public Product_info Product_info
        {
            get; set;
        }
        [XmlElement(ElementName = "partition_info")]
        public Partition_info Partition_info
        {
            get; set;
        }
        [XmlElement(ElementName = "builds_flat")]
        public Builds_flat Builds_flat
        {
            get; set;
        }
        [XmlElement(ElementName = "build_tools")]
        public string Build_tools
        {
            get; set;
        }
        [XmlElement(ElementName = "external_tools")]
        public External_tools External_tools
        {
            get; set;
        }
        [XmlElement(ElementName = "workflow")]
        public Workflow Workflow
        {
            get; set;
        }
    }
}
