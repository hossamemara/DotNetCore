using ImTools;
using JasperFx.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DotNetCore.Authorization
{
    public class USARegionOnlyHandler : AuthorizationHandler<USARegionOnlyRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, USARegionOnlyRequirements requirement)
        {
            if (context.User.FindFirstValue(ClaimTypes.Country) == "USA")
                context.Succeed(requirement);
            return Task.CompletedTask;

        }
    }
}
