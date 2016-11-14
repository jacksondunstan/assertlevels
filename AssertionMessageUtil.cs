using System;

public class AssertionMessageUtil
{
	public static string GetMessage(string failureMessage)
	{
		return string.Format("{0} {1}", "Assertion failed.", failureMessage);
	}

	public static string GetMessage(string failureMessage, string expected)
	{
		return AssertionMessageUtil.GetMessage(
			string.Format(
				"{0}{1}{2} {3}",
				failureMessage,
				Environment.NewLine,
				"Expected:",
				expected
			)
		);
	}

	public static string GetEqualityMessage(object actual, object expected, bool expectEqual)
	{
		return AssertionMessageUtil.GetMessage(
			string.Format(
				"Values are {0}equal.",
				(!expectEqual) ? string.Empty : "not "
			),
			string.Format(
				"{0} {2} {1}",
				actual,
				expected,
				(!expectEqual) ? "!=" : "=="
			)
		);
	}

	public static string NullFailureMessage(object value, bool expectNull)
	{
		return AssertionMessageUtil.GetMessage(
			string.Format(
				"Value was {0}Null",
				(!expectNull) ? string.Empty : "not "
			),
			string.Format(
				"Value was {0}Null",
				(!expectNull) ? "not " : string.Empty
			)
		);
	}

	public static string BooleanFailureMessage(bool expected)
	{
		return AssertionMessageUtil.GetMessage("Value was " + !expected, expected.ToString());
	}
}