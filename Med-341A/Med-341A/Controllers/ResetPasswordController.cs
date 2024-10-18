using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Med_341A.Controllers
{
    public class ResetPasswordController : Controller
    {
        public readonly AuthService authService;
        public readonly ResetPasswordService resetPWService;
        public VMResponse response = new();

        private static string _otp;
        private static string _email;
        private static VResetPassword resetPWData = new();


        public ResetPasswordController(AuthService _authService, ResetPasswordService resetPWService)
        {
            authService = _authService;
            this.resetPWService = resetPWService;
        }

        // Form email 
        public IActionResult InputEmail()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> CheckAccountEmail(string email)
        {
            var data = await authService.CheckEmailIsRegistered(email);
            if (!data)
            {
                response.Success = false;
                response.Message = "Email tidak terdaftar";
            }
            else
            {
                resetPWData.Email = email;
                resetPWData.usedFor = "RESET_PW";
                response = await resetPWService.RequestOTP(resetPWData);
            }
            return Json(new { dataResponse = response });
        }


        // Form OTP
        public IActionResult InputOTP()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> VerifyOTP(VResetPassword dataForm)
        {
            resetPWData.OTP = dataForm.OTP;
            response = await resetPWService.VerifyOTP(resetPWData);

            return Json(new { dataResponse = response });
        }

        public IActionResult InputPassword()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> SavePassword(VResetPassword dataForm)
        {
            resetPWData.Password= dataForm.Password;
            resetPWData.ConfirmPassword = dataForm.ConfirmPassword;

            VMResponse response = await resetPWService.SavePassword(resetPWData);

            
            return Json(new { dataResponse = response });

        }

        

    }
}
