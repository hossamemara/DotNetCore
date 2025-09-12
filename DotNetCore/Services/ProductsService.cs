using DotNetCore.DBContext;
using DotNetCore.Helpers;
using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.Services
{
    public class ProductsService(ApplicationDBContext context) : IProducts
    {
        private readonly ApplicationDBContext _context = context;


        #region GetProducts

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var data = await _context.Set<Product>().ToListAsync();
            return data;
        }

        #endregion



        #region AddProduct

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            _context.SaveChanges();
            return product;
        }

        #endregion



        #region UpdateProduct

        public async Task<Product?> UpdateProduct(Product product)
        {
            var data = await _context.Set<Product>().FindAsync(product.Id);
            if (data == null)
            {
                return null;
            }
            else
            {
                data.Name = product.Name;
                data.Sku = product.Sku;
                _context.Set<Product>().Update(data);
                _context.SaveChanges();
            }

            return data;
        }

        #endregion


        #region DeleteProduct
        public async Task<Product?> DeleteProduct(Product product)
        {
            var data = await _context.Set<Product>().FindAsync(product.Id);
            if (data == null)
            {
                return null;
            }
            else
            {
                _context.Set<Product>().Remove(data);
                _context.SaveChanges();
            }

            return data;
        }

        #endregion

    }
}
