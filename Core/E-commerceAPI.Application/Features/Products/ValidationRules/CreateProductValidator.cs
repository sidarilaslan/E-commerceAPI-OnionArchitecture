using E_commerceAPI.Application.Features.Products.Commands.CreateProduct;
using FluentValidation;

namespace E_commerceAPI.Application.Features.Products.ValidationRules
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.StockQuantity).NotEmpty().GreaterThan(0);
            RuleFor(u => u.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(u => u.StockQuantity).NotEmpty().GreaterThan(0);
        }
    }
}
