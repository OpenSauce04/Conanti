using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static List<List<string>> ReplaceTokens(List<List<string>> tokenizedContent)
		{
			string? currentClassName = null;
			int? classDefLine = null;
			for (int lineIndex = 0; lineIndex < tokenizedContent.Count; lineIndex++)
			{
				for (int tokenIndex = 0; tokenIndex < tokenizedContent[lineIndex].Count; tokenIndex++)
				{

					// Basic replacements
					switch (tokenizedContent[lineIndex][tokenIndex])
					{
						case "{": tokenizedContent[lineIndex][tokenIndex] = ":"; break;
						case "}": tokenizedContent[lineIndex][tokenIndex] = ""; break;
						case "function": tokenizedContent[lineIndex][tokenIndex] = "def"; break;
						case "switch": tokenizedContent[lineIndex][tokenIndex] = "match"; break;
					}

					// default case
					if (
						tokenIndex != 0 &&
						tokenizedContent[lineIndex][tokenIndex - 1] == "case" &&
						tokenizedContent[lineIndex][tokenIndex] == "default"
						)
					{
						tokenizedContent[lineIndex][tokenIndex] = "_";
					}

					// Class name constructor

					if (
						tokenIndex != 0 &&
						GetScope(tokenizedContent[lineIndex][0]) == 0
						)
					{

						if (tokenizedContent[lineIndex][tokenIndex - 1] == "class")
						{
							currentClassName = tokenizedContent[lineIndex][tokenIndex];
							classDefLine = lineIndex;
						}

						else if (classDefLine != lineIndex)
						{
							currentClassName = null;
						}

					}
					if (
						currentClassName != null &&
						GetScope(tokenizedContent[lineIndex][0]) != 0 &&
						tokenizedContent[lineIndex][tokenIndex] == currentClassName
						)
					{
						tokenizedContent[lineIndex][tokenIndex] = "def __init__";
					}
				}
			}

			return tokenizedContent;
		}

	}
}
