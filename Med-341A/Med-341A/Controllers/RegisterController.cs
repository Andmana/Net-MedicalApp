using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult EmailVerification()
        {
            return PartialView();
        }
    }
}
