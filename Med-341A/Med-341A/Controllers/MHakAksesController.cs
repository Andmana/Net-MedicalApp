using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class MHakAksesController : Controller
    {
        private MHakAksesService mHakAksesService;
        private int idUser = 1;

        public MHakAksesController(MHakAksesService _mHakAksesService)
        {
            mHakAksesService = _mHakAksesService;
        }

        public async Task< IActionResult > Index()
        {
            List<MRole> data = await mHakAksesService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Add()
        {
            MRole data = new MRole();
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MRole dataForm)
        {
            dataForm.CreatedBy = idUser;
            dataForm.CreatedOn = DateTime.Now;

            VMResponse response = await mHakAksesService.Add(dataForm);

            if (response.Success)
            {
                return Json(new { dataResponse = response });
            }

            return PartialView(dataForm);
        }


    }
}
