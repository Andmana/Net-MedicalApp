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
        private VMResponse response = new VMResponse();

        public apiTResetPasswordController(Med341aContext _db, EmailService _emailService, AuthService _authService)
        {
            this.db = _db;
            this.emailService = _emailService;
            this.authService = _authService;
        }

        [HttpPost("RequestOTP")]
        public VMResponse RequestOTP(VResetPassword request)
        {
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
                    UsedFor = request.usedFor
                };
                db.TTokens.Add(token);
                db.SaveChanges();
                
                emailService.SendOtpEmail(request.Email, request.OTP);


                response.Entity = request;
                response.Success = true;
                response.Message = "OTP sent to email. Please verify your email.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to generate OTP " + ex.Message;
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
        public VMResponse SaveNewPassword(VResetPassword request)
        {
            MUser data = db.MUsers.Where(a => a.IsDelete == false && a.Email == request.Email).FirstOrDefault();
            if (data == null)
            {
                response.Success=false;
                response.Message = "Akun tidak ditemukan";
            }
            else
            {
                TResetPassword resetPW = new TResetPassword();

                resetPW.OldPassword = data.Password;
                resetPW.NewPassword = request.Password;
                resetPW.CreatedBy = data.Id;
                resetPW.CreatedOn = DateTime.Now;
                resetPW.ResetFor = request.usedFor;

                try
                {
                    data.Password = request.Password;

                    db.Add(resetPW);
                    db.Update(data);

                    db.SaveChanges();

                } catch (Exception ex) {
                    response.Success = false;
                    response.Message = "Reset kata sandi gagal : " + ex.Message;
                }
                response.Success = true;
                response.Message = "Reset kata sandi berhasil.";

            }
            return response;
        }

    }
}
