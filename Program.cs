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
					Build();
				}
			} catch (System.IndexOutOfRangeException e)
			{
				Console.WriteLine("No arguments specified.");
			}
		}
	}
}