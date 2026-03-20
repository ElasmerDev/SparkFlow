// -----------------------------------------------------------------------------
// File: FakeClock.cs
// Path: src/Shared/SparkFlow.Shared.Core/Time/FakeClock.cs
// Description:
//   Test-friendly implementation of IClock that allows deterministic time control.
//   This is useful for unit tests, integration tests, and offline scenarios.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Core.Time;

/// <summary>
/// Provides a manually controlled implementation of <see cref="IClock"/>.
/// </summary>
public sealed class FakeClock : IClock
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FakeClock"/> class.
    /// </summary>
    public FakeClock(DateTimeOffset initialUtc)
    {
        CurrentUtc = initialUtc.ToUniversalTime();
    }

    /// <summary>
    /// Gets the current fake UTC time.
    /// </summary>
    public DateTimeOffset CurrentUtc { get; private set; }

    /// <inheritdoc />
    public DateTime UtcNow => CurrentUtc.UtcDateTime;

    /// <inheritdoc />
    public DateTimeOffset UtcNowOffset => CurrentUtc;

    /// <summary>
    /// Moves the fake clock forward by the specified time span.
    /// </summary>
    public void Advance(TimeSpan timeSpan)
    {
        CurrentUtc = CurrentUtc.Add(timeSpan);
    }

    /// <summary>
    /// Sets the fake clock to a specific UTC time.
    /// </summary>
    public void Set(DateTimeOffset utcDateTime)
    {
        CurrentUtc = utcDateTime.ToUniversalTime();
    }
}