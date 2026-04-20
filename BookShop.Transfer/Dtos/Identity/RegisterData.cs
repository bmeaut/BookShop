namespace BookShop.Transfer.Dtos.Identity;

public class RegisterData
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordAgain { get; set; } = null!;

    // Must be empty string (not null in DB)
    public string DisplayName { get; set; } = string.Empty;
}
