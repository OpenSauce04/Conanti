using System;
using System.Collections.Generic;

namespace Conanti
{
	public static partial class BuildTools
	{
		public static List<string> StitchTokens(List<List<string>> tokenizedContent) {

			List<string> stitchedContent = new List<string>();
			foreach (List<string> line in tokenizedContent)
			{
				stitchedContent.Add(String.Join(' ', line));
			}

			return stitchedContent;

		}
	}
}
