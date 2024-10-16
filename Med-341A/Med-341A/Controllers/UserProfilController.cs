using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class UserProfilController : Controller
    {
        private UserProfileService userProfileService;

        public UserProfilController(UserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        public async Task<IActionResult> Index()
        {
            VMUser data = await userProfileService.GetDataUser(1); //HardCore
            return View(data);
        }
    }
}
