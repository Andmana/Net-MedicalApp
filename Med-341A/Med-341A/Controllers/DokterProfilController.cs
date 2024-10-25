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
        public async Task<IActionResult> UbahGambar(int id)
        {
            VMUploadGambar data = await dokterProfilService.GetDataGambar(id);
            return PartialView(data);
        }

        public async Task<string> Upload(IFormFile imageFile)
        {
            string uniqueFileName = "";

            if (imageFile != null)
            {
                // Buat path untuk menyimpan file di wwwroot/images
                var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                // Pastikan folder 'images' ada, jika tidak, buat foldernya
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Ambil ekstensi file (misal: .jpg, .png)
                //var extension = Path.GetExtension(imageFile.FileName);

                // Buat nama file unik menggunakan waktu dan kode mesin
                //uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmss}_{Environment.MachineName}";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                // Gabungkan folder path dan nama file unik
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Simpan file ke folder wwwroot/images
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpPost]
        public async Task<JsonResult> UbahGambar(VMUploadGambar dataParam)
        {
            if (dataParam.ImageFile != null)
            {
                dataParam.ImagePath = await Upload(dataParam.ImageFile);
            }

            VMResponse respon = await dokterProfilService.UbahGambar(dataParam);
            HttpContext.Session.SetString("ImagePath", dataParam.ImagePath!);
            return Json(new { dataRespon = respon });

        }
    }
}
