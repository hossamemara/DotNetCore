using DotNetCore.ConfigurationClasses;
using DotNetCore.DataContext;
using JasperFx.CodeGeneration.Frames;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DotNetCore.DBContext
{
    public class ApplicationDBContext:DbContext
    {

        private readonly string? _connectionString_sql;
        private readonly string? _connectionStringPostgresSQL;
        private readonly IOptionsSnapshot<ConnectionStrings> _optionsSnapshot;
        private readonly string? _mongoClient;
        private readonly string? _dbName;
        public ApplicationDBContext(IOptionsSnapshot<ConnectionStrings> optionsSnapshot)
        {
            _optionsSnapshot = optionsSnapshot;
            _connectionString_sql = _optionsSnapshot .Value.SqlServerApp;
            _connectionStringPostgresSQL = _optionsSnapshot.Value.PostgresSQLServerApp;
            _dbName = _optionsSnapshot.Value.MongoDatabaseName;
            _mongoClient = _optionsSnapshot.Value.MongoDb;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_optionsSnapshot.Value.DataBaseType == "sqlServer")
            {
                optionsBuilder.UseSqlServer(_connectionString_sql);

            }
            else if (_optionsSnapshot.Value.DataBaseType == "mongoDb")
            {
                optionsBuilder.UseMongoDB(_mongoClient, _dbName);

            }
            else if (_optionsSnapshot.Value.DataBaseType == "PostgresDb")
            {
                optionsBuilder.UseNpgsql(_connectionStringPostgresSQL);

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_optionsSnapshot.Value.DataBaseType == "sqlServer")
            {
                modelBuilder.Entity<Product>().ToTable("Products");
                modelBuilder.Entity<User>().ToTable("Users");
                modelBuilder.Entity<UserPermission>().ToTable("UserPermissions").HasKey(item => new {item.UserId, item.PermissionId});


            }
            else if (_optionsSnapshot.Value.DataBaseType == "mongoDb")
            {
                modelBuilder.Entity<ProductsCollection>().ToCollection("Products");

            }
            else if (_optionsSnapshot.Value.DataBaseType == "PostgresDb")
            {
                modelBuilder.Entity<Product>().ToTable("Products");
             

            }
        }


    }
}
