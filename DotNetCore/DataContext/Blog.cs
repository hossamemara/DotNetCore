using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore.DataContext
{
    [Table("Blogs")]
    // Parent 
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public BlogImage BlogImage { get; set; }
    }
}
