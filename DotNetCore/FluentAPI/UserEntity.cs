using DotNetCore.DataContext;
using DotNetCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.FluentAPI
{
    public class UserEntity : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> options)
        {

            //fluent api create index  options.HasIndex(item => item.Email);

            options.HasIndex(item => new { item.Email, item.Country }).IsUnique();
            // Role vs Users Many to Many
            options.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<RoleUser>(
            // RoleUser -> Role
            j => j.HasOne(e => e.Role)
             .WithMany()
             .HasForeignKey(e => e.RolesId),
            // RoleUser -> User
            j => j.HasOne(e => e.User)
             .WithMany()
             .HasForeignKey(e => e.UsersId),
           // Join table config
           j =>
           {
               j.ToTable("RoleUser");
               j.HasKey(e => new { e.UsersId, e.RolesId });
           });


            // Permission vs Users Many to Many

            options.HasMany(u => u.Permissions)
                .WithMany(r => r.Users)
                .UsingEntity<PermissionUser>(
                // PermissionUser -> Permission
                j => j.HasOne(e => e.Permission)
                 .WithMany()
                 .HasForeignKey(e => e.PermissionsId),
                // PermissionUser -> User
                j => j.HasOne(e => e.User)
                 .WithMany()
                 .HasForeignKey(e => e.UsersId),
               // Join table config
               j =>
               {
                   j.ToTable("PermissionUser");
                   j.HasKey(e => new { e.UsersId, e.PermissionsId });
               });


        }
    }
}
