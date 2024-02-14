using FluentValidation;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ProductDtos;

namespace OnlineShop.Api.Validator.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Name should not be empty")
                .MinimumLength(2).MaximumLength(50);

            RuleFor(dto => dto.Description)
                .MaximumLength(256).WithMessage("Description maximal 256 characters");

            RuleFor(dto => dto.Price)
                .NotNull().WithMessage("Price cann't be null");

            RuleFor(dto => dto.Quantity)
                .NotNull().WithMessage("Quantity cann't be null");

            RuleFor(dto => dto.CategoryId)
                .NotNull().WithMessage("CategoryId cann't be null");
        }
    }
}
