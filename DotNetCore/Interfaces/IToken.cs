using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Entities;

namespace DotNetCore.Interfaces
{
    public interface IToken
    {
        string? GetUserToken(AuthenticationRequest request,User user);
    }
}
