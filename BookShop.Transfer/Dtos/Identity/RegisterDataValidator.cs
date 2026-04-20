using FluentValidation;

namespace BookShop.Transfer.Dtos.Identity;

internal class RegisterDataValidator : AbstractValidator<RegisterData>
{
    public RegisterDataValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.PasswordAgain).NotEmpty().Equal(x => x.Password);

        RuleFor(x => x.DisplayName).NotEmpty();
    }
}
