// -----------------------------------------------------------------------------
// File: ExceptionMiddleware.cs
// Path: ./src/Server/SparkFlow.Server.Api/Middlewares/ExceptionMiddleware.cs
// Summary:
//   Captures unhandled exceptions and returns a simple error response.
//
// Responsibilities:
//   - Catch unhandled exceptions
//   - Return a 500 status code
//   - Prevent raw exception propagation to the pipeline
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Api.Middlewares;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(exception.Message);
        }
    }
}
