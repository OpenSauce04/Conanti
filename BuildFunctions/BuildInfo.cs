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
		public static void Init()
		{
			SourcePath = Environment.CurrentDirectory;
			BuildPath = Path.GetFullPath(Environment.CurrentDirectory + "../build");
			var pythonExtensions = new List<string> { "py", "pyw", "py3" };
			Files = Directory.EnumerateFiles(SourcePath, "*.*", SearchOption.AllDirectories)
				             .Where(fileName => pythonExtensions.Contains(Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant()));
		}
	}
}
