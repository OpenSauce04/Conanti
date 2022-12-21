using System;
using System.IO;
using System.Collections.Generic;

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

			foreach (String filePath in BuildInfo.Files)
			{
				string[] fileContents = File.ReadAllLines(filePath);
				List<List<string>> tokenizedContent = Build.Lex(fileContents); // Tokenize file contents
				Build.LexerTest(tokenizedContent);
			}

		}
	}
}
