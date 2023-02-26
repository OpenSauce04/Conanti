using System;
using System.Collections.Generic;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static List<List<string>> Lex(string[] fileContents) // I think this is what the verb of using a Lexer is? https://www.wordsense.eu/lexer/
		{
			List<List<string>> tokenizedContent = new List<List<string>>();
			int index = 0;
			foreach (string line in fileContents)
			{
				List<int> breakpoints = new List<int>{0};
				int charIndex = 0;

				foreach (char character in line)
				{
					switch (character) // Breakpoint characters
					{
						case '\t':
						case ' ': breakpoints.Add(charIndex); breakpoints.Add(charIndex+1); break; // Set two break points before and after the space so that the empty token is caught later on and removed
						case '(': breakpoints.Add(charIndex); break;
						case ')': breakpoints.Add(charIndex+1); break;
						case ':': breakpoints.Add(charIndex); breakpoints.Add(charIndex + 1); break;
					}
					charIndex++;
				}
				breakpoints.Add(charIndex);

				List<string> tokenizedLine = new List<string>();
				for (int i=1; i<breakpoints.Count; i++)
				{
					string token = line.Substring(breakpoints[i - 1], (breakpoints[i] - breakpoints[i - 1]));
					if (!string.IsNullOrWhiteSpace(token)) { tokenizedLine.Add(token); }
				}
				tokenizedContent.Add(tokenizedLine);
				index++;
			}

			return tokenizedContent;
		}


		internal static void TokenTest(List<List<string>> tokenizedContent)
		{
			foreach (List<string> line in tokenizedContent)
			{
				foreach (string token in line)
				{
					Console.WriteLine('|'+token+'|');
				}
				Console.WriteLine("==NEW LINE==");
			}
		}
	}
}
