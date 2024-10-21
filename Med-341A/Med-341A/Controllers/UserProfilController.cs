using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        //public string Upload(IFormFile ImageFile)
        //{

        //    string uniqueFileName = "";
        //    if (ImageFile != null && ImageFile.Length > 0)
        //    {
        //        string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images"); //Path folder untuk tempat gambar
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImageFile.FileName);
        //        string filePath = Path.Combine(uploadFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            ImageFile.CopyTo(fileStream);
        //        };
        //    }
        //    return uniqueFileName;
        //}
        public byte[] Upload(IFormFile ImageFile)
        {
            byte[] imageData = null;
            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    ImageFile.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }
            }
            return imageData;
        }
        public async Task<IActionResult> UbahGambar(int id)
        {
            VMUploadGambar data = await userProfileService.GetDataGambar(id);
            return PartialView(data);

        }
        [HttpPost]
        public async Task<JsonResult> UbahGambar(VMUploadGambar dataParam)
        {
            if(dataParam.ImageFile != null)
            {
                dataParam.Image = Upload(dataParam.ImageFile);
            }
            
            VMResponse respon = await userProfileService.UbahGambar(dataParam);
            HttpContext.Session.SetString("ImagePath", dataParam.ImagePath);
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
    }
}
