using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DotNetCore.Authorization
{
    public class PermissionBasedAuthorizationFilter(ApplicationDBContext dBContext) : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var attribute =(CheckPermissionAttribute)context.ActionDescriptor.EndpointMetadata.FirstOrDefault(item => item is CheckPermissionAttribute);
            if (attribute != null)
            {
                var claimIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
                if (claimIdentity is null || !claimIdentity.IsAuthenticated) 
                {
                    context.Result = new ForbidResult();
                }
                else
                {
                    var UserId = int.Parse(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    var hasPermission = dBContext.Set<UserPermission>().Any(item => item.UserId == UserId && item.PermissionId == (int)attribute.Permission);
                    if (!hasPermission)
                    {
                        context.Result = new ForbidResult();
                    }     
                }
                
            }
                
        }
    }
}
