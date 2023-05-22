using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using static System.Net.Mime.MediaTypeNames;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Book_Sharing.Models;

namespace Book_Sharing.Data
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {/*
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(Options.SendGridKey, subject, message, toEmail);*/
            var MessaggioInviare = new MimeMessage();
            MessaggioInviare.From.Add(new MailboxAddress("Staff Book Sharing", "booksharing.contatta@gmail.com"));

            MessaggioInviare.To.Add(new MailboxAddress("", toEmail));
            MessaggioInviare.Subject = subject;

            MessaggioInviare.Body = new TextPart("html")
            {
                Text = message,
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("booksharing.register@gmail.com", "xvgaokdakdoqhtvj"/*Options.RegisterPsw*/);
                client.Send(MessaggioInviare);
                client.Disconnect(true);
            }
        }

        /*public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("booksharing.register@gmail.com"/*, "xvgaokdakdoqhtvj"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }*/
    }
}