using FluentValidation;

namespace BookShop.Transfer.Dtos.Identity;

internal class LoginDataValidator : AbstractValidator<LoginData>
{
    public LoginDataValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
        RuleFor(x => x.Password).NotEmpty();
    }
}
