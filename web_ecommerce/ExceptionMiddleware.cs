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

public class ErrorResponse
{
    public ErrorResponse(HttpStatusCode statusCode, string errorMessage)
    {
    }
}