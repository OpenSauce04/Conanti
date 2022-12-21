using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Conanti
{
	public static class BuildInfo
	{
		public static IEnumerable<String> Files;
		public static String SourcePath;
		public static String BuildPath;
		public static void Init(string srcDir)
		{
			SourcePath = srcDir;
			BuildPath = Path.GetFullPath(srcDir+ "/../build");
			Files = Directory.EnumerateFiles(SourcePath, "*.*", SearchOption.AllDirectories)
				             .Where(fileName => Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant() == "cnt");
		}
	}
}
