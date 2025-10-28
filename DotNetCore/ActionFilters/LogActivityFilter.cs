using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCore.ActionFilters
{
    public class LogActivityFilter : IAsyncActionFilter
    {
        private readonly ILogger _logger;
        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger= logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation(context.ActionDescriptor.DisplayName);
            if (context.ActionDescriptor.DisplayName == "DotNetCore.Controllers.ProductsController.DeleteProduct (DotNetCore)")
                context.Result = new BadRequestResult();
            else
                await next();

        }
    }
}
