using System.Linq.Expressions;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductsRepository
{
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression)
    {
        return await context.Products.Where(conditionExpression).ToListAsync();
    }

    public async Task<Product?> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression)
    {
        return await context.Products.FirstOrDefaultAsync(conditionExpression);
    }

    public async Task<Product?> AddProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        Product? existingProduct = await context.Products.FirstOrDefaultAsync(temp => temp.ProductId == product.ProductId);
        if (existingProduct == null)
        {
            return null;
        }
        else
        {
            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.QuantityInStock = product.QuantityInStock;

            await context.SaveChangesAsync();
            return existingProduct;
        }
    }

    public async Task<bool> DeleteProductAsync(Guid productId)
    {
        Product? existingProduct = await context.Products.FirstOrDefaultAsync(temp => temp.ProductId == productId);
        if (existingProduct == null)
        {
            return false;
        }
        else
        {
            context.Products.Remove(existingProduct);
            int affectedRowCount = await context.SaveChangesAsync();
            return affectedRowCount > 0;
        }
    }
}