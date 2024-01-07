using E_commerceAPI.Application.Features.Products.Commands.UpdateProduct;
using FluentValidation;

namespace E_commerceAPI.Application.Features.Products.ValidationRules
{
    public class StockUpdateProductValidator : AbstractValidator<StockUpdateProductCommand>
    {
        public StockUpdateProductValidator()
        {
            RuleFor(u => u.StockQuantity).NotEmpty().GreaterThan(0);
        }
    }
}
