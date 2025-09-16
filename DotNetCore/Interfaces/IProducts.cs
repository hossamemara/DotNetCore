﻿using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<ProductsCollection>> GetProducts();
        Task<Product?> GetProductsByFilter(int id);
        Task<Product> AddProduct(Product product);
        Task<Product?> UpdateProduct(Product product);
        Task<Product?> DeleteProduct(int id);
    }
}
