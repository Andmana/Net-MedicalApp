using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class DokterProfilController : Controller
    {
        private DokterProfilService dokterProfilService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public DokterProfilController(DokterProfilService dokterProfilService, IWebHostEnvironment webHostEnvironment)
        {
            this.dokterProfilService = dokterProfilService;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            int idUser = HttpContext.Session.GetInt32("IdUser") ?? 0;
            if (idUser != 0)
            {
                VMDoctor data = await dokterProfilService.GetDataDokter(idUser);
                string imagePath = HttpContext.Session.GetString("ImagePath") ?? "default-profile.png";

                // Mengisi ViewBag dengan nilai imagePath
                ViewBag.ImagePath = imagePath;
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
