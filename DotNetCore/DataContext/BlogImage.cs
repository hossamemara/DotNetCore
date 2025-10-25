using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore.DataContext
{
    [Table("BlogImages")]
    // Child 
    public class BlogImage
    {
        public int Id { get; set; }
        public byte [] Image { get; set; }
        public string Caption { get; set; }
        public int BlogId { get; set; }
        
        //[ForeignKey("BlogId")]
        public Blog Blog { get; set; }  
    }
}
