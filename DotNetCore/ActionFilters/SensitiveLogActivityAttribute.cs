using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace DotNetCore.ActionFilters
{
    public class SensitiveLogActivityAttribute: ActionFilterAttribute
    {
     
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine("SensitiveLogActivityAttribute started !!!!!!!");
            if (context.ActionDescriptor.RouteValues["controller"] != "Products")
                context.Result = new NotFoundResult();
            else
                await base.OnActionExecutionAsync(context, next);
        }

    }
}
