using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService authService;
        private VMResponse response = new();
        private UserProfileService userProfilService;

        public AuthController(AuthService _authService, UserProfileService _userProfileService)
        {
            this.authService = _authService;
            this.userProfilService = _userProfileService;
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
            }
            else
            {
                response.Success = false;
                response.Message = $"Oops, password is wrong, please enter valid password";
            }

            return Json(new { dataResponse = response });
        }

        [HttpPost]
        public async Task<JsonResult> LoginSubmitV2(string email, string password)
        {
            VMUser user = await authService.CheckLoginV2(email, password);
            VMUser imagePath = await userProfilService.GetDataUser((Int32)user.Id);
            if (user != null)
            {
                response.Message = $"Hello, {user.Fullname} Welcome to Med 341";
                HttpContext.Session.SetInt32("IdUser", (Int32)user.Id);
                HttpContext.Session.SetString("NameUser", user.Fullname ?? "");
                HttpContext.Session.SetString("Email", user.Email ?? "");
                HttpContext.Session.SetString("NameRole", user.NameRole ?? "");
                HttpContext.Session.SetInt32("IdRole", (Int32)(user.RoleId ?? 0));
                HttpContext.Session.SetString("ImagePath", imagePath.ImagePath);
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
