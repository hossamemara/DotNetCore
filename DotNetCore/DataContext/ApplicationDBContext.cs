using Microsoft.EntityFrameworkCore;

namespace DotNetCore.DBContext
{
    public class ApplicationDBContext:DbContext
    {

        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        

        public ApplicationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlServerApp");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }


    }
}
