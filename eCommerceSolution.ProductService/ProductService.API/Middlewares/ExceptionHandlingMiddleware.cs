namespace ProductService.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                logger.LogError(
                    "{ExceptionType} {ExceptionMessage}",
                    ex.InnerException.GetType().ToString(), 
                    ex.InnerException.Message);
            }
            else
            {
                logger.LogError(
                    "{ExceptionType} {ExceptionMessage}", 
                    ex.GetType().ToString(), ex.Message);
            }
            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString()});
        }
    }

}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}

