namespace BusinessLogicLayer.Dtos;

public record ProductUpdateRequest(
    Guid ProductId,
    string ProductName,
    CategoryOption Category,
    double? UnitPrice,
    int? QuantityInStock
)
{
    public ProductUpdateRequest(): this(default, default, default, 
        default, default){}
}