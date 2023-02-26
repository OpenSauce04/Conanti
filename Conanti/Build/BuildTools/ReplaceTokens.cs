using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static List<List<string>> ReplaceTokens(List<List<string>> content)
		{
			string? currentClassName = null;
			int? classDefLine = null;
			for (int lineIndex = 0; lineIndex < content.Count; lineIndex++)
			{
				for (int tokenIndex = 0; tokenIndex < content[lineIndex].Count; tokenIndex++)
				{

					// Basic replacements
					switch (content[lineIndex][tokenIndex])
					{
						case "{": content[lineIndex][tokenIndex] = ":"; break;

						case "break":
						case "}":
						case "const": content[lineIndex][tokenIndex] = ""; break;

						case "function": content[lineIndex][tokenIndex] = "def"; break;
						case "switch": content[lineIndex][tokenIndex] = "match"; break;
					}

					// default case
					if (
						tokenIndex != 0 &&
						content[lineIndex][tokenIndex - 1] == "case" &&
						content[lineIndex][tokenIndex] == "default"
						)
					{
						content[lineIndex][tokenIndex] = "_";
					}

					// Class name constructor

					if (
						tokenIndex != 0 &&
						GetScope(content[lineIndex][0]) == 0
						)
					{

						if (content[lineIndex][tokenIndex - 1] == "class")
						{
							currentClassName = content[lineIndex][tokenIndex];
							classDefLine = lineIndex;
						}

						else if (classDefLine != lineIndex)
						{
							currentClassName = null;
						}

					}
					if (
						currentClassName != null &&
						GetScope(content[lineIndex][0]) != 0 &&
						content[lineIndex][tokenIndex] == currentClassName
						)
					{
						content[lineIndex][tokenIndex] = "def __init__";
					}
				}
			}

			return content;
		}

	}
}
