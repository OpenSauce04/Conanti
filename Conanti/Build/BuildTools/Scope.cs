using System;
using System.Collections.Generic;
using System.Linq;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static object Scope(List<List<string>> tokenizedContent, string mode)
		{
			int lineIndex = 0;
			int scope = 0;
			List<int> scopeMap = new List<int>() {0}; // The scope of the first line is always 0

			foreach (List<string> line in tokenizedContent)
			{

				foreach (string token in line)
				{

					switch (token)
					{
						case ":":
						case "{": scope++; break;

						case "break":
						case "}": scope--; break;
					}

					if (scope < 0)
					{
						Console.WriteLine(ErrorMessages.GenerateError(ErrorMessages.NegativeScope(scope)));
						Environment.Exit(1);
					}
				}

				if (mode == "INDENT")
				{

					if (scope > 0)
					{
						try
						{
							tokenizedContent[lineIndex + 1].Insert(0, String.Concat(Enumerable.Repeat(" ", scope*4 - 1))); // -1 because the existence of the token will create a space when stitched together
						}
						catch (ArgumentOutOfRangeException)
						{
							Console.WriteLine(ErrorMessages.GenerateError(ErrorMessages.NegativeScope(scope)));
							Environment.Exit(1);
						}
					}

				} else if (mode == "MAP") {
					scopeMap.Add(scope);
				}

				lineIndex++;
			}

			if (mode == "INDENT")
			{
				return tokenizedContent;
			}
			else if (mode == "MAP")
			{
				return scopeMap;
			}
			return new Object();
		}

		internal static int GetScope(string indents)
		{
			return (indents.Count(x => x == ' ')+1) / 4;
		}
	}
}
