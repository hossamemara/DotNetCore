namespace DotNetCore.DataContext
{
    public class RoleUser
    {
        public int UsersId { get; set; }
        public int RolesId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
