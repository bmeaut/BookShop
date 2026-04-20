using BookShop.Web.RazorPage.Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace BookShop.Web.RazorPage.Services;

public class EmailSender(IOptions<EmailSettings> emailSettingsOptions, ILogger<EmailSender> logger) : IEmailSender
{
    private readonly EmailSettings emailSettings = emailSettingsOptions.Value;

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SmtpClient(emailSettings.Host, emailSettings.Port)
        {
            EnableSsl = true,
            Credentials = new System.Net.NetworkCredential(emailSettings.Mail, emailSettings.Password)
        };

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

        await client.SendMailAsync(message);

        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation("Email sent to: {to}", to.Address);
    }
}
