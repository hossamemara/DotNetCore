using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Entities;

namespace DotNetCore.Interfaces
{
    public interface IToken
    {
        TokenResponse GetUserToken(AuthenticationRequest request,User user,List<Role> role);
    }
}
