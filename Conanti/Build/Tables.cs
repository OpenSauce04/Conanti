using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Conanti
{
    static internal class Tables
    {
        internal static List<Regex> Mutators = new List<Regex>()
        {
			new Regex("^=$"), // =
			new Regex("^[\\+\\-\\*\\/]?=$") // +=, -=, *=, /=
		};
    }
}
