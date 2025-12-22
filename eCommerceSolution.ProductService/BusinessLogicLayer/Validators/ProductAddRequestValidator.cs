using BusinessLogicLayer.Dtos;
using FluentValidation;

namespace BusinessLogicLayer.Validators;

public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
        RuleFor(temp => temp.ProductName).NotEmpty().WithMessage("Product name is required");
        RuleFor(temp => temp.Category).IsInEnum().WithMessage("Category must be a valid enum value");
        RuleFor(temp => temp.UnitPrice)
            .InclusiveBetween(0, double.MaxValue).WithMessage($"Unit price must be between 0 and {double.MaxValue}");
        RuleFor(temp => temp.QuantityInStock)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity in stock must be greater than or equal to 0");
    }
}