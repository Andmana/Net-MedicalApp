using Azure;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using NuGet.Protocol;
using System.Drawing.Text;
using System.Net;

namespace Med_341A.Controllers
{
    public class UserProfilController : Controller
    {
        private UserProfileService userProfileService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public UserProfilController(UserProfileService userProfileService, IWebHostEnvironment webHostEnvironment)
        {
            this.userProfileService = userProfileService;
            this.webHostEnvironment = webHostEnvironment;
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

        public async Task<IActionResult> UbahGambar(int id)
        {
            VMUploadGambar data = await userProfileService.GetDataGambar(id);
            return PartialView(data);

        }
        [HttpPost]
        public async Task<JsonResult> UbahGambar(VMUploadGambar dataParam)
        {
            if (dataParam.ImageFile != null)
            {
                dataParam.ImagePath = await Upload(dataParam.ImageFile);
            }

            VMResponse respon = await userProfileService.UbahGambar(dataParam);
            HttpContext.Session.SetString("ImagePath", dataParam.ImagePath!);
            return Json(new { dataRespon = respon });

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
        [HttpPost]
        public async Task<JsonResult> UpdatePassword(VMUser data)
        {
            VMResponse respon = await userProfileService.UpdatePassword(data);
            if (respon.Success)
            {
                HttpContext.Session.Clear();
            }
            return Json(new { dataRespon = respon });
        }
        public async Task<IActionResult> UbahEmail(int id)
        {
            VMUser data = await userProfileService.GetDataUser(id);
            return PartialView(data);
        }
 
        public async Task<JsonResult> CheckEmailIsExist(string email)
        {
            bool isExist = await userProfileService.CheckEmail(email);
            return Json(isExist);
        }
        [HttpPost]
        public async Task<IActionResult> ValidasiOTP(string email, int id)
        {
            VMResponse respon = await userProfileService.RequestOTPEmailBaru(email, id);
            ViewBag.Email = email;
            ViewBag.Id = id;
            return PartialView(respon);
        }
        [HttpPost]
        public async Task<JsonResult> UlangRequestOTP(string email, int id)
        {
            VMResponse respon = await userProfileService.RequestOTPEmailBaru(email, id);
            return Json(new { dataResponse = respon });
        }
        [HttpPost]
        public async Task<JsonResult> VerifikasiOTP (string email, string otp, int id)
        {
            VMResponse respon = await userProfileService.VerifikasiOTP(email, otp, id);

            if (respon.Success)
            {
                HttpContext.Session.Clear();
            }

            return Json(new { dataResponse = respon });
        }
    }
}
