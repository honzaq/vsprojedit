using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace VsProjEdit.Models
{
    class NewProjectModel
    {
        public enum EPropsType
        {
            lib,
            dll,
            headers_only,
            dll_dependent,
            test
        }

        [Flags]
        public enum EConfigType
        {
            None = 0,
            Debug_lib_x86 = 1 << 0,
            Release_lib_x86 = 1 << 1,
            Debug_lib_x64 = 1 << 2,
            Release_lib_x64 = 1 << 3,
            Debug_x86 = 1 << 4,
            Release_x86 = 1 << 5,
            Debug_x64 = 1 << 6,
            Release_x64 = 1 << 7
        }

        public string Name { get; set; }
        public EPropsType PropsType { get; set; }
        public EConfigType ConfigType { get; set; }

        public void WriteResourceToFile(string resourceName, string fileName)
        {
            // If you want see your resources uncomment this 
            //   string[] array = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("VsProjEdit.Resources." + resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }

        public void Create(object parameter)
        {
            string ProjCreateDir = @"c:\Download\_todelete";
            string ModulDir = new DirectoryInfo(ProjCreateDir).Name;

            string ProjPath = Path.Combine(ProjCreateDir, Name);
            // Create new directory
            Directory.CreateDirectory(ProjPath);

            //////////////////////////////////////////////////////////////////////////
            // includes
            string ProjIncPath = Path.Combine(ProjPath, "include");
            
            Directory.CreateDirectory(ProjIncPath);
            Directory.CreateDirectory(Path.Combine(ProjIncPath, "asw"));
            Directory.CreateDirectory(Path.Combine(ProjIncPath, "asw", ModulDir));
            Directory.CreateDirectory(Path.Combine(ProjIncPath, "asw", ModulDir, Name));

            // Unpack default include header
            string HeaderPath = Path.Combine(ProjIncPath, "asw", ModulDir, Name + ".h");
            WriteResourceToFile("proj_inc.h.tmpl", HeaderPath);

            //////////////////////////////////////////////////////////////////////////
            // src
            Directory.CreateDirectory(Path.Combine(ProjPath, "src"));

            MessageBox.Show("Done");
        }
    }
}
