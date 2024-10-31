using Azure;
using Azure.Core;
using Med_341A.api.Services;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static System.Net.WebRequestMethods;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiTResetPasswordController : ControllerBase
    {
        private readonly Med341aContext db;
        private readonly EmailService emailService;
        private readonly AuthService authService;
        private readonly ResetPasswordService resetPasswordService;
        private VMResponse response = new VMResponse();

        public apiTResetPasswordController(Med341aContext _db, EmailService _emailService, 
                                            AuthService _authService, ResetPasswordService _resetPasswordService)
        {
            this.db = _db;
            this.emailService = _emailService;
            this.authService = _authService;
            this.resetPasswordService = _resetPasswordService;
        }

        [HttpPost("VerifyEmail_nRequestOTP")]
        public VMResponse VerifyEmail_nRequestOTP(VResetPassword request)
        {
            MUser data = db.MUsers.Where(a => a.IsDelete == false 
                                           && a.Email == request.Email).FirstOrDefault()!;
            if (data == null)
            {
                response.Success = false;
                response.Message = "Email tidak terdaftar";

                return response;
            }

            request.OTP = emailService.GenerateOtp();
            try
            {
                var token = new TToken
                {
                    Email = request.Email,
                    Token = request.OTP,
                    ExpiredOn = DateTime.Now.AddMinutes(10),
                    IsExpired = false,
                    CreatedOn = DateTime.Now,
                    UsedFor = request.usedFor,
                    UserId = data.Id
                };
                db.TTokens.Add(token);
                db.SaveChanges();

                var isSent = emailService.SendOtpEmailV2(request.Email, request.OTP);
                if (isSent)
                {
                    response.Entity = request;
                    response.Success = true;
                    response.Message = "OTP berhasil dikirim ke Email";

                    return response;
                }

                response.Success = false;
                response.Message = "OTP Gagal dikirim ke Email, Silakan coba setelah beberapa saat";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Gagal mengirim OTP " + ex.Message;
            }
            return response;
        }


        [HttpPost("VerifyOTP")]
        public VMResponse VerifyOTP(VResetPassword request)
        {
            var token = db.TTokens.Where(t => t.Email == request.Email && t.IsExpired == false && t.UsedFor == request.usedFor)
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

            if (token.Token != request.OTP)
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

        [HttpPost("SaveNewPassword")]
        public async Task<VMResponse> SaveNewPassword(VResetPassword request)
        {
            MUser data = db.MUsers.Where(a => a.IsDelete == false && a.Email == request.Email).FirstOrDefault();
            if (data == null)
            {
                response.Success=false;
                response.Message = "Akun tidak ditemukan";

                return response;
            }
            else
            {
                if (authService.VerifyPassword(data.Password, request.Password))
                {
                    response.Success = false;
                    response.Message = "Password tidak boleh sama dengan password saat ini";
                    return response;
                }

                if (await resetPasswordService.IsEqual_PrevPass(data.Id, request.Password))
                {
                    response.Success = false;
                    response.Message = "Password sudah pernah digunakan sebelumnya";
                    return response;
                }
                

                try
                {
                    string newPassHash = authService.HashPassword(request.Password);
                    string oldPass = data.Password;
                    
                    // Add new record 
                    TResetPassword resetPW = new TResetPassword();
                    resetPW.OldPassword = oldPass;
                    resetPW.NewPassword = newPassHash;
                    resetPW.CreatedBy = data.Id;
                    resetPW.CreatedOn = DateTime.Now;
                    resetPW.ResetFor = request.usedFor;
                    db.Add(resetPW);


                    // Set new Password
                    data.Password = newPassHash;
                    data.ModifiedBy = data.Id;
                    data.ModifiedOn = DateTime.Now;
                    db.Update(data);

                    db.SaveChanges();

                } catch (Exception ex) {
                    response.Success = false;
                    response.Message = "Reset kata sandi gagal : " + ex.Message;
                }
                response.Success = true;
                response.Message = "Reset kata sandi berhasil.";

                return response;

            }

        }
        

    }
}
