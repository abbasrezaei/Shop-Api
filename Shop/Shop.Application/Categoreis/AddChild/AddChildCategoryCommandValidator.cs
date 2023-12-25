using FluentValidation;
using Common.Application.Validation;

namespace Shop.Application.Categoreis.AddChild
{
    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessage.required("Slug"));
        }
    }
}
