namespace BusinessLogicLayer.Dtos;

public record ProductUpdateRequest(
    Guid ProductId,
    string ProductName,
    string Category,
    double? UnitPrice,
    int? QuantityInStock
)
{
    public ProductUpdateRequest(): this(default, default, default, 
        default, default){}
}