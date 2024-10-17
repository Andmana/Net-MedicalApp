using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Med_341A.api.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendOtpEmail(string email, string otp)
        {
            try
            {
                // Mengambil konfigurasi SMTP dari appsettings.json
                var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
                {
                    Port = int.Parse(_configuration["Smtp:Port"]),
                    Credentials = new NetworkCredential(_configuration["Smtp:SenderEmail"], _configuration["Smtp:Password"]),
                    EnableSsl = bool.Parse(_configuration["Smtp:EnableSsl"])
                };

                // Membuat isi email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Smtp:SenderEmail"]),
                    Subject = "Your OTP Code",
                    Body = $"Your OTP code is: {otp}\nIt will expire in 10 minutes.",
                    IsBodyHtml = false,
                };

                // Menambahkan email tujuan
                mailMessage.To.Add(email);

                // Mengirimkan email
                smtpClient.Send(mailMessage);
                Console.WriteLine($"OTP {otp} has been sent to {email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}