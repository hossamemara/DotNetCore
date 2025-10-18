namespace DotNetCore.DataContext
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public byte[]? Password { get; set; }
    }
}
