using System;

namespace Conanti
{
	internal class Conanti
	{
		public static void Main(string[] args)
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

					Build.Run(srcDir);
				}
			} catch (IndexOutOfRangeException)
			{
				Console.WriteLine("No arguments specified.");
			}
		}
	}
}