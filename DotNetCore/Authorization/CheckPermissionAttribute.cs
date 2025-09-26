using DotNetCore.Entities;

namespace DotNetCore.Authorization
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class CheckPermissionAttribute(Permission permission) : Attribute
    {
        public Permission Permission { get; } = permission;
    }
}
