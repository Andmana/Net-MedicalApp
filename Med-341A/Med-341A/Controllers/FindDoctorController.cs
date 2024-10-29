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
            ViewBag.DoctorTreatmentName = (await findDoctorService.GetAllDcotorTreatment()).Where(a => a.Id == dataSearch.DoctorTreatmentId).Select(treat => treat.Name).FirstOrDefault()!;
            ViewBag.DoctorTreatmentId = dataSearch.DoctorTreatmentId;
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

            if (dataSearch.DoctorTreatmentId != null)
            {
                dataDoctor = dataDoctor.Where(a => a.DoctorTreatment.Any(dt => dt.Name?.ToLower() == ViewBag.DoctorTreatmentName.ToLower())).ToList();
            }

            return View(VPaginatedList<VMSearchDoctor>.CreateAsync(dataDoctor, dataSearch.PageNumber ?? 1, dataSearch.PageSize ?? 10));
        }

        public async Task<IActionResult> SearchMenu(int locationId, int specializationId, string nameDoctor, int doctorTreatmentId)
        {
            VMSearchPageDoctor dataSearch = new VMSearchPageDoctor
            {
                LocationId = locationId,
                SpecializationId = specializationId,
                NameDoctor = nameDoctor,
                DoctorTreatmentId = doctorTreatmentId
            };

            ViewBag.DropdownLocation = (await findDoctorService.GetAllCity()).OrderBy(a => a.Name).Select(a => new MLocation { Id = a.Id, Name = textInfo.ToTitleCase(a.Name ?? "") });
            ViewBag.DropdownSpecialization = (await findDoctorService.GetAllSpecialization()).OrderBy(a => a.Name).Select(a => new MSpecialization { Id = a.Id, Name = textInfo.ToTitleCase(a.Name ?? "") });
            ViewBag.DropdownDoctorTreatment = (await findDoctorService.GetAllDcotorTreatment()).OrderBy(a => a.Name)
            .Select(a => new MSpecialization { Id = a.Id, Name = textInfo.ToTitleCase(a.Name ?? "") })
            .GroupBy(a => a.Name).Select(g => g.First());

            return PartialView(dataSearch);
        }
    }
}
