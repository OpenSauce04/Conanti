﻿namespace Conanti
{
	internal static class ErrorMessages
	{
		// Generate Error Message
		internal static string GenericErrorHeader = "ERROR: ";
		internal static string GenericErrorTail = "\nStopping...";
		internal static string GenerateError(string message) => GenericErrorHeader + message + GenericErrorTail;

		// Messages
		internal static string NegativeScope(int indent) => "Scope level hit negative number " + indent;
		internal static string NonZeroScope(int indent) => "File finished at scope level " + indent + "; Should be 0";
		internal static string MutatedConstant = "Variable defined as a constant was mutated";

	}
}
