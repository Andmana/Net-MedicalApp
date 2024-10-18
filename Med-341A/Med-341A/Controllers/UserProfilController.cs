using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
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
            if (idUser != 0)
            {
                VMUser data = await userProfileService.GetDataUser(idUser);
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> UbahPribadi(int id)
        {
            VMUser data = await userProfileService.GetDataUser(id);
            return PartialView(data);
        }
        [HttpPost]
        public async Task<JsonResult> UbahPribadi(VMUser dataParam)
        {
            VMResponse respon = await userProfileService.UbahPribadi(dataParam);

            return Json(new { dataRespon = respon });
        }
        public async Task<IActionResult> UbahPassword(int id)
        {
            VMUser data = await userProfileService.GetDataUser(id);
            return PartialView(data);
        }

        public async Task<JsonResult> CheckPassword(string email, string password)
        {
            bool isExist = await userProfileService.CheckPassword(email, password);
            return Json(isExist);
        }

        public async Task<IActionResult> UbahPasswordBaru(int id)
        {
            VMUser data = await userProfileService.GetDataUser(id);
            return PartialView(data);
        }
    }
}
