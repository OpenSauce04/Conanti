namespace Conanti
{
	internal static class ErrorMessages
	{
		// Generate Error Message
		internal static string GenericErrorHeader = "ERROR: ";
		internal static string GenericErrorTail = "\nStopping...";
		internal static string GenerateError(string message)
		{
			return GenericErrorHeader + message + GenericErrorTail;
		}

		// Messages
		internal static string NegativeScope(int indent) { return "Scope level hit negative number " + indent; }
		internal static string NonZeroScope(int indent) { return "File finished at scope level " + indent + "; Should be 0"; }

	}
}
