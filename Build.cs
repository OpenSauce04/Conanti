using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Conanti
{
	internal partial class Program
	{
		static void BuildProgram(String buildDir)
		{

			// Initialize build info
			BuildInfo.Init(buildDir);

			// Initialize build environment
			Init();

			for (int fileIndex = 0; fileIndex < BuildInfo.SourceFiles.Count(); fileIndex++)
			{
				string[] fileContents = File.ReadAllLines(BuildInfo.SourceFiles[fileIndex]);

				List<List<string>> tokenizedContent;
				tokenizedContent = Build.Lex(fileContents); // Tokenize file contents;
				tokenizedContent = Build.Scope(tokenizedContent); // Indent code to conform with Python's whitespace-centric syntax
				tokenizedContent = Build.ReplaceTokens(tokenizedContent); // Replace Conanti tokens with Python tokens

				List<string> newContent;
				newContent = Build.StitchTokens(tokenizedContent); // Put tokens back together into a String array that can be written to a file
				newContent = Build.CleanBlanks(newContent); // Remove blank lines from produced Python file

				File.WriteAllLines(BuildInfo.BuiltFiles[fileIndex], newContent);
			}

		}

		public static void Init()
		{
			RecursiveDelete(new DirectoryInfo(BuildInfo.BuildPath));
			Directory.CreateDirectory(BuildInfo.BuildPath);
			CloneDirectory(BuildInfo.SourcePath, BuildInfo.BuildPath);
		}


		// MODIFIED CODE FROM STACKOVERFLOW: https://stackoverflow.com/a/36484371 //
		private static void CloneDirectory(string root, string dest)
		{
			foreach (var directory in Directory.GetDirectories(root))
			{
				//Get the path of the new directory
				var newDirectory = Path.Combine(dest, Path.GetFileName(directory));
				//Create the directory if it doesn't already exist
				Directory.CreateDirectory(newDirectory);
				//Recursively clone the directory
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
