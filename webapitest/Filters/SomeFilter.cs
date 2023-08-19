using Microsoft.AspNetCore.Mvc.Filters;

namespace webapitest.Filters;

public class SomeFilter: ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var constants = new Constants();
        
        if (constants.GenerateException)
            throw new Exception("Filter Exception");

        await next();
    }
}