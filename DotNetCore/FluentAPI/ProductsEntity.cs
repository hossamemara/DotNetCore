using DotNetCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.FluentAPI
{
    public class ProductsEntity:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> options)
        {
            options.Property(a => a.Sku).HasMaxLength(50);
        }
    }
}
