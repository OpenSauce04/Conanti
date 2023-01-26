using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

# nullable disable

namespace Conanti
{
	public static class BuildInfo
	{
		public static String[] SourceFiles;
		public static String[] BuiltFiles;
		public static String SourcePath;
		public static String BuildPath;
		public static void Init(string srcDir)
		{
			SourcePath = srcDir;

			Directory.CreateDirectory(srcDir + "/../build");

			BuildPath = Path.GetFullPath(srcDir + "/../build");

			SourceFiles = getSourceFiles();

			BuiltFiles = getSourceFiles();
			for (int i = 0; i < BuiltFiles.Length; i ++) {
				if (BuiltFiles[i].ToLower().EndsWith(".cnt"))
					BuiltFiles[i] = Path.ChangeExtension(BuiltFiles[i], ".py");

				BuiltFiles[i] = BuiltFiles[i].Replace(SourcePath, BuildPath);
			}
		}
		private static String[] getSourceFiles()
		{
			return Directory.EnumerateFiles(SourcePath, "*.*", SearchOption.AllDirectories)
												.Where(fileName => Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant() == "cnt").ToArray<String>();
		}
	}
}
