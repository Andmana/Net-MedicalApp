using System.Net.Mail;
using System.Net;

namespace Med_341A.api.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        private string smtpHost;
        private int smtpPort;
        private string senderEmail = "";
        private string emailAppPassword = "";
        private bool enableSSl;


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            this.smtpHost = _configuration["Smtp:Host"]!;
            this.smtpPort = int.Parse(_configuration["Smtp:Port"]!);
            this.senderEmail = _configuration["Smtp:senderEmail"]!;
            this.emailAppPassword = _configuration["Smtp:Password"]!;
            this.enableSSl = bool.Parse(_configuration["Smtp:EnableSsl"] ?? "false");
        }

        public void SendOtpEmail(string email, string otp)
        {
            try
            {
                // Mengambil konfigurasi SMTP dari appsettings.json
                SmtpClient smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, emailAppPassword),
                    EnableSsl = enableSSl
                };

                // Membuat isi email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = "Your OTP Code",
                    Body = $"Your OTP code is: {otp}\nIt will expire in 10 minutes.",
                    IsBodyHtml = false,
                };

                // Menambahkan email tujuan
                mailMessage.To.Add(email);

                // Mengirimkan email
                smtpClient.Send(mailMessage);
                Console.WriteLine($"OTP has been sent to your emai {email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

        public bool SendOtpEmailV2(string email, string otp)
        {
            try
            {
                // Mengambil konfigurasi SMTP dari appsettings.json
                SmtpClient smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, emailAppPassword),
                    EnableSsl = enableSSl
                };

                // Membuat isi email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = "Your OTP Code",
                    Body = $"Your OTP code is: {otp}\nIt will expire in 10 minutes.",
                    IsBodyHtml = false,
                };

                // Menambahkan email tujuan
                mailMessage.To.Add(email);

                // Mengirimkan email
                smtpClient.Send(mailMessage);
                Console.WriteLine($"OTP has been sent to your emai {email}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;

            }
        }

        // Generate 6-digit OTP
        public string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Generate OTP 6 digit
        }
    }
}