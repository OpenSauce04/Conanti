using System.IO;

namespace Conanti
{
	internal class Utils
	{
		// MODIFIED CODE FROM STACKOVERFLOW: https://stackoverflow.com/a/36484371 //
		public static void CloneDirectory(string root, string dest)
		{
			foreach (var directory in Directory.GetDirectories(root))
			{
				// Get the path of the new directory
				var newDirectory = Path.Combine(dest, Path.GetFileName(directory));
				// Create the directory if it doesn't already exist
				Directory.CreateDirectory(newDirectory);
				// Recursively clone the directory
				CloneDirectory(directory, newDirectory);
			}

			foreach (var file in Directory.GetFiles(root))
			{
				if (!file.EndsWith(".cnt"))
					File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
			}
		}
		// END //

		// CODE FROM STACKOVERFLOW: https://stackoverflow.com/a/22282428 //
		public static void RecursiveDelete(DirectoryInfo baseDir)
		{
			if (!baseDir.Exists)
				return;

			foreach (var dir in baseDir.EnumerateDirectories())
			{
				RecursiveDelete(dir);
			}
			baseDir.Delete(true);
		}
		// END //
	}
}
