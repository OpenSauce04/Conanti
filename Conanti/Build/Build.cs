using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Conanti.Build;

namespace Conanti
{
    public static partial class Conanti
	{
		public static void RunBuild(String buildDir)
		{

			// Initialize build info
			BuildInfo.Generate(buildDir);

			// Initialize build environment
			Init();

			for (int fileIndex = 0; fileIndex < BuildInfo.SourceFiles.Count(); fileIndex++)
			{
				string[] fileContents = File.ReadAllLines(BuildInfo.SourceFiles[fileIndex]);

				List<List<string>> tokenizedContent;

				tokenizedContent = BuildTools.Lex(fileContents); // Tokenize file contents;

				List<int> scopeMap;
				scopeMap = (List<int>) BuildTools.Scope(tokenizedContent, "MAP"); // Create a map of the indentation of the file

				BuildTools.EnforceConstants(tokenizedContent, scopeMap); // Checks all constant values to see if they are mutated

				tokenizedContent = (List<List<string>>) BuildTools.Scope(tokenizedContent, "INDENT"); // Indent code to conform with Python's whitespace-centric syntax

				tokenizedContent = BuildTools.ReplaceTokens(tokenizedContent); // Replace Conanti tokens with Python tokens
				tokenizedContent = BuildTools.RemoveEmptyTokens(tokenizedContent);

				List<string> newContent;
				newContent = BuildTools.StitchTokens(tokenizedContent); // Put tokens back together into a String array that can be written to a file

				newContent = BuildTools.Clean(newContent); // Remove blank lines from produced Python file

				File.WriteAllLines(BuildInfo.BuiltFiles[fileIndex], newContent);
			}

		}

		internal static void Init()
		{
			Utils.RecursiveDelete(new DirectoryInfo(BuildInfo.BuildPath));
			Directory.CreateDirectory(BuildInfo.BuildPath);
			Utils.CloneDirectory(BuildInfo.SourcePath, BuildInfo.BuildPath);
		}
	}
}
