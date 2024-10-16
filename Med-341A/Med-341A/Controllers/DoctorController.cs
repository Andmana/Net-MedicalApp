using Azure;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class DoctorController : Controller
    {

        private DoctorService doctorService;
        private int idUser = 1;

        public DoctorController(DoctorService _roleService)
        {
            doctorService = _roleService;
        }

        public async Task<IActionResult> Index()
        {
            List<VMDoctor> data = await doctorService.GetAll();

            return View(data);
        }
    }
}
