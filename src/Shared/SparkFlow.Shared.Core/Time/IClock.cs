// -----------------------------------------------------------------------------
// File: IClock.cs
// Path: src/Shared/SparkFlow.Shared.Core/Time/IClock.cs
// Description:
//   Defines an abstraction for retrieving the current UTC time.
//   This should be used instead of calling DateTime.UtcNow or
//   DateTimeOffset.UtcNow directly in application code.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Core.Time;

/// <summary>
/// Represents an abstraction for current time access.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets the current UTC date and time.
    /// </summary>
    DateTime UtcNow { get; }

    /// <summary>
    /// Gets the current UTC date and time with offset support.
    /// </summary>
    DateTimeOffset UtcNowOffset { get; }
}