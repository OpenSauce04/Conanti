using System;
using System.Collections.Generic;

namespace Conanti
{
	public static partial class Build
	{
		public static List<List<string>> ReplaceTokens(List<List<string>> tokenizedContent)
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
					}
				}
			}

			return tokenizedContent;
		}

	}
}
