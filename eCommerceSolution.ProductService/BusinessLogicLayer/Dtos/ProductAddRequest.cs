namespace BusinessLogicLayer.Dtos;

public record ProductAddRequest(
    string ProductName,
    CategoryOption Category,
    double? UnitPrice,
    int? QuantityInStock
)
{
    public ProductAddRequest(): this(default, default, default, default){}
}