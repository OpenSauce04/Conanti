using System;
using System.Collections.Generic;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static List<List<string>> RemoveEmptyTokens(List<List<string>> content)
		{

			for (int lineIndex = 0; lineIndex < content.Count; lineIndex++)
			{
				for (int tokenIndex = 0; tokenIndex < content[lineIndex].Count; tokenIndex++)
				{
					if (content[lineIndex][tokenIndex] == "")
					{
						content[lineIndex].RemoveAt(tokenIndex);
						tokenIndex--;
					}
				}
			}
			return content;
		}
	}
}
