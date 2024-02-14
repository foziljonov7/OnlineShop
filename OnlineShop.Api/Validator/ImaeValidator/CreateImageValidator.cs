using FluentValidation;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;

namespace OnlineShop.Api.Validator.ImaeValidator
{
    public class CreateImageValidator : AbstractValidator<CreateImageDto>
    {
        public CreateImageValidator(AppDbContext dbContext)
        {
            RuleFor(dto => dto.FileName)
                .NotEmpty().WithMessage("FileName should not be empty");

            RuleFor(dto => dto.FilePath)
                .NotEmpty().WithMessage("FilePath should not be empty");

            RuleFor(dto => dto.ProductId)
                .NotNull().WithMessage("ProductId cann't be null");
        }
    }
}
