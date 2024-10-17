using Azure;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class AuthController : Controller
    {

        private readonly AuthService authService;
        private VMResponse response = new();

        public AuthController(AuthService _authService)
        {
            this.authService = _authService;
        }

        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> LoginSubmit(string email, string password)
        {
            VMUser user = await authService.CheckLogin(email, password);

            if (user != null)
            {
                response.Message = $"Hello, {user.Fullname} Welcome to Med 341";
                HttpContext.Session.SetInt32("IdUser", (Int32)user.Id);
                HttpContext.Session.SetString("NameUser", user.Fullname ?? "");
                HttpContext.Session.SetInt32("IdRole", (Int32)(user.RoleId ?? 0));
            }
            else
            {
                response.Success = false;
                response.Message = $"Oops, {email} not found or password is wrong, please check it";
            }

            return Json(new { dataResponse = response });
        }

        [HttpGet]
        public async Task<JsonResult> CheckEmailIsRegistered(string email)
        {
            var data = await authService.CheckEmailIsRegistered(email);

            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> CheckPasswordIsValid(string email, string password)
        {
            var data = await authService.CheckPasswordIsValid(email, password);

            return Json(data);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
