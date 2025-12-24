using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.ServiceContracts;
using FluentValidation;

namespace ProductService.API.ApiEndpoints;

public static class ProductApiEndpoints
{
    public static IEndpointRouteBuilder MapProductApiEndpoints(this IEndpointRouteBuilder app)
    {
        // minimal API endpoints can be defined here in the future
        
        // GET /api/products
        app.MapGet("/api/products", async (IProductsService productsService) =>
        {
            List<ProductResponse?> products = await productsService.GetProducts();
            return Results.Ok(products);
        });
        
        
        // GET /api/products/search/product-id/{productId}
        app.MapGet("/api/products/search/product-id/{productId:guid}", async (IProductsService productsService, Guid productId) =>
        {
            ProductResponse? product = await productsService.GetProductByCondition(p => p.ProductId == productId);
            return product != null ? Results.Ok(product) : Results.NotFound();
        });

        app.MapGet(
            "/api/products/search/{searchString}",
            async (IProductsService productsService, string searchString) =>
            {
                List<ProductResponse?> productsByProductName = await productsService
                    .GetProductsByCondition(p => 
                        p.ProductName != null && p.ProductName!.Contains(searchString));
                
                List<ProductResponse?> productsByCategory = await productsService
                    .GetProductsByCondition(p => 
                        p.Category != null && p.Category!.Contains(searchString));

                var unionProducts = productsByProductName.Union(productsByCategory);
                return Results.Ok(unionProducts);
        });

        app.MapPost("/api/products",
            async (
                IProductsService productsService,
                IValidator<ProductAddRequest> productAddRequestValidator,
                ProductAddRequest productAddRequest) =>
            {
                // Validate the request using fluent validation
                var validationResult = await productAddRequestValidator.ValidateAsync(productAddRequest);
                if (!validationResult.IsValid)
                {
                    Dictionary<string, string[]> errors = validationResult.Errors.GroupBy(temp => 
                        temp.PropertyName).ToDictionary(temp => temp.Key, temp => 
                        temp.Select(error => error.ErrorMessage).ToArray());
                    
                    return Results.BadRequest(errors);
                }
                var addedProductResponse = await productsService.AddProduct(productAddRequest);
                if (addedProductResponse != null)
                {
                    return Results.Created($"/api/products/search/product-id/{addedProductResponse.ProductId}", addedProductResponse);
                }
                else
                {
                    return Results.Problem("Product could not be added");
                }
            }
        );
        
        app.MapPut("/api/products",
            async (
                IProductsService productsService,
                IValidator<ProductUpdateRequest> productUpdateRequestValidator,
                ProductUpdateRequest productUpdateRequest) =>
            {
                // Validate the request using fluent validation
                var validationResult = await productUpdateRequestValidator.ValidateAsync(productUpdateRequest);
                if (!validationResult.IsValid)
                {
                    Dictionary<string, string[]> errors = validationResult.Errors.GroupBy(temp => 
                        temp.PropertyName).ToDictionary(temp => temp.Key, temp => 
                        temp.Select(error => error.ErrorMessage).ToArray());
                    
                    return Results.BadRequest(errors);
                }
                var updatedProductResponse = await productsService.UpdateProduct(productUpdateRequest);
                if (updatedProductResponse != null)
                {
                    return Results.Ok(updatedProductResponse);
                }
                else
                {
                    return Results.Problem("Product could not be updated");
                }
            }
        );
        
        app.MapDelete("/api/products/{productId:guid}",
            async (
                IProductsService productsService,
                Guid productId) =>
            {
                bool isDeleted = await productsService.DeleteProduct(productId);
                if (isDeleted)
                {
                    return Results.Ok(true);
                }
                else
                {
                    return Results.Problem("Product could not be deleted");
                }
            }
        );
        
        return app;
    }
}