// -----------------------------------------------------------------------------
// File: ServiceError.cs
// Path: src/Shared/SparkFlow.Shared.Core/Results/ServiceError.cs
// Description:
//   Represents a normalized error payload used by service operations.
//   This type allows application services to return structured errors without
//   depending on exception-based flow for normal business failures.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Core.Results;

/// <summary>
/// Represents a structured error returned by a service operation.
/// </summary>
/// <param name="Code">
/// A machine-readable error code.
/// </param>
/// <param name="Message">
/// A human-readable error message.
/// </param>
public sealed record ServiceError(string Code, string Message)
{
    /// <summary>
    /// Creates a validation error payload.
    /// </summary>
    public static ServiceError Validation(string message)
        => new("validation_error", message);

    /// <summary>
    /// Creates a not-found error payload.
    /// </summary>
    public static ServiceError NotFound(string message)
        => new("not_found", message);

    /// <summary>
    /// Creates a conflict error payload.
    /// </summary>
    public static ServiceError Conflict(string message)
        => new("conflict", message);

    /// <summary>
    /// Creates an unauthorized error payload.
    /// </summary>
    public static ServiceError Unauthorized(string message)
        => new("unauthorized", message);

    /// <summary>
    /// Creates an internal error payload.
    /// </summary>
    public static ServiceError Internal(string message)
        => new("internal_error", message);
}