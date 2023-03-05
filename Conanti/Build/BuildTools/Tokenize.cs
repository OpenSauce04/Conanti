using System;
using System.Collections.Generic;

namespace Conanti
{
	internal static partial class BuildTools
	{
		private static List<char> stringChars = new List<char> {'\'', '"'};
		internal static List<List<string>> Tokenize(string[] fileContents) // I think this is what the verb of using a Lexer is? https://www.wordsense.eu/lexer/
		{
			List<List<string>> tokenizedContent = new List<List<string>>();
			int index = 0;
			char? stringChar = null;
			foreach (string line in fileContents)
			{
				List<int> breakpoints = new List<int>{0};
				int charIndex = -1;

				for (charIndex = 0; charIndex < line.Length; charIndex++)
				{
					char character = line[charIndex];

					if (stringChars.Contains(character))
					{
						if (stringChar is null)
							stringChar = character;
						else if (stringChar == character)
							stringChar = null;
					}

					// Do not parse characters if currently within a string
					if (stringChar is not null)
						continue;

					switch (character) // Breakpoint characters
					{
						case '\t':
						case ' ':
						case '(':
						case ')':
						case ':':
						case '{':
						case '}':
						case '[':
						case ']':

						breakpoints.Add(charIndex); breakpoints.Add(charIndex+1); break;
					}
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
