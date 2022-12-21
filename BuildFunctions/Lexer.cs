using System;
using System.Collections.Generic;
using System.Linq;

namespace Conanti
{
	public static partial class Build
	{
		public static List<List<string>> Lex(string[] fileContents) // I think this is what the verb of using a Lexer is? https://www.wordsense.eu/lexer/
		{
			List<List<string>> tokenizedContent = new List<List<string>>();
			int index = 0;
			foreach (string line in fileContents)
			{
				List<int> breakpoints = new List<int>();
				breakpoints.Add(0);
				int charIndex = 0;

				foreach (char character in line)
				{
					if (character == ' ')
					{
						breakpoints.Add(charIndex+1);
					}
					charIndex++;
				}
				breakpoints.Add(charIndex+1);

				List<string> tokenizedLine = new List<string>();
				for (int i=1; i<breakpoints.Count; i++)
				{
					if (((breakpoints[i] - breakpoints[i-1])-1) != 0) {
						tokenizedLine.Add(line.Substring(breakpoints[i - 1], (breakpoints[i] - breakpoints[i - 1]) - 1));
					}
				}
				tokenizedContent.Add(tokenizedLine);
				index++;
			}

			return tokenizedContent;
		}


		public static void LexerTest(List<List<string>> tokenizedContent)
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
