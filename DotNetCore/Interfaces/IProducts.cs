using DotNetCore.DBContext;
using DotNetCore.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
