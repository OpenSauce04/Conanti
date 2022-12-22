using System;
using System.Collections.Generic;

namespace Conanti
{
	public static partial class Build
	{
		public static string[] StitchTokens(List<List<string>> tokenizedContent) {
			String[] stitchedContent = new String[tokenizedContent.Count];
			int lineIndex = 0;
			foreach (List<string> line in tokenizedContent)
			{
				stitchedContent[lineIndex] = String.Join(' ', line);
				lineIndex++;
			}

			return stitchedContent;
		}
	}
}
