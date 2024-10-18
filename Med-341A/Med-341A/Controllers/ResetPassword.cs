using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class ResetPassword : Controller
    {
        public readonly AuthService authService;
        public VMResponse response = new();

        public ResetPassword(AuthService _authService)
        {
            authService = _authService;
        }
        public IActionResult EmailVerification()
        {
            return PartialView();
        }
    }
}
