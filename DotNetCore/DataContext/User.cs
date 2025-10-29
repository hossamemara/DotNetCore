using Microsoft.EntityFrameworkCore;

namespace DotNetCore.DataContext
{
    [Index(nameof(Email),IsUnique =true)]
    // [Index(nameof(Email), nameof(Country))]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public byte[]? Password { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
