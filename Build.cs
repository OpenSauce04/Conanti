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
			Build.Init();

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
	}
}
