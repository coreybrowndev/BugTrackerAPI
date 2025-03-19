using System.Net;
using System.Text.Json;
using BugTracker.Api.Exceptions;

namespace BugTracker.Api.Middleware.ExceptionConfig;

public class ExceptionMiddleware 
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
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        var errorDetails = new ExceptionDetailsConfiguration
        {
            ErrorType = "Failure",
            ErrorMessage = exception.Message, 
            StatusCode = (int)statusCode
        };

        switch(exception)
        {
            case NotFoundException _:
                statusCode = HttpStatusCode.NotFound;
                errorDetails.ErrorType = "Not Found";
                break;
            case BadRequestException _:
                statusCode = HttpStatusCode.BadRequest;
                errorDetails.ErrorType = "Bad Request";
                break;
            default:
                break;
        }

        errorDetails.StatusCode = (int)statusCode;
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(errorDetails.ToString());
    }
}