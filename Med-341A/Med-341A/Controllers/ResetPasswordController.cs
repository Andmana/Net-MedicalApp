using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Med_341A.Controllers
{
    public class ResetPasswordController : Controller
    {
        public readonly ResetPasswordService resetPWService;
        public VMResponse response = new();

        private static VResetPassword resetPWData = new();


        public ResetPasswordController( ResetPasswordService resetPWService)
        {
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
            // Save email and usedFor as resetPWData Model
            resetPWData.Email = email;
            resetPWData.usedFor = "RESET_PW";

            //Return Email
            ViewBag.email = email;

            // Varify Email isRegistered and send OTP if registered
            response = await resetPWService.VerifyEmailnReqOTP(resetPWData);
            return Json(new { dataResponse = response });
        }


        // Form OTP
        public IActionResult InputOTP()
        {
            return PartialView();
        }

        // Request OTP Again
        [HttpPost]
        public async Task<JsonResult> ReRequestOTP()
        {
            // Send OTP again using saved ResetPWModel
            response = await resetPWService.VerifyEmailnReqOTP(resetPWData);
            return Json(new { dataResponse = response });
        }

        // Veerify OTP
        [HttpPost]
        public async Task<JsonResult> VerifyOTP(VResetPassword dataForm)
        {
            // Cerify OTP
            resetPWData.OTP = dataForm.OTP;
            response = await resetPWService.VerifyOTP(resetPWData);

            return Json(new { dataResponse = response });
        }

        // Form Password
        public IActionResult InputPassword()
        {
            return PartialView();
        }

        // Save new Password
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
