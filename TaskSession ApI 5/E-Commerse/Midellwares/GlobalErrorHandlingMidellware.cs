using System.Diagnostics;
using System.Net;
using Domain.Exceptions;
using Shared.ErrorModels;

namespace E_Commerse.Midellwares;

public class GlobalErrorHandlingMidellware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorHandlingMidellware> _logger;

    public GlobalErrorHandlingMidellware(RequestDelegate next,ILogger<GlobalErrorHandlingMidellware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
            if(context.Response.StatusCode==(int)HttpStatusCode.NotFound) await HandelNotFoundApiAsync(context);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error went wrong : {ex}");
            await HandleException(context, ex);
        }
    }

    private async Task HandelNotFoundApiAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var response = new ErrorDetails()
        {
            StatusCode = (int)HttpStatusCode.NotFound,
            ErrorMessage = $"The end point {context.Request.Path} was not found"
        }.ToString();
        await context.Response.WriteAsync(response);
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        context.Response.ContentType="application/json";
        //context.Response.StatusCode= (int)HttpStatusCode.InternalServerError;
        var response = new ErrorDetails
        {
            ErrorMessage = exception.Message,
        };
        context.Response.StatusCode = exception switch
        {
            NotFoundException =>(int) HttpStatusCode.NotFound,
            UnAuthenticationException => (int) HttpStatusCode.Unauthorized,
            ValidationException validationException=> HandleErrorException(validationException,response),
            _ => (int)HttpStatusCode.InternalServerError

        };
        response.StatusCode=context.Response.StatusCode;
        await context.Response.WriteAsync(response.ToString());
    }

    private int HandleErrorException(ValidationException validationException, ErrorDetails response)
    {
        response.Errors = validationException.Errors;
        return response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
}