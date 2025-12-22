using System.Linq.Expressions;
using AutoMapper;
using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using FluentValidation;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLogicLayer.Services;

public class ProductService(
    IValidator<ProductAddRequest> productAddRequestValidator,
    IValidator<ProductUpdateRequest> productUpdateRequestValidator,
    IMapper mapper,
    IProductsRepository productsRepository) : IProductsService
{
    public async Task<List<ProductResponse?>> GetProducts()
    {
        IEnumerable<Product?> products = await productsRepository.GetAllProductsAsync();
        IEnumerable<ProductResponse?> responses = mapper.Map<IEnumerable<ProductResponse>>(products);
        return responses.ToList();
    }

    public async Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        Product? product = await productsRepository.GetProductByConditionAsync(conditionExpression);

        if (product == null)
        {
            return null;
        }
        
        ProductResponse response = mapper.Map<ProductResponse>(product); // invokes ProductToProductResponseMappingProfile
        return response;
    }

    public async Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        IEnumerable<Product?> products = await productsRepository.GetProductsByConditionAsync(conditionExpression);
        IEnumerable<ProductResponse?> responses = mapper.Map<IEnumerable<ProductResponse>>(products);
        return responses.ToList();
    }

    public async Task<ProductResponse?> AddProduct(ProductAddRequest product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        
        // Validate the request
        var validationResult = await productAddRequestValidator.ValidateAsync(product);
        if (!validationResult.IsValid)
        {
            string errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            throw new ArgumentException(errors);
        }
        
        // Map the request to a Product entity
        Product mappedProduct = mapper.Map<Product>(product);
        Product? addedProduct = await productsRepository.AddProductAsync(mappedProduct);

        if (addedProduct == null)
        {
            return null;
        }
        
        ProductResponse productResponse = mapper.Map<ProductResponse>(addedProduct);
        return productResponse;
    }

    public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest product)
    {
        Product? existingProduct = await productsRepository.GetProductByConditionAsync(temp => temp.ProductId == product.ProductId);

        if (existingProduct == null)
        {
            throw new ArgumentException("Product not found");
        }
        
        // Validate the request
        ValidationResult validationResult = await productUpdateRequestValidator.ValidateAsync(product);
        if (!validationResult.IsValid)
        {
            string errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            throw new ArgumentException(errors);
        }
        
        // Map the request to a Product entity
        Product mappedProduct = mapper.Map<Product>(product); // invokes ProductUpdateRequestToProductMappingProfile
        Product? updatedProduct = await productsRepository.UpdateProductAsync(mappedProduct);
        if (updatedProduct == null)
        {
            return null;
        }
        
        ProductResponse productResponse = mapper.Map<ProductResponse>(updatedProduct);
        return productResponse;
        
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        Product? product = await productsRepository.GetProductByConditionAsync(temp => temp.ProductId == productId);

        if (product == null)
        {
            return false;
        }
        
        return await productsRepository.DeleteProductAsync(productId);
    }
}