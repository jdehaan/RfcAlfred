using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Alfred
{
	static class Storage
	{
		/// <summary>
		/// Base directory for the storage of data
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

		public static FileInfo Index
		{
			get
			{
				String path = Path.Combine(BaseDirectory.FullName, "Index", "rfc-index.xml");
				return new FileInfo(path);
			}
		}

		private static void CreateSubDirectories()
		{
			String dir = _baseDirectory.FullName;
			Directory.CreateDirectory(Path.Combine(dir, "Index"));
			Directory.CreateDirectory(Path.Combine(dir, "Rfc"));
		}

		private static DirectoryInfo _baseDirectory;
	}
}
