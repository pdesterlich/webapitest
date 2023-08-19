namespace webapitest.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    /// <summary>
    /// gestisce l'eccezione
    /// </summary>
    /// <param name="httpContext">contesto della richiesta</param>
    /// <param name="requestDataManager">request data manager</param>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await httpContext.Response.WriteAsync(exception.Message);
        }
    }

}