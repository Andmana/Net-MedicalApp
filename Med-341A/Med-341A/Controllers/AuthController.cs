using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                HttpContext.Session.SetString("Email", user.Email ?? "");
                HttpContext.Session.SetString("NameRole", user.NameRole ?? "");
                HttpContext.Session.SetInt32("IdRole", (Int32)(user.RoleId ?? 0));
                HttpContext.Session.SetString("ImagePath", user.ImagePath ?? "");
            }

            return Json(new { dataResponse = response });
        }

        [HttpPost]
        public async Task<JsonResult> LoginSubmitV2(string email, string password)
        {
            response = await authService.CheckLoginV2(email, password);

            if (response.Entity != null)
            {
                VMUser? user = JsonConvert.DeserializeObject<VMUser>(response.Entity.ToString() ?? string.Empty);

                if (user != null)
                {
                    response.Message = $"Hello, {user.Fullname} Welcome to Med 341";

                    // Store user information in session
                    HttpContext.Session.SetInt32("IdUser", (int)user.Id);
                    HttpContext.Session.SetString("NameUser", user.Fullname ?? "");
                    HttpContext.Session.SetString("Email", user.Email ?? "");
                    HttpContext.Session.SetString("NameRole", user.NameRole ?? "");
                    HttpContext.Session.SetInt32("IdRole", (int)(user.RoleId ?? 0));
                    HttpContext.Session.SetString("ImagePath", user.ImagePath ?? "default-profile.png");
                }
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

        [HttpPost]
        public async Task<JsonResult> CheckPasswordIsValidV2(string email, string password)
        {
            var data = await authService.CheckPasswordIsValidV2(email, password);

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
