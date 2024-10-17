using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class AuthResetPWController : Controller
    {
        private readonly AuthService authService;
        private VMResponse response = new();

        public AuthResetPWController(AuthService authService)
        {
            this.authService = authService;
        }

        // Email Form
        public IActionResult InputEmail()
        {
            return PartialView();
        }

        public IActionResult InputOTP()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<JsonResult> CheckEmailIsRegistered(string email)
        {
            var data = await authService.CheckEmailIsRegistered(email);
            if (data)
            {
                HttpContext.Session.SetString("email", email);
            }

            return Json(data);
        }

    }
}
