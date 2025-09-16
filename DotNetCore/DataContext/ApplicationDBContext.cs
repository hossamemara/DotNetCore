using Microsoft.EntityFrameworkCore;

namespace DotNetCore.DBContext
{
    public class ApplicationDBContext:DbContext
    {

        private readonly IConfiguration _configuration;
        private readonly string? _connectionString_sql;
        private readonly string? _connectionStringPostgresSQL;


        public ApplicationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString_sql = _configuration["ConnectionStrings:SqlServerApp"];
            _connectionStringPostgresSQL = _configuration["ConnectionStrings:PostgresSQLServerApp"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString_sql);
            //optionsBuilder.UseNpgsql(_connectionStringPostgresSQL);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }


    }
}
