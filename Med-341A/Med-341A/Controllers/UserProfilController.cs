using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Med_341A.Controllers
{
    public class UserProfilController : Controller
    {
        private UserProfileService userProfileService;
        private PasienService pasienService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public UserProfilController(UserProfileService userProfileService, PasienService pasienService, IWebHostEnvironment webHostEnvironment)
        {
            this.pasienService = pasienService;
            this.userProfileService = userProfileService;
            this.webHostEnvironment = webHostEnvironment;
        }

        private int GetUserIdFromSession()
        {
            return HttpContext.Session.GetInt32("IdUser") ?? 0;
        }

        public async Task<IActionResult> Index()
        {
            int idUser = GetUserIdFromSession();
            if (idUser != 0)
            {
                VMUser data = await userProfileService.GetDataUser(idUser);
                string imagePath = HttpContext.Session.GetString("ImagePath") ?? "default-profile.png";

                // Mengisi ViewBag dengan nilai imagePath
                ViewBag.MainContent = HttpContext.Session.GetString("MainContent") ?? "EditProfil";
                ViewBag.ImagePath = imagePath;
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
            if (respon.Success)
            {
                HttpContext.Session.SetString("NameUser", dataParam.Fullname);
            }
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
        public async Task<JsonResult> VerifikasiOTP(string email, string otp, int id)
        {
            VMResponse respon = await userProfileService.VerifikasiOTP(email, otp, id);

            if (respon.Success)
            {
                HttpContext.Session.Clear();
            }

            return Json(new { dataResponse = respon });
        }
        public async Task<IActionResult> LoadPasien(string sortOrder,
                                                    string searchString,
                                                    string currentFilter,
                                                    int? pageNumber,
                                                    int? pageSize)
        {
            int idUser = GetUserIdFromSession();
            if (idUser != 0)
            {
                // Mengisi ViewBag dengan nilai imagePath
                ViewBag.MainContent = "Pasien";
                ViewBag.currentSort = sortOrder;
                ViewBag.currentPageSize = pageSize ?? 3;
                ViewBag.nameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.ageSort = sortOrder == "age_asc" ? "age_asc" : "age_desc";
                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                ViewBag.currentFilter = searchString;

                List<VMPasien> data = await pasienService.GetAllData(idUser);

                if (!string.IsNullOrEmpty(searchString))
                {
                    data = data.Where(a => a.Fullname.ToLower().Contains(searchString.ToLower()) || a.NameRelation.ToLower().Contains(searchString.ToLower())).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        data = data.OrderByDescending(a => a.Fullname).ToList();
                        break;
                    case "age_desc":
                        data = data.OrderByDescending(a => a.Dob).ToList();
                        break;
                    case "age_asc":
                        data = data.OrderBy(a => a.Dob).ToList();
                        break;
                    default:
                        data = data.OrderBy(a => a.Fullname).ToList();
                        break;
                }
                return PartialView("_Pasien", VPaginatedList<VMPasien>.CreateAsync(data, pageNumber ?? 1, pageSize ?? 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public async Task<IActionResult> LoadEditProfil()
        {
            int idUser = GetUserIdFromSession();
            if (idUser != 0)
            {
                VMUser data = await userProfileService.GetDataUser(idUser);
                string imagePath = HttpContext.Session.GetString("ImagePath") ?? "default-profile.png";

                // Mengisi ViewBag dengan nilai imagePath
                ViewBag.MainContent = "EditProfil";
                ViewBag.ImagePath = imagePath;
                return PartialView("_EditProfil", data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult LoadPembelianObat()
        {
            int idUser = GetUserIdFromSession();
            if (idUser != 0)
            {

                // Mengisi ViewBag dengan nilai imagePath
                ViewBag.MainContent = "PembelianObat";
                return PartialView("_PembelianObat");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LoadRencana()
        {
            int idUser = GetUserIdFromSession();
            if (idUser != 0)
            {
                ViewBag.MainContent = "Rencana";
                return PartialView("_Rencana");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LoadRiwayatChat()
        {
            int idUser = GetUserIdFromSession();
            if (idUser != 0)
            {
                ViewBag.MainContent = "RiwayatChat";
                return PartialView("_RiwayatChat");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> TambahPasien()
        {
            VMPasien data = new VMPasien();
            ViewBag.ListRelasi = await pasienService.GetAllRelasi();
            ViewBag.ListGoldar = await pasienService.GetAllGoldar();
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> TambahPasien(VMPasien dataForm)
        {
            VMResponse respon = await pasienService.TambahPasien(dataForm);

            return Json(new { dataRespon = respon });
        }
        //Berdasarkan id customer member
        public async Task<IActionResult> EditPasien(int id)
        {
            VMPasien data = await pasienService.GetPasienByIdCustomer(id);
            ViewBag.ListRelasi = await pasienService.GetAllRelasi();
            ViewBag.ListGoldar = await pasienService.GetAllGoldar();
            ViewBag.IdUser = GetUserIdFromSession();
            return PartialView(data);
        }
        [HttpPost]
        public async Task<JsonResult> EditPasien(VMPasien dataForm)
        {
            VMResponse respon = await pasienService.EditPasien(dataForm);
            return Json(new { dataRespon = respon });
        }
        //Berdasarkan id customer
        public async Task<IActionResult> HapusPasien(int id)
        {
            VMPasien data = await pasienService.GetPasienByIdCustomer(id);
            ViewBag.IdUser = GetUserIdFromSession();
            return PartialView(data);
        }
        [HttpPost]
        public async Task<JsonResult> DeletePasien(int idUser, int idCustomer)
        {
            VMResponse respon = await pasienService.DeletePasien(idUser, idCustomer);
            return Json(new { dataRespon = respon });
        }
        public async Task<IActionResult> MultipleDelete(List<int> listId)
        {
            List<string> listName = new List<string>();
            foreach (int item in listId)
            {
                VMPasien data = await pasienService.GetPasienByIdCustomer(item);
                listName.Add(data.Fullname);
            }
            ViewBag.listName = listName;
            ViewBag.IdUser = GetUserIdFromSession();
            return PartialView();
        }
        [HttpPost]
        public async Task<JsonResult> SureMultipleDelete(int idUser, List<int> listId)
        {
            VMResponse respon = await pasienService.MultipleDelete(idUser, listId);
            return Json(new { dataRespon = respon });
        }
    }
}
