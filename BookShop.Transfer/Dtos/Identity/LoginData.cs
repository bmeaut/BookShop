namespace BookShop.Transfer.Dtos.Identity;

public class LoginData
{
    public required string Email { get; set; }

    public required string Password { get; set; }

    public string? TwoFactorCode { get; set; }

    public string? TwoFactorRecoveryCode { get; set; }
}
