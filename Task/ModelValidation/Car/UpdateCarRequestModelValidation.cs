using FluentValidation;
using Task.Models.Car;

namespace Task.ModelValidation.Car
{
    public class UpdateCarRequestModelValidation : AbstractValidator<UpdateCarRequestModel>
    {
        public UpdateCarRequestModelValidation()
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
