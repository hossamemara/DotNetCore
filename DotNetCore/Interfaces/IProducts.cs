using DotNetCore.DBContext;
using DotNetCore.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product product);
        Task<Product?> UpdateProduct(Product product);
        Task<Product?> DeleteProduct(Product product);
    }
}
