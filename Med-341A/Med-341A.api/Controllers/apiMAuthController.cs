using Med_341A.api.Services;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMAuthController : ControllerBase
    {
        private readonly Med341aContext db;
        private readonly EmailService emailService;
        private VMResponse response = new VMResponse();

        public apiMAuthController(Med341aContext _db, EmailService _emailService)
        {
            this.db = _db;
            this.emailService = _emailService;
        }

        [HttpGet("CheckLogin/{email}/{password}")]
        public VMUser CheckLogin(string email, string password)
        {
            VMUser data = (from user in db.MUsers
                           join bio in db.MBiodata 
                           on user.BiodataId equals bio.Id
                           into biouser from bio in biouser.DefaultIfEmpty()
                           where user.IsDelete == false && user.Email == email && user.Password == password
                           select new VMUser
                           {
                               Id = user.Id,
                               RoleId = user.RoleId,
                               Fullname = bio.Fullname,
                           }).FirstOrDefault()!;

            return data;
        }

        [HttpGet("CheckEmailIsValid/{email}")]
        public bool CheckEmailIsValid(string email)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email).FirstOrDefault()!;

            return data != null;
        }

        [HttpGet("CheckPasswordIsValid/{email}/{password}")]
        public bool CheckPasswordIsValid(string email, string password)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email && a.Password == password).FirstOrDefault()!;

            return data != null;
        }

        // API Register
		[HttpPost("Register")]
		public VMResponse Register(string email)
		{
			// Periksa apakah email sudah terdaftar
			var existingUser = db.MUsers.FirstOrDefault(u => u.Email == email && u.IsDelete == false);
			if (existingUser != null)
			{
				response.Success = false;
				response.Message = "Email already registered.";
				return response;
			}

			// Jika email belum terdaftar, generate OTP dan simpan di database
			var otp = GenerateOtp();
			var token = new TToken
			{
				Email = email,
				Token = otp,
				ExpiredOn = DateTime.Now.AddMinutes(10),
				IsExpired = false,
				CreatedOn = DateTime.Now,
				UsedFor = "Register"
			};
			db.TTokens.Add(token);
			db.SaveChanges();

			// Kirim OTP ke email pengguna
			emailService.SendOtpEmail(email, otp);

			response.Success = true;
			response.Message = "OTP sent to email. Please verify your email.";
			return response;
		}

		// Verify OTP
		[HttpPost("VerifyOtp")]
		public VMResponse VerifyOtp(string email, string otp)
		{
			var token = db.TTokens.Where(t => t.Email == email && t.IsExpired == false && t.UsedFor == "Register")
								  .OrderByDescending(t => t.CreatedOn)
								  .FirstOrDefault();

			if (token == null)
			{
				response.Success = false;
				response.Message = "OTP not found or expired.";
				return response;
			}

			if (token.ExpiredOn < DateTime.Now)
			{
				response.Success = false;
				response.Message = "OTP expired.";
				token.IsExpired = true;
				db.SaveChanges();
				return response;
			}

			if (token.Token != otp)
			{
				response.Success = false;
				response.Message = "Incorrect OTP.";
				return response;
			}

			// OTP is valid, mark as expired
			token.IsExpired = true;
			db.SaveChanges();

			response.Success = true;
			response.Message = "OTP verification successful. Proceed to set a new password.";
			return response;
		}

		// Resend OTP with a 3-minute cooldown
		//[HttpPost("ResendOtp")]
		//public VMResponse ResendOtp(string email)
		//{
		//	var lastToken = db.TTokens.Where(t => t.Email == email && t.IsExpired == false && t.UsedFor == "Email Verification")
		//							  .OrderByDescending(t => t.CreatedOn)
		//							  .FirstOrDefault();

		//	if (lastToken != null && lastToken.CreatedOn.AddMinutes(ResendCooldownInMinutes) > DateTime.Now)
		//	{
		//		response.Success = false;
		//		response.Message = $"Please wait for {ResendCooldownInMinutes} minutes before requesting a new OTP.";
		//		return response;
		//	}

		//	// Generate new OTP
		//	var newOtp = GenerateOtp(OtpLength);

		//	// Mark previous OTP as expired
		//	if (lastToken != null)
		//	{
		//		lastToken.IsExpired = true;
		//	}

		//	// Save new OTP
		//	TToken newToken = new TToken
		//	{
		//		Email = email,
		//		Token = newOtp,
		//		ExpiredOn = DateTime.Now.AddMinutes(OtpExpiryTimeInMinutes),
		//		IsExpired = false,
		//		UsedFor = "Email Verification",
		//		CreatedBy = 1,
		//		CreatedOn = DateTime.Now
		//	};
		//	db.TTokens.Add(newToken);
		//	db.SaveChanges();

		//	// Send new OTP to Email
		//	SendOtpEmail(email, newOtp);

		//	response.Success = true;
		//	response.Message = "New OTP has been sent.";
		//	return response;
		//}

		// Generate 6-digit OTP
		private string GenerateOtp()
		{
			var random = new Random();
			return random.Next(100000, 999999).ToString(); // Generate OTP 6 digit
		}
    }
}
