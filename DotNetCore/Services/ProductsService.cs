using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.Services
{
    public class ProductsService(ApplicationDBContext context) : IProducts
    {
        private readonly ApplicationDBContext _context = context;


        #region Get Products

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var data = await _context.Set<Product>().ToListAsync();
            return data;
        }

        #endregion


        #region Get Products

        public async Task<Product?> GetWithLinq(Product product)
        {
            //var data = await _context.Set<Product>().SingleOrDefaultAsync(item=>item.Id == product.Id);
            var data = await _context.Set<Product>().FirstOrDefaultAsync(item=>item.Id == product.Id);
            //var data = await _context.Set<Product>().FindAsync(product.Id);
            return data;
        }

        #endregion


        #region Get Products By Filter

        public async Task<Product?> GetProductsByFilter(int id)
        {
            var data = await _context.Set<Product>().FindAsync(id);
            return data;
        }

        #endregion


        #region AddProduct

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        #endregion


        #region UpdateProduct

        public async Task<Product?> UpdateProduct(Product product)
        {
            var data = await _context.Set<Product>().FindAsync(product.Id);
            if (data is not null)
            {
                data.Name = product.Name;
                data.Sku = product.Sku;
                await _context.SaveChangesAsync();
            }

            return data;
        }

        #endregion


        #region DeleteProduct
        public async Task<Product?> DeleteProduct(int id)
        {
            var data = await _context.Set<Product>().FindAsync(id);
            if (data is not null)
            {
                _context.Set<Product>().Remove(data);
                await _context.SaveChangesAsync();
            }

            return data;
        }

        #endregion

    }
}
