using System;
using System.Collections.Generic;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static List<List<string>> ReplaceTokens(List<List<string>> tokenizedContent)
		{

			for (int lineIndex = 0; lineIndex < tokenizedContent.Count; lineIndex++)
			{
				for (int tokenIndex = 0; tokenIndex < tokenizedContent[lineIndex].Count; tokenIndex++)
				{

					switch(tokenizedContent[lineIndex][tokenIndex])
					{
						case "{": tokenizedContent[lineIndex][tokenIndex] = ":"; break;
						case "}": tokenizedContent[lineIndex].RemoveAt(tokenIndex); break;
						case "function": tokenizedContent[lineIndex][tokenIndex] = "def"; break;
						case "switch": tokenizedContent[lineIndex][tokenIndex] = "match"; break;
					}

					if (
						tokenIndex != 0 &&
						tokenizedContent[lineIndex][tokenIndex-1] == "case" &&
						tokenizedContent[lineIndex][tokenIndex] == "default"
					)
					{
						tokenizedContent[lineIndex][tokenIndex] = "_";
					}

				}
			}

			return tokenizedContent;
		}

	}
}
