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
        private readonly AuthService authService;
        private VMResponse response = new VMResponse();

        public apiMAuthController(Med341aContext _db, EmailService _emailService, AuthService _authService)
        {
            this.db = _db;
            this.emailService = _emailService;
            this.authService = _authService;
        }

        [HttpGet("CheckLogin/{email}/{password}")]
        public VMUser CheckLogin(string email, string password)
        {
            VMUser data = (from user in db.MUsers
                           join bio in db.MBiodata
                           on user.BiodataId equals bio.Id
                           into biouser
                           from bio in biouser.DefaultIfEmpty()
                           where user.IsDelete == false && user.Email == email && user.Password == password
                           select new VMUser
                           {
                               Id = user.Id,
                               RoleId = user.RoleId,
                               Fullname = bio.Fullname,
                           }).FirstOrDefault()!;

            return data;
        }

        [HttpGet("CheckEmailIsRegistered/{email}")]
        public bool CheckEmailIsRegistered(string email)
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
        [HttpPost("RequestOTP")]
        public VMResponse RequestOTP(OTPValidationRequestBody request)
        {
            var otp = emailService.GenerateOtp();
            var token = new TToken
            {
                Email = request.Email,
                Token = otp,
                ExpiredOn = DateTime.Now.AddMinutes(10),
                IsExpired = false,
                CreatedOn = DateTime.Now,
                UsedFor = "Register"
            };
            db.TTokens.Add(token);
            db.SaveChanges();

            // Kirim OTP ke email pengguna
            emailService.SendOtpEmail(request.Email, otp);

            response.Success = true;
            response.Message = "OTP sent to email. Please verify your email.";
            return response;
        }

        // Verify OTP
        [HttpPost("VerifyOTP")]
        public VMResponse VerifyOTP(OTPValidationRequestBody request)
        {
            var token = db.TTokens.Where(t => t.Email == request.Email && t.IsExpired == false && t.UsedFor == "Register")
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

            if (token.Token != request.Otp)
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


        // Temporary Create New
        [HttpPost("RegisterNewUser")]
        public VMResponse RegisterNewUser(VMUser dataUserProfile)
        {

            try
            {
                // Create biodata data first
                MBiodatum biodata = new();

                // manual mapping ke entity biodata
                biodata.Fullname = dataUserProfile.Fullname;
                biodata.MobilePhone = dataUserProfile.MobilePhone;
                biodata.CreatedOn = DateTime.Now;

                // add to db
                db.Add(biodata);

                string hashedPassword = authService.HashPassword(dataUserProfile.Password);

                MUser user = new();
                // manual mapping ke entity user
                user.BiodataId = biodata.Id;
                user.Email = dataUserProfile.Email;
                user.Password = hashedPassword;
                user.RoleId = dataUserProfile.RoleId;
                user.CreatedOn = DateTime.Now;

                // add to db
                db.Add(user);

                // save changes
                db.SaveChanges();

                response.Message = "Berhasil Register";
            }
            catch (Exception ex)
            {

                response.Message = "Register tidak berhasil " + ex.Message;
                response.Success = false;
            }

            return response;
        }
    }

    public class OTPValidationRequestBody
    {
        public string Email { get; set; }
        public string? Otp { get; set; }
    }
}
