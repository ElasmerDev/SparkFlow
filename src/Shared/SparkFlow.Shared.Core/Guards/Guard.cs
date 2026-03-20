// -----------------------------------------------------------------------------
// File: Guard.cs
// Path: src/Shared/SparkFlow.Shared.Core/Guards/Guard.cs
// Description:
//   Provides simple and reusable guard clauses used across the solution.
//   These methods should be used to validate inputs and state at boundaries.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Core.Guards;

/// <summary>
/// Contains guard clause helpers for validating arguments and state.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Throws <see cref="ArgumentNullException"/> when the value is null.
    /// </summary>
    public static T AgainstNull<T>(T? value, string paramName)
        where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> when the string is null, empty, or whitespace.
    /// </summary>
    public static string AgainstNullOrWhiteSpace(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null, empty, or whitespace.", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> when the value is outside the allowed range.
    /// </summary>
    public static int AgainstOutOfRange(int value, int minimum, int maximum, string paramName)
    {
        if (value < minimum || value > maximum)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                value,
                $"Value must be between {minimum} and {maximum}.");
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> when the value is less than the minimum.
    /// </summary>
    public static int AgainstLessThan(int value, int minimum, string paramName)
    {
        if (value < minimum)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                value,
                $"Value must be greater than or equal to {minimum}.");
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="InvalidOperationException"/> when the condition is true.
    /// </summary>
    public static void AgainstInvalidState(bool invalidCondition, string message)
    {
        if (invalidCondition)
        {
            throw new InvalidOperationException(message);
        }
    }
}