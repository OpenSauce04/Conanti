using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Conanti
{
	internal static partial class BuildTools
	{
		internal static void EnforceConstants(List<List<string>> content, List<int> scopeMap)
		{
			List<object[]> constList = new List<object[]>();
			// 0: The token of the constant
			// 1: The scope of the constant


			for (int lineIndex = 0; lineIndex < content.Count; lineIndex++)
			{
				int currentScope = 0; // temporary

				// Scan for const definitions
				for (int tokenIndex = 0; tokenIndex < content[lineIndex].Count(); tokenIndex++)
				{
					if (tokenIndex != 0) {

						if (content[lineIndex][tokenIndex - 1] == "const")
						{
							constList.Add(new object[2]
							{
								content[lineIndex][tokenIndex],
								scopeMap[lineIndex]
							});

							continue; // Skip subsequent checks, as this is the token where the constant is initialized
						}

					}

					if (tokenIndex + 1 != content[lineIndex].Count)
					{

						for (int i = 0; i < constList.Count(); i++)
						{
							if (currentScope < (int) constList[i][1])
							{ // Constant is out of scope, stop tracking it
								constList.RemoveAt(i);
								i--;
								continue;
							}

							foreach (Regex mutator in Tables.Mutators)
							{
								if (
									tokenIndex+1 != content[lineIndex].Count &&
									content[lineIndex][tokenIndex] == (string) constList[i][0] &&
							  	mutator.Match(content[lineIndex][tokenIndex+1]).Success // If constant is being mutated
								)
								{
									Console.WriteLine(ErrorMessages.GenerateError(ErrorMessages.MutatedConstant));
									Environment.Exit(1);
								}

							}
						}
					}
				}
			}
		}
	}
}
