using System;
using System.Collections.Generic;
using System.Linq;

namespace Conanti
{
	public static partial class Build
	{
		public static List<List<string>> Scope(List<List<string>> tokenizedContent)
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
						throw (new Exception("Error: '}' used without an accompanying '{'"));
					}
				}
				if (indent > 0)
				{
					tokenizedContent[lineIndex+1].Insert(0, String.Concat(Enumerable.Repeat(" ", indent-1))); // -1 because the existence of the token will create a space when stitched together
				}
				lineIndex++;
			}

			return tokenizedContent;
		}
	}
}
