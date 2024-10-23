using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class MedicalItemController : Controller
    {
        private MedicalItemService miService;
        public MedicalItemController(MedicalItemService _miService)
        {
            miService = _miService;
        }
        public async Task <IActionResult >Index()
        {
            List<VMedicalItem> data = await  miService.GetAll();
            return View(data);
        }
    }
}
