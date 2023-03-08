using System.IO;
using System.Reflection;

namespace Conanti.Tests
{
	internal class ConantiTests
	{
		internal static void Main()
		{
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
			Conanti.RunBuild(dir + "/Tests");
		}
	}
}
