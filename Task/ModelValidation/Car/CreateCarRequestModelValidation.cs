using FluentValidation;
using Task.Models.Car;
using Task.Models.User;

namespace Task.ModelValidation.Car
{
    public class CreateCarRequestModelValidation : AbstractValidator<CreateCarRequestModel>
    {
        public CreateCarRequestModelValidation() //Constructor for Model Validation
        {
            RuleFor(x => x.UserId)
              .NotEmpty()
              .NotNull()
              .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64);

            RuleFor(p => p.Price)
                    .NotEmpty()
                    .NotNull();
        }
    }
}
