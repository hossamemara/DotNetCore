using DotNetCore.ConfigurationClasses;
using DotNetCore.DataContext;
using DotNetCore.FluentAPI;
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

        // create new table Employees

        /* EF core 
        
        1. add-migration migrationName
        2. update-database  & update-database migrationName للرجوع من اول الميجريشن داه 
        3. rollback all migrations   update-database -migration:0
        4. mark column as required
        5. add entity to model
        6. exclude entity from model 
        7. change table name
        8. change schema
        9. exclude property
        10. change column name
        11. change column data types 
        12. maximum length
        13. column comment
        14. set primary key
        15. change primary key name 
        16. set composite key
        17. set default value
        18. set computed column
        19. primary key default value 
        20. one to one relationship
        21. one to many relationship
        22. many to many relationship
        23. Indexes  -- by default added to foreign keys
        24. composite Index
        25. Unique Index
        26. Global Sequence on Column on All Tables  
        27. Data Seeding (Dummy Data)
        27. Linq select all and select one  .ToListAsync()   .Find(1)  by primary key
        28. Linq select one  .Single() // has exception if no data found or more than row found  
        .SingleOrDefault()  top 1 

         */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Blog> Blogs { get; set; } // Parent and its child BlogImage
        public DbSet<Product> Products { get; set; } 
        public DbSet<Car> Cars { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderNew> OrdersNew { get; set; }
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
                // data seeding
                modelBuilder.Entity<Blog>().HasData(new Blog { Id = 1,Url = "www.google.com"});
                // fluent api
                new ProductsEntity().Configure(modelBuilder.Entity<Product>());

                new UserEntity().Configure(modelBuilder.Entity<User>());

                //Global Sequence on Column on All Tables
                modelBuilder.HasSequence<int>("OrderNumber");
                modelBuilder.Entity<Order>().Property(o=>o.OrderNumber).HasDefaultValueSql("NEXT VALUE FOR OrderNumber");
                modelBuilder.Entity<OrderNew>().Property(o=>o.OrderNumber).HasDefaultValueSql("NEXT VALUE FOR OrderNumber");


                // one to one 
                modelBuilder.Entity<Blog>().HasOne(item => item.BlogImage).WithOne(item => item.Blog)
                    .HasForeignKey<BlogImage>(item => item.BlogId);

                // one to many 
                modelBuilder.Entity<RecordOfSale>().HasOne(item => item.Car).WithMany(item => item.SaleHistory)
                    .HasForeignKey(item => item.CarId);

               






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
