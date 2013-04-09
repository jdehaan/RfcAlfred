using System;
using System.IO;
using System.Reflection;

namespace Alfred.Storage
{
    internal static class Storage
    {
        private static DirectoryInfo _baseDirectory;

        /// <summary>
        ///     Base directory for the storage of data
        /// </summary>
        public static DirectoryInfo BaseDirectory
        {
            get
            {
                if (_baseDirectory == null)
                {
                    Assembly a = Assembly.GetEntryAssembly();
                    _baseDirectory = new DirectoryInfo(Path.GetDirectoryName(a.Location));
                    CreateSubDirectories();
                }
                return _baseDirectory;
            }
        }

        public static FileInfo IndexPath
        {
            get
            {
                String path = Path.Combine(BaseDirectory.FullName, "Index", "rfc-index.xml");
                return new FileInfo(path);
            }
        }

        public static FileInfo GetDocumentPath(String documentId)
        {
            String type = documentId.Substring(0, 3).ToLowerInvariant();
            int id = Convert.ToInt32(documentId.Substring(3));
            String filename = String.Format("{0}{1}.txt", type, id);
            String path = Path.Combine(BaseDirectory.FullName, "Documents", type, filename);
            return new FileInfo(path);
        }

        private static void CreateSubDirectories()
        {
            String dir = _baseDirectory.FullName;
            Directory.CreateDirectory(Path.Combine(dir, "Index"));
            Directory.CreateDirectory(Path.Combine(dir, "Documents", "bcp"));
            Directory.CreateDirectory(Path.Combine(dir, "Documents", "std"));
            Directory.CreateDirectory(Path.Combine(dir, "Documents", "rfc"));
            Directory.CreateDirectory(Path.Combine(dir, "Documents", "fyi"));
        }
    }
}