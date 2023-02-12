using System;

namespace Conanti
{
	public static partial class Conanti
	{
		internal static void Main(string[] args)
		{
			try
			{
				if (args[0].ToLower() == "build")
				{
					string srcDir;
					try
					{
						srcDir = args[1];
					}
					catch (IndexOutOfRangeException)
					{
						srcDir = "";
					}

					RunBuild(srcDir);
				}
			} catch (IndexOutOfRangeException)
			{
				Console.WriteLine("No arguments specified.");
			}
		}
	}
}