using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class MHakAksess : Controller
    {
        private MHakAksesService mHakAksesService;
        private int idUser = 1;

        public MHakAksess(MHakAksesService _mHakAksesService)
        {
            mHakAksesService = _mHakAksesService;
        }

        public async Task< IActionResult > Index()
        {
            List<MRole> data = await mHakAksesService.GetAll();
            return View();
        }
    }
}
