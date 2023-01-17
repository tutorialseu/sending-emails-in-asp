using System.Net;
using System.Net.Mail;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.office365.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("mohsen.bazmi@live.com", "pass")
        };

        return client.SendMailAsync(
            new MailMessage(from: "mohsen.bazmi@live.com",
                            to: email,
                            subject,
                            message
                            ));
    }
}

