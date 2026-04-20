using BookShop.Web.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace BookShop.Web.Services;

public class EmailSender<TUser>(IOptions<EmailSettings> emailSettingsOptions, ILogger<EmailSender<TUser>> logger) : IEmailSender<TUser>
    where TUser : class
{
    private readonly EmailSettings emailSettings = emailSettingsOptions.Value;

    private readonly SmtpClient smtpClient = new SmtpClient(emailSettingsOptions.Value.Host, emailSettingsOptions.Value.Port)
    {
        EnableSsl = true,
        Credentials = new System.Net.NetworkCredential(emailSettingsOptions.Value.Mail, emailSettingsOptions.Value.Password)
    };

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var from = new MailAddress(emailSettings.Mail, emailSettings.DisplayName, System.Text.Encoding.UTF8);
        var to = new MailAddress(email);

        var message = new MailMessage(from, to)
        {
            Body = htmlMessage,
            BodyEncoding = System.Text.Encoding.UTF8,
            IsBodyHtml = true,
            Subject = subject,
            SubjectEncoding = System.Text.Encoding.UTF8
        };

        await smtpClient.SendMailAsync(message);

        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation("Email sent to: {to}", to.Address);
    }

    public Task SendConfirmationLinkAsync(TUser user, string email, string confirmationLink)
    {
        return SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
    }

    public Task SendPasswordResetCodeAsync(TUser user, string email, string resetCode)
    {
        return SendEmailAsync(email, "Reset your password", $"Reset your password using the following code: {resetCode}");
    }

    public Task SendPasswordResetLinkAsync(TUser user, string email, string resetLink)
    {
        return SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
    }
}
