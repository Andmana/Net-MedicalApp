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
                 join currSpecialization in db.TCurrentDoctorSpecializations on doctor.Id equals currSpecialization.DoctorId
                 join specialization in db.MSpecializations on currSpecialization.SpecializationId equals specialization.Id
                 join doctorOffice in db.TDoctorOffices on doctor.Id equals doctorOffice.DoctorId
                 join medicalFacilities in db.MMedicalFacilities on doctorOffice.MedicalFaciltyId equals medicalFacilities.Id
                 join kecamatan in db.MLocations on medicalFacilities.LocationId equals kecamatan.Id
                 join kota in db.MLocations on kecamatan.ParentId equals kota.Id
                 where doctorOffice.IsDelete == false && doctor.IsDelete == false
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
                         Schedule = (from dfsh in db.TDoctorOfficeSchedules
                                     join mfsh in db.MMedicalFacilitySchedules on dfsh.MedicalFacilitySchedule equals mfsh.Id
                                     where dfsh.DoctorId == doctorGroup.Key.IdDoctor && mfsh.MedicalFacilityId == loc.MedicalFacilityId && !dfsh.IsDelete && !mfsh.IsDelete
                                     select new DoctorOfficeSchedule
                                     {

                                         Day = mfsh.Day,
                                         TimeScheduleStart = mfsh.TimeScheduleStart,
                                         TimeScheduleEnd = mfsh.TimeScheduleEnd,
                                     }).ToList()
                     }).ToList()
                 }).ToList();

            foreach (var doctor in result)
            {
                doctor.DoctorTreatment = db.TDoctorTreatments.Where(a => a.DoctorId == doctor.IdDoctor).Select(a => new VMDoctorTreatment
                {
                    Id = (Int32)a.Id,
                    DoctorId = (Int32)(a.DoctorId ?? 0),
                    Name = a.Name
                }).ToList();
                doctor.Experience = (Int32)CalculateDoctorExperience(doctor.MedicalFacilities);
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

        public static double CalculateDoctorExperience(List<VMMedicalFacility> facilities)
        {
            // Sort periods by StartWork date
            var sortedFacilities = facilities
                .Where(f => f.StartWork.HasValue) // Ensure StartWork date exists
                .OrderBy(f => f.StartWork)
                .Select(f => new { Start = f.StartWork.Value, End = f.EndWork ?? DateOnly.FromDateTime(DateTime.Today) })
                .ToList();

            double totalExperienceInYears = 0;
            DateOnly? currentStart = null;
            DateOnly? currentEnd = null;

            foreach (var period in sortedFacilities)
            {
                if (currentStart == null)
                {
                    // Initialize the first period
                    currentStart = period.Start;
                    currentEnd = period.End;
                }
                else if (period.Start <= currentEnd) // Overlapping or contiguous period
                {
                    // Extend the end date if the current period overlaps or is contiguous
                    currentEnd = currentEnd = (currentEnd.Value > period.End) ? currentEnd.Value : period.End;
                }
                else
                {
                    // Calculate the duration of the non-overlapping period
                    totalExperienceInYears += (currentEnd.Value.ToDateTime(new TimeOnly()) - currentStart.Value.ToDateTime(new TimeOnly())).TotalDays / 365.25;

                    // Start a new non-overlapping period
                    currentStart = period.Start;
                    currentEnd = period.End;
                }
            }

            // Calculate the last accumulated period
            if (currentStart != null && currentEnd != null)
            {
                totalExperienceInYears += (currentEnd.Value.ToDateTime(new TimeOnly()) - currentStart.Value.ToDateTime(new TimeOnly())).TotalDays / 365.25;
            }

            return totalExperienceInYears;
        }


    }
}
