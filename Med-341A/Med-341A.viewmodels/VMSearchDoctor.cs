namespace Med_341A.viewmodels;
using System.Globalization;

public class VMSearchDoctor
{
    public long IdDoctor { get; set; }

    public string? Fullname { get; set; }

    public string? ImagePath { get; set; }

    public long? SpecializationId { get; set; }

    public string? SpecializationName { get; set; }

    public int? ExperienceInMonth { get; set; }

    public List<VMMedicalFacility> MedicalFacilities { get; set; } = [];

    public List<VMDoctorTreatment> DoctorTreatment { get; set; } = [];

    // Properti baru untuk status online
    public bool IsOnline => CheckDoctorAvailability();

    private bool CheckDoctorAvailability()
    {
        // Menggunakan zona waktu Indonesia (WIB)
        TimeZoneInfo wibZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        DateTime wibNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, wibZone);

        // Mendapatkan hari dan waktu dalam format Indonesia
        var currentDay = wibNow.ToString("dddd", new CultureInfo("id-ID"));
        var currentTime = wibNow.TimeOfDay;
        
        foreach (var facility in MedicalFacilities)
        {
            foreach (var schedule in facility.Schedule)
            {
                if (schedule.Day == currentDay)
                {
                    var start = TimeSpan.Parse(schedule.TimeScheduleStart!);
                    var end = TimeSpan.Parse(schedule.TimeScheduleEnd!);

                    if (currentTime >= start && currentTime <= end)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

public class VMMedicalFacility
{
    public long? MedicalFacilityId { get; set; }

    public string? MedicalFacilityName { get; set; }

    public long? locationId { get; set; }

    public string? LocationName { get; set; }

    public long? LocationParentId { get; set; }

    public long? LocationLevelId { get; set; }

    public DateOnly? StartWork { get; set; }

    public DateOnly? EndWork { get; set; }

    public List<VMDoctorOfficeSchedule> Schedule { get; set; } = [];
}

public class VMDoctorOfficeSchedule
{
    public int? DoctorOfficeScheduleId { get; set; }

    public int? MedicalFacilityId { get; set; }

    public string? Day { get; set; }

    public string? TimeScheduleStart { get; set; }

    public string? TimeScheduleEnd { get; set; }
}

public class VMSearchPageDoctor
{
    public int? LocationId { get; set; }

    public int? LocationName { get; set; }

    public string? NameDoctor { get; set; }

    public int? SpecializationId { get; set; }

    public string? SpecializationName { get; set; }

    public int? DoctorTreatmentId { get; set; }

    public string? DoctorTreatmentName { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public int? CurrentPageSize { get; set; }
}

public class VMDoctorTreatment
{
    public int Id { get; set; }
    public int? DoctorId { get; set; }
    public string? Name { get; set; }
}