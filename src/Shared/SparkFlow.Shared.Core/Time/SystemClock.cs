// -----------------------------------------------------------------------------
// File: SystemClock.cs
// Path: src/Shared/SparkFlow.Shared.Core/Time/SystemClock.cs
// Description:
//   Default runtime implementation of IClock based on the system UTC clock.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Core.Time;

/// <summary>
/// Provides the current UTC time using the system clock.
/// </summary>
public sealed class SystemClock : IClock
{
    /// <inheritdoc />
    public DateTime UtcNow => DateTime.UtcNow;

    /// <inheritdoc />
    public DateTimeOffset UtcNowOffset => DateTimeOffset.UtcNow;
}