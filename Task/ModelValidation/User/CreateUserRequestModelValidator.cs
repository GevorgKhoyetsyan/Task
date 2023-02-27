using FluentValidation;
using Task.Models.User;

namespace Task.ModelValidation.User
{
    public class CreateUserRequestModelValidator : AbstractValidator<CreateUserRequestModel>
    {
        public CreateUserRequestModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64);

            RuleFor(p => p.Age)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64).EmailAddress();
        }
    }
}
