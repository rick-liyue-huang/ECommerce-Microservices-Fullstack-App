using System.Linq.Expressions;
using BusinessLogicLayer.Dtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductsService
{
    Task<List<ProductResponse?>> GetProducts();
    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);
    Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);
    Task<ProductResponse?> AddProduct(ProductAddRequest product);
    Task<ProductResponse?> UpdateProduct(ProductUpdateRequest product);
    Task<bool> DeleteProduct(Guid productId);
}