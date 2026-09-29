using Fintalks.Common.Constants;
using Fintalks.Common.Exceptions;
using Fintalks.Common.Models;
using Microsoft.AspNetCore.Diagnostics;

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

        var response = new ErrorResponse
        {
            Success = false,
            Message = message,
            Errors = null,
            Stack = exception.StackTrace,
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }

    private static (int StatusCode, string Message) MapException(Exception exception) =>
        exception switch
        {
            AppException appEx => ((int)appEx.StatusCode, appEx.Message),
            _ => (StatusCodes.Status500InternalServerError, ErrorConst.Message.genericError),
        };
}
