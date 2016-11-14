using System;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEngine.Assertions;
using UnityEngine.Assertions.Comparers;

[DebuggerStepThrough]
public static class AssertFast
{
	public static bool raiseExceptions;

	private static void Fail(string message, string userMessage)
	{
		if (Debugger.IsAttached)
		{
			throw new AssertionException(message, userMessage);
		}
		if (raiseExceptions)
		{
			throw new AssertionException(message, userMessage);
		}
		if (userMessage != null)
		{
			message = userMessage + '\n' + message;
		}
		UnityEngine.Debug.LogAssertion(message);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsTrue(bool condition)
	{
		IsTrue(condition, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsTrue(bool condition, string message)
	{
		if (!condition)
		{
			Fail(AssertionMessageUtil.BooleanFailureMessage(true), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsFalse(bool condition)
	{
		IsFalse(condition, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsFalse(bool condition, string message)
	{
		if (condition)
		{
			Fail(AssertionMessageUtil.BooleanFailureMessage(false), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreApproximatelyEqual(float expected, float actual)
	{
		AreEqual<float>(
			expected,
			actual,
			null,
			FloatComparer.s_ComparerWithDefaultTolerance
		);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreApproximatelyEqual(float expected, float actual, string message)
	{
		AreEqual<float>(
			expected,
			actual,
			message,
			FloatComparer.s_ComparerWithDefaultTolerance
		);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreApproximatelyEqual(float expected, float actual, float tolerance)
	{
		AreApproximatelyEqual(expected, actual, tolerance, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreApproximatelyEqual(
		float expected,
		float actual,
		float tolerance,
		string message
	)
	{
		AreEqual<float>(expected, actual, message, new FloatComparer(tolerance));
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotApproximatelyEqual(float expected, float actual)
	{
		AreNotEqual<float>(
			expected,
			actual,
			null,
			FloatComparer.s_ComparerWithDefaultTolerance
		);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotApproximatelyEqual(float expected, float actual, string message)
	{
		AreNotEqual<float>(
			expected,
			actual,
			message,
			FloatComparer.s_ComparerWithDefaultTolerance
		);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance)
	{
		AreNotApproximatelyEqual(expected, actual, tolerance, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotApproximatelyEqual(
		float expected,
		float actual,
		float tolerance,
		string message
	)
	{
		AreNotEqual<float>(expected, actual, message, new FloatComparer(tolerance));
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreEqual<T>(T expected, T actual)
	{
		AreEqual<T>(expected, actual, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreEqual<T>(T expected, T actual, string message)
	{
		AreEqual<T>(expected, actual, message, EqualityComparer<T>.Default);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreEqual<T>(
		T expected,
		T actual,
		string message,
		IEqualityComparer<T> comparer
	)
	{
		if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T)))
		{
			AreEqual(expected as UnityEngine.Object, actual as UnityEngine.Object, message);
			return;
		}
		if (!comparer.Equals(actual, expected))
		{
			Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, true), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreEqual(
		UnityEngine.Object expected,
		UnityEngine.Object actual,
		string message
	)
	{
		if (actual != expected)
		{
			Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, true), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotEqual<T>(T expected, T actual)
	{
		AreNotEqual<T>(expected, actual, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotEqual<T>(T expected, T actual, string message)
	{
		AreNotEqual<T>(expected, actual, message, EqualityComparer<T>.Default);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotEqual<T>(
		T expected,
		T actual,
		string message,
		IEqualityComparer<T> comparer
	)
	{
		if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T)))
		{
			AreNotEqual(expected as UnityEngine.Object, actual as UnityEngine.Object, message);
			return;
		}
		if (comparer.Equals(actual, expected))
		{
			Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, false), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void AreNotEqual(
		UnityEngine.Object expected,
		UnityEngine.Object actual,
		string message
	)
	{
		if (actual == expected)
		{
			Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, false), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsNull<T>(T value) where T : class
	{
		IsNull<T>(value, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsNull<T>(T value, string message) where T : class
	{
		if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T)))
		{
			IsNull(value as UnityEngine.Object, message);
		}
		else if (value != null)
		{
			Fail(AssertionMessageUtil.NullFailureMessage(value, true), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsNull(UnityEngine.Object value, string message)
	{
		if (value != null)
		{
			Fail(AssertionMessageUtil.NullFailureMessage(value, true), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsNotNull<T>(T value) where T : class
	{
		IsNotNull<T>(value, null);
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsNotNull<T>(T value, string message) where T : class
	{
		if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T)))
		{
			IsNotNull(value as UnityEngine.Object, message);
		}
		else if (value == null)
		{
			Fail(AssertionMessageUtil.NullFailureMessage(value, false), message);
		}
	}

	#if UNITY_ASSERTIONS_DISABLE_FAST || !UNITY_ASSERTIONS
	[Conditional("__NEVER_DEFINED__")]
	#endif
	public static void IsNotNull(UnityEngine.Object value, string message)
	{
		if (value == null)
		{
			Fail(AssertionMessageUtil.NullFailureMessage(value, false), message);
		}
	}
}