using System;

namespace Conanti
{
	internal partial class Program
	{
		static void Main(string[] args)
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

					BuildProgram(srcDir);
				}
			} catch (IndexOutOfRangeException)
			{
				Console.WriteLine("No arguments specified.");
			}
		}
	}
}