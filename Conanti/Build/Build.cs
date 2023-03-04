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
				List<int> scopeMap;
				List<string> untokenizedContent;

				// Tokenize file contents
				tokenizedContent = BuildTools.Lex(fileContents);

				// Create a map of the indentation of the file
				scopeMap = (List<int>) BuildTools.Scope(tokenizedContent, "MAP");

				// Checks all constant values to see if they are mutated
				BuildTools.EnforceConstants(tokenizedContent, scopeMap);

				// Indent code to conform with Python's whitespace-centric syntax
				tokenizedContent = (List<List<string>>) BuildTools.Scope(tokenizedContent, "INDENT");

				// Replace Conanti tokens with Python tokens
				tokenizedContent = BuildTools.ReplaceTokens(tokenizedContent);

				// Clean up empty tokens
				tokenizedContent = BuildTools.CleanEmptyTokens(tokenizedContent);

				// Put tokens back together into a String array that can be written to a file
				untokenizedContent = BuildTools.StitchTokens(tokenizedContent);

				// Remove blank lines from produced Python file
				untokenizedContent = BuildTools.CleanEmptyLines(untokenizedContent);

				File.WriteAllLines(BuildInfo.BuiltFiles[fileIndex], untokenizedContent);
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
