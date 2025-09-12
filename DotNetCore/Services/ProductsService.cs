using DotNetCore.DBContext;
using DotNetCore.Helpers;
using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.Services
{
    public class ProductsService : IProducts
    {
        private readonly ApplicationDBContext _context;
        public ProductsService(ApplicationDBContext context) 
        { 
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var data =await _context.Set<Product>().ToListAsync();
            return data;
        }
    }
}
