using System.Globalization;
using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class FindDoctorController : Controller
    {
        private readonly FindDoctorService findDoctorService;
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;



        public FindDoctorController(FindDoctorService _findDoctorService)
        {
            this.findDoctorService = _findDoctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(VMSearchPageDoctor dataSearch)
        {
            List<VMSearchDoctor> dataDoctor = (await findDoctorService.GetAllSearchDoctor()).OrderBy(a => a.Fullname).ToList();

            ViewBag.LocationName = (await findDoctorService.GetAllCity()).Where(a => a.Id == dataSearch.LocationId).Select(loc => loc.Name).FirstOrDefault()!;
            ViewBag.LocationId = dataSearch.LocationId;
            ViewBag.SpecializationName = (await findDoctorService.GetAllSpecialization()).Where(a => a.Id == dataSearch.SpecializationId).Select(spec => spec.Name).FirstOrDefault()!;
            ViewBag.SpecializationId = dataSearch.SpecializationId;
            ViewBag.CurrentNameDoctor = dataSearch.NameDoctor;

            if (dataSearch.LocationId != null)
            {
                dataDoctor = dataDoctor.Where(a => a.MedicalFacilities.Any(a => a.LocationParentId == dataSearch.LocationId)).ToList();
            }

            if (dataSearch.SpecializationId != null)
            {
                dataDoctor = dataDoctor.Where(a => a.SpecializationId == dataSearch.SpecializationId).ToList();
            }

            if (!string.IsNullOrEmpty(dataSearch.NameDoctor))
            {
                dataDoctor = dataDoctor.Where(a => a.Fullname!.ToLower().Contains(dataSearch.NameDoctor.ToLower())).ToList();
            }

            return View(VPaginatedList<VMSearchDoctor>.CreateAsync(dataDoctor, dataSearch.PageNumber ?? 1, dataSearch.PageSize ?? 10));
        }

        public async Task<IActionResult> SearchMenu(int locationId, int specializationId, string nameDoctor)
        {
            VMSearchPageDoctor dataSearch = new VMSearchPageDoctor
            {
                LocationId = locationId,
                SpecializationId = specializationId,
                NameDoctor = nameDoctor
            };

            ViewBag.DropdownLocation = (await findDoctorService.GetAllCity()).OrderBy(a => a.Name).Select(a => new MLocation { Id = a.Id, Name = textInfo.ToTitleCase(a.Name ?? "") });
            ViewBag.DropdownSpecialization = (await findDoctorService.GetAllSpecialization()).OrderBy(a => a.Name).Select(a => new MSpecialization { Id = a.Id, Name = textInfo.ToTitleCase(a.Name ?? "") });

            return PartialView(dataSearch);
        }
    }
}
