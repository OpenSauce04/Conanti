using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
			BuildPath = Path.GetFullPath(srcDir+ "/../build");
			BuiltFiles = SourceFiles = Directory.EnumerateFiles(BuildPath, "*.*", SearchOption.AllDirectories)
												.Where(fileName => Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant() == "cnt").ToArray<String>();

		}
	}
}
