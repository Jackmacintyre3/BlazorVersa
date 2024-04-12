using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string html);
}

public class EmailService : IEmailService
{
    private readonly string host = "smtp.office365.com";
    private readonly int port = 587;
    private readonly string username = "VersaNet1@outlook.com";
    private readonly string password = "IneARpho&4226";

    public async Task SendEmailAsync(string to, string subject, string html)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("VersaNet", "VersaNet1@outlook.com"));
        email.To.Add(new MailboxAddress("", to));
        email.Subject = subject;

        var builder = new BodyBuilder { HtmlBody = html };
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        try
        {
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(username, password);
            await smtp.SendAsync(email);
        }
        catch (SmtpCommandException ex)
        {
            Console.WriteLine($"SMTP Command Error: {ex.StatusCode} - {ex.Message}");
            throw; 
        }
        catch (SmtpProtocolException ex)
        {
            Console.WriteLine($"SMTP Protocol Error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            throw;
        }
        finally
        {
            smtp.Disconnect(true);
        }
    }
}
