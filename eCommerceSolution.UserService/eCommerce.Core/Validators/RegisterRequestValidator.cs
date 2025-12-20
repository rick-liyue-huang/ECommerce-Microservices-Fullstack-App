using eCommerce.Core.Dtos;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
{
    
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("Person name is required.");
        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Gender must be either Male or Female or Other.");
    }
}