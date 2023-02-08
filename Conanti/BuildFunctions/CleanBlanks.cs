using System;
using System.Collections.Generic;

namespace Conanti
{
	public static partial class Build
	{
		public static List<string> CleanBlanks(List<string> newContent)
		{
			for (int lineIndex = 0; lineIndex < newContent.Count; lineIndex++)
			{
				if (String.IsNullOrWhiteSpace(newContent[lineIndex])) {
					newContent.RemoveAt(lineIndex);
				}
			}

			return newContent;
		} 
	}
}
