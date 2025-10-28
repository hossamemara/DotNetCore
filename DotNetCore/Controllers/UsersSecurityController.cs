using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Entities;
using DotNetCore.Helpers;
using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersSecurityController(IToken _token, ApplicationDBContext context) : ControllerBase
    {
        #region Get Products


        [HttpPost("GetUserToken")]

        public async Task<IActionResult> GetUserToken(AuthenticationRequest request)
        {
            try

            {
                byte[] passwordHash;
                using (SHA512 sha256 = SHA512.Create())
                {
                    passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                }

                var user = await context.Set<User>().FirstOrDefaultAsync(item => item.Email == request.Email && passwordHash.Equals(item.Password));
                


                if (user is null)
                        return Unauthorized(new ApiResponse { StatusCode = 401, AffectedRows = 0, Message = "Unauthorized", HttpStatusCodes = "Unauthorized", ExistanceFlag = false });
                
                else
                {
                    var roles = await context.Set<RoleUser>().Where(item => item.UsersId == user.Id).ToListAsync();
                    var roleNames = new List<Role> { };

                    foreach (var role in roles)
                    {

                        var roleName = await context.Set<Role>().FirstOrDefaultAsync(item => item.Id == role.RolesId);
                        if (!string.IsNullOrEmpty(roleName?.RoleName))
                        {
                            roleNames.Add(roleName);

                        }
                    }

                    var token = _token.GetUserToken(request, user, roleNames);
                    if (token is null)
                        return NotFound(new ApiResponse { StatusCode = 404, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found", ExistanceFlag = false });
                    else
                        return Ok(new ApiResponse { Data = token, StatusCode = 200, AffectedRows = 1, Message = "Data Found", HttpStatusCodes = "Success", ExistanceFlag = true });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "Bad Request" });
            }


        }


        #endregion

    }
}
