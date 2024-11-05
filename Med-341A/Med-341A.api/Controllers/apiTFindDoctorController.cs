using Med_341A.api.Services;
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

        private FindDoctorService findDoctorService;

        private VMResponse response = new VMResponse();

        public apiFindDoctorController(Med341aContext _db, FindDoctorService _findoctorService)
        {
            this.db = _db;
            this.findDoctorService = _findoctorService;
        }

        [HttpGet("GetAllDoctor")]
        public List<VMSearchDoctor> GetAllDoctor()
        {
            List<VMSearchDoctor> result =
                (from doctor in db.MDoctors
                 join bio in db.MBiodata on doctor.BiodataId equals bio.Id
                 join currSpecialization in db.TCurrentDoctorSpecializations on doctor.Id equals currSpecialization.DoctorId
                 join specialization in db.MSpecializations on currSpecialization.SpecializationId equals specialization.Id
                 join doctorOffice in db.TDoctorOffices on doctor.Id equals doctorOffice.DoctorId
                 join medicalFacilities in db.MMedicalFacilities on doctorOffice.MedicalFaciltyId equals medicalFacilities.Id
                 join medicalFacilityCategories in db.MMedicalFacilityCategories on medicalFacilities.MedicalFacilityCategoryId equals medicalFacilityCategories.Id
                 join kecamatan in db.MLocations on medicalFacilities.LocationId equals kecamatan.Id
                 join kota in db.MLocations on kecamatan.ParentId equals kota.Id
                 where
                    doctorOffice.IsDelete == false
                    && doctorOffice.EndDate == null
                    && doctor.IsDelete == false
                    && currSpecialization.IsDelete == false
                    && doctorOffice.IsDelete == false
                    && medicalFacilities.IsDelete == false

                 // Grouping the result after doctor data
                 group new
                 {
                     LocationId = medicalFacilities.LocationId,
                     LocationName = $"{kecamatan.Name}, {kota.Name}",
                     LocationParentId = kecamatan.ParentId,
                     LocationLevelId = kecamatan.LocationLevelId,
                     MedicalFacilityId = medicalFacilities.Id,
                     MedicalFacilitiesName = medicalFacilities.Name,
                     StartWork = doctorOffice.StartDate,
                     EndWork = doctorOffice.EndDate,
                     MedicalFacilityCategoryId = medicalFacilities.MedicalFacilityCategoryId,
                     MedicalFacilityCategory = medicalFacilityCategories.Name
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

                     //  Calculate Experience In Month
                     ExperienceInMonth = (Int32)findDoctorService.CalculateDoctorExperience(
                        db.TDoctorOffices
                        .Where(a => a.DoctorId == doctorGroup.Key.IdDoctor && a.IsDelete == false)
                        .Select(loc => new VMMedicalFacility { StartWork = loc.StartDate, EndWork = loc.EndDate }).ToList()),
                     // End Calculate Experience In Month

                     // Mapping Medical Treatment
                     DoctorTreatment = db.TDoctorTreatments.Where(a => a.DoctorId == doctorGroup.Key.IdDoctor && !a.IsDelete).Select(a => new VMDoctorTreatment
                     {
                         Id = (Int32)a.Id,
                         DoctorId = (Int32)(a.DoctorId ?? 0),
                         Name = a.Name
                     }).ToList(),
                     // End Medical Treatment

                     // Mapping Medical Facility 
                     MedicalFacilities = doctorGroup.Where(loc => loc.EndWork == null).Select(loc => new VMMedicalFacility
                     {
                         MedicalFacilityId = loc.MedicalFacilityId,
                         MedicalFacilityName = loc.MedicalFacilitiesName,
                         LocationParentId = loc.LocationParentId,
                         LocationLevelId = loc.LocationLevelId,
                         locationId = loc.LocationId,
                         LocationName = loc.LocationName,
                         StartWork = loc.StartWork,
                         EndWork = loc.EndWork,
                         MedicalFacilityCategoryId = loc.MedicalFacilityCategoryId,
                         MedicalFacilityCategoryName = loc.MedicalFacilityCategory,

                         // Mapping Medical Facility Schedule inner every medical facility
                         Schedule = (from dfsh in db.TDoctorOfficeSchedules
                                     join mfsh in db.MMedicalFacilitySchedules on dfsh.MedicalFacilitySchedule equals mfsh.Id
                                     where dfsh.DoctorId == doctorGroup.Key.IdDoctor && mfsh.MedicalFacilityId == loc.MedicalFacilityId && !dfsh.IsDelete && !mfsh.IsDelete
                                     select new VMDoctorOfficeSchedule
                                     {
                                         DoctorOfficeScheduleId = (int)dfsh.Id,
                                         MedicalFacilityId = mfsh.MedicalFacilityId,
                                         Day = mfsh.Day,
                                         TimeScheduleStart = mfsh.TimeScheduleStart,
                                         TimeScheduleEnd = mfsh.TimeScheduleEnd,
                                     }).ToList()
                         // End Mapping Medical Facility Schedule

                     }).ToList()
                     // End Mapping Medical Facility

                 }).ToList();

            foreach (var doctor in result)
            {
                doctor.IsOnline = findDoctorService.CheckDoctorAvailability(doctor.MedicalFacilities);
            }

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


        [HttpGet("GetAllDoctorTreatment")]
        public List<VMDoctorTreatment> GetAllDoctorTreatment()
        {
            List<VMDoctorTreatment> data = db.TDoctorTreatments.Select(a => new VMDoctorTreatment
            {
                Id = (Int32)a.Id,
                DoctorId = (Int32)(a.DoctorId ?? 0),
                Name = a.Name
            }).ToList();

            return data;
        }

    }
}
