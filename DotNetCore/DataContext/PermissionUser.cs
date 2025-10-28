namespace DotNetCore.DataContext
{
    public class PermissionUser
    {
        public int UsersId { get; set; }
        public int PermissionsId { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
