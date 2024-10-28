using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiFindDoctorController : ControllerBase
    {

        private readonly Med341aContext db;
        private VMResponse response = new VMResponse();

        public apiFindDoctorController(Med341aContext _db)
        {
            this.db = _db;
        }

        [HttpGet("GetAllDoctor")]
        public List<VMSearchDoctor> GetAllDoctor()
        {
            List<VMSearchDoctor> result =
                (from doctor in db.MDoctors
                 join bio in db.MBiodata on doctor.BiodataId equals bio.Id
                 join currentSpecial in db.TCurrentDoctorSpecializations on doctor.Id equals currentSpecial.DoctorId
                 join specialization in db.MSpecializations on currentSpecial.SpecializationId equals specialization.Id
                 join doctorOffice in db.TDoctorOffices on doctor.Id equals doctorOffice.DoctorId
                 join medicalFacilities in db.MMedicalFacilities on doctorOffice.MedicalFaciltyId equals medicalFacilities.Id
                 join kecamatan in db.MLocations on medicalFacilities.LocationId equals kecamatan.Id
                 join kota in db.MLocations on kecamatan.ParentId equals kota.Id
                 group new
                 {
                     LocationId = medicalFacilities.LocationId,
                     LocationName = $"{kecamatan.Name}, {kota.Name}",
                     LocationParentId = kecamatan.ParentId,
                     LocationLevelId = kecamatan.LocationLevelId,
                     MedicalFacilityId = medicalFacilities.Id,
                     MedicalFacilitiesName = medicalFacilities.Name,
                     StartWork = doctorOffice.StartDate,
                     EndWork = doctorOffice.EndDate
                 } by new
                 {
                     IdDoctor = doctor.Id,
                     Fullname = bio.Fullname,
                     ImagePath = bio.ImagePath,
                     SpecializationId = specialization.Id,
                     SpecializationName = specialization.Name
                 } into doctorGroup
                 select new VMSearchDoctor
                 {
                     IdDoctor = doctorGroup.Key.IdDoctor,
                     Fullname = doctorGroup.Key.Fullname,
                     ImagePath = doctorGroup.Key.ImagePath,
                     SpecializationId = doctorGroup.Key.SpecializationId,
                     SpecializationName = doctorGroup.Key.SpecializationName,
                     EarliestStartWork = doctorGroup.Min(x => x.StartWork),
                     LatestEndWork = doctorGroup.Any(loc => loc.EndWork == null)
                          ? null : doctorGroup.Max(loc => loc.EndWork),
                     MedicalFacilities = doctorGroup.Select(loc => new VMMedicalFacility
                     {
                         MedicalFacilityId = loc.MedicalFacilityId,
                         MedicalFacilityName = loc.MedicalFacilitiesName,
                         LocationParentId = loc.LocationParentId,
                         LocationLevelId = loc.LocationLevelId,
                         locationId = loc.LocationId,
                         LocationName = loc.LocationName,
                         StartWork = loc.StartWork,
                         EndWork = loc.EndWork
                     }).ToList()
                 }).ToList();

            return result;
        }

        [HttpGet("GetAllCity")]
        public List<MLocation> GetAllCity()
        {
            List<MLocation> data = db.MLocations.Where(a => a.ParentId == null).ToList();

            return data;
        }

        [HttpGet("GetAllSpecialization")]
        public List<MSpecialization> GetAllSpecialization()
        {
            List<MSpecialization> data = db.MSpecializations.ToList();

            return data;
        }

    }
}
