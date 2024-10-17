using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

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
            int idUser = HttpContext.Session.GetInt32("IdUser") ?? 0;
            VMUser data = await userProfileService.GetDataUser(idUser);
            return View(data);
        }
    }
}
