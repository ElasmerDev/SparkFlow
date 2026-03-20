// -----------------------------------------------------------------------------
// File: ServiceResult.cs
// Path: src/Shared/SparkFlow.Shared.Core/Results/ServiceResult.cs
// Description:
//   Provides a standard result model for application and infrastructure services.
//   This implementation supports both non-generic and generic success/failure
//   flows while keeping error information explicit and strongly typed.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Core.Results;

/// <summary>
/// Represents the outcome of a service operation without a value payload.
/// </summary>
public class ServiceResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceResult"/> class.
    /// </summary>
    protected ServiceResult(bool isSuccess, ServiceError? error)
    {
        if (isSuccess && error is not null)
        {
            throw new InvalidOperationException("A successful result cannot contain an error.");
        }

        if (!isSuccess && error is null)
        {
            throw new InvalidOperationException("A failed result must contain an error.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the operation succeeded.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error payload for failed operations.
    /// </summary>
    public ServiceError? Error { get; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    public static ServiceResult Success()
        => new(true, null);

    /// <summary>
    /// Creates a failed result with a structured error payload.
    /// </summary>
    public static ServiceResult Failure(ServiceError error)
        => new(false, error);

    /// <summary>
    /// Creates a failed result with a code and message.
    /// </summary>
    public static ServiceResult Failure(string code, string message)
        => new(false, new ServiceError(code, message));

    /// <summary>
    /// Creates a successful generic result.
    /// </summary>
    public static ServiceResult<T> Success<T>(T value)
        => ServiceResult<T>.Success(value);

    /// <summary>
    /// Creates a failed generic result using the current error payload.
    /// </summary>
    public ServiceResult<T> ToFailure<T>()
    {
        if (IsSuccess)
        {
            throw new InvalidOperationException("Cannot convert a successful result into a failure result.");
        }

        return ServiceResult<T>.Failure(Error!);
    }
}

/// <summary>
/// Represents the outcome of a service operation with a value payload.
/// </summary>
/// <typeparam name="T">
/// The payload type.
/// </typeparam>
public sealed class ServiceResult<T> : ServiceResult
{
    private ServiceResult(T? value, bool isSuccess, ServiceError? error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the value returned by a successful operation.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Creates a successful typed result.
    /// </summary>
    public static ServiceResult<T> Success(T value)
        => new(value, true, null);

    /// <summary>
    /// Creates a failed typed result using a structured error payload.
    /// </summary>
    public static new ServiceResult<T> Failure(ServiceError error)
        => new(default, false, error);

    /// <summary>
    /// Creates a failed typed result using a code and message.
    /// </summary>
    public static new ServiceResult<T> Failure(string code, string message)
        => new(default, false, new ServiceError(code, message));

    /// <summary>
    /// Returns the success value or throws when the result is a failure.
    /// </summary>
    public T EnsureValue()
    {
        if (IsFailure)
        {
            throw new InvalidOperationException(
                $"Cannot access {nameof(Value)} on a failed result. Error: {Error?.Code} - {Error?.Message}");
        }

        return Value!;
    }

    /// <summary>
    /// Maps a successful payload into another type while preserving failures.
    /// </summary>
    public ServiceResult<TTarget> Map<TTarget>(Func<T, TTarget> mapper)
    {
        ArgumentNullException.ThrowIfNull(mapper);

        if (IsFailure)
        {
            return ServiceResult<TTarget>.Failure(Error!);
        }

        return ServiceResult<TTarget>.Success(mapper(Value!));
    }
}