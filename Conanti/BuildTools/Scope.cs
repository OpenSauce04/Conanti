using System;
using System.Collections.Generic;
using System.Linq;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static List<List<string>> Scope(List<List<string>> tokenizedContent)
		{
			int lineIndex = 0;
			int indent = 0;

			foreach (List<string> line in tokenizedContent)
			{

				foreach (string token in line)
				{
					switch (token)
					{
						case "{": indent++; break;
						case "}": indent--; break;
					}

					if (indent < 0)
					{
						Console.WriteLine("ERROR: '}' used without an accompanying '{'\nStopping...");
						Environment.Exit(1);
					}
				}

				if (indent > 0)
				{
					try
					{
						tokenizedContent[lineIndex + 1].Insert(0, String.Concat(Enumerable.Repeat(" ", indent*4 - 1))); // -1 because the existence of the token will create a space when stitched together
					}
					catch (ArgumentOutOfRangeException)
					{
						Console.WriteLine("ERROR: '{' used without an accompanying '}'\nStopping...");
						Environment.Exit(1);
					}
				}
				lineIndex++;

			}

			return tokenizedContent;
		}

		internal static int GetScope(string indents)
		{
			return (indents.Count(x => x == ' ')+1) / 4;
		}
	}
}
