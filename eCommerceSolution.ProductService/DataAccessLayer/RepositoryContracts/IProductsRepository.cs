using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

/// <summary>
/// represents a products repository for managing products table
/// </summary>
public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression);
    Task<Product?> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression);
    Task<Product?> AddProductAsync(Product product);
    Task<Product?> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Guid productId);
}