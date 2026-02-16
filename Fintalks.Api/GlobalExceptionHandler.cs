using System.ComponentModel.DataAnnotations;
using Fintalks.Api.Exceptions;
using Fintalks.Common.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public sealed class GlobalExceptionHandler() : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var (statusCode, message) = MapException(exception);

        httpContext.Response.StatusCode = statusCode;

        object? errors = null;
        if (exception is Fintalks.Common.Exceptions.ValidationException validationException)
        {
            errors = validationException.Errors;
        }

        var response = new ErrorResponse
        {
            Success = false,
            Message = message,
            Errors = errors,
            Stack = exception.StackTrace,
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }

    private static (int StatusCode, string Message) MapException(Exception exception) =>
        exception switch
        {
            AppException appEx => ((int)appEx.StatusCode, appEx.Message),
            ArgumentNullException => (StatusCodes.Status400BadRequest, "Invalid argument provided"),
            ArgumentException => (StatusCodes.Status400BadRequest, "Invalid argument provided"),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred"),
        };
}
