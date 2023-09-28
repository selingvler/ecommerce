using System.Net;
using Newtonsoft.Json;

namespace web_ecommerce;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            ErrorResponse response;
            if (exception is SlnException)
            {
                response = new ErrorResponse(
                    HttpStatusCode.BadRequest,
                    exception.Message
                );
            }
            else
            {
                response = new ErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new string("Gönderilen istek başarısız sonuçlannmıştır") 
                    );
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(result);
            }
        }
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}

public class ErrorResponse : BaseClass
{
    private HttpStatusCode _statusCode;
    private string _errorMessage;
    public ErrorResponse(HttpStatusCode statusCode, string errorMessage)
    {
        _statusCode = statusCode;
        _errorMessage = errorMessage;
    }

    public override HttpStatusCode StatusCode
    {
        get => _statusCode;
        set => _statusCode = value;
    }

    public override string ErrorMessage
    {
        get => _errorMessage;
        set => _errorMessage = value;
    }
}

public class BaseClass
{
    public virtual HttpStatusCode StatusCode { get; set; }
    public virtual string ErrorMessage { get; set; }
}