using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using webapitest.Filters;

namespace webapitest.Controllers;

[Route("api/test")]
[SomeFilter]
public class SomeController: Controller
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await base.OnActionExecutionAsync(context, next);
     
        var constants = new Constants();
        
        if (constants.GenerateException)
        {
            throw new Exception("Some Controller Exception");
        }
        
        await next();
    }

    
    [HttpGet]
    public async Task<IActionResult> GetScuole()
    {
        return Ok("Hello World");
    }
}