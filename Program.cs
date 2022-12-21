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
					catch (System.IndexOutOfRangeException e)
					{
						srcDir = "";
					}

					BuildProgram(srcDir);
				}
			} catch (System.IndexOutOfRangeException e)
			{
				Console.WriteLine("No arguments specified.");
			}
		}
	}
}