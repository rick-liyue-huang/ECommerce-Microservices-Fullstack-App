namespace eCommerceSolution.UsersService.API.Middlewares;


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
            if (ex.InnerException is not null)
            {
                logger.LogError(ex.InnerException, $"{ex.InnerException.GetType().ToString()} : {ex.InnerException.Message}");
            }
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(
                new
                {
                    Message = "Internal Server Error", 
                    Type = ex.GetType().ToString()
                }
            );
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