using Med_341A.viewmodels;
using System.Globalization;

namespace Med_341A.api.Services;

public class FindDoctorService
{
    public double CalculateDoctorExperience(List<VMMedicalFacility> facilities)
    {
        // Semua riwayat praktek dokter di sorting baik yang masih berjalan atau sudah selesai
        // dibuatkan object baru yang hanya berisi awal dan akhir praktek di fasilitas kesehatan tersebut
        // diurutkan berdasarkan waktu terlama pada start date
        var sortedFacilities = facilities
            .Where(f => f.StartWork.HasValue) // Memastikan startDate tidak null atau harus memiliki isi
            .OrderBy(f => f.StartWork)
            .Select(f => new
            {
                Start = f.StartWork.Value,
                End = f.EndWork ?? DateOnly.FromDateTime(DateTime.Today) // ketika endWork bernilai null maka assign dengan tanggal dan waktu sekarang
            })
            .ToList();

        // inisialisasi awal currentStart dan currentDate untuk menjadi parameter ketika kalkulasi looping
        // currentStart dibuat null untuk menghindari kesalahan kalkulasi object pertama yang akan dihitung
        // totalExperience di set ke 0;
        int totalExperienceInMonths = 0;
        DateOnly? currentStart = null;
        DateOnly? currentEnd = null;

        // example (sudah disorting): [{start: '2021-01-01', end: '2022-10-01'}, {start: '2021-05-01', end: 'now'}]
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
                currentEnd = (currentEnd.Value > period.End) ? currentEnd.Value : period.End;
            }
            else
            {
                // Calculate the duration of the current non-overlapping period in months
                totalExperienceInMonths += GetMonthDifference(currentStart.Value, currentEnd.Value);

                // Start a new non-overlapping period
                currentStart = period.Start;
                currentEnd = period.End;
            }
        }

        // Calculate the last accumulated period in months
        if (currentStart != null && currentEnd != null)
        {
            totalExperienceInMonths += GetMonthDifference(currentStart.Value, currentEnd.Value);
        }

        return totalExperienceInMonths;
    }

    // Helper method to calculate the difference in months between two dates, with a minimum of 1 month
    private static int GetMonthDifference(DateOnly start, DateOnly end)
    {
        int monthDifference = ((end.Year - start.Year) * 12) + end.Month - start.Month;
        // example start: 2020-05-05, end: 2022-01-10
        // end.year - start.year = 2022 - 2020 = 2 * 12 = 24
        // end.mont - start.month = 1 - 5 = -4
        // totalMonth = 24 + (-4) = 20         

        // If there are any remaining days after counting full months, count it as an additional month
        if (end.Day > start.Day || monthDifference == 0)
        {
            monthDifference++;
        }
        // end.day > start.day = month++ = 21

        // at the front end calculate
        // 20 / 12 = 1 year
        // 20 % 12 = 9 month

        return monthDifference;
    }

    // public bool CheckDoctorAvailability(List<VMMedicalFacility> medicalFacilities)
    // {
    //     // Menggunakan zona waktu Indonesia (WIB)
    //     TimeZoneInfo wibZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
    //     DateTime wibNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, wibZone);

    //     // Mendapatkan hari dan waktu dalam format Indonesia
    //     var currentDay = wibNow.ToString("dddd", new CultureInfo("id-ID"));
    //     var currentTime = wibNow.TimeOfDay;

    //     foreach (var facility in medicalFacilities)
    //     {
    //         if (facility.MedicalFacilityCategoryId == 1)
    //         {
    //             foreach (var schedule in facility.Schedule)
    //             {
    //                 if (schedule.Day == currentDay)
    //                 {
    //                     var start = TimeSpan.Parse(schedule.TimeScheduleStart!);
    //                     var end = TimeSpan.Parse(schedule.TimeScheduleEnd!);

    //                     if (currentTime >= start && currentTime <= end || currentTime >= 22:00wib && currentTime <= 8:00wib)
    //                     {
    //                         return false;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //     return true;
    // }

    public bool CheckDoctorAvailability(List<VMMedicalFacility> medicalFacilities)
    {
        TimeZoneInfo wibZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        DateTime wibNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, wibZone);

        TimeSpan allowedStartTime = new TimeSpan(8, 0, 0); // set bottom limit of time to 8:00
        TimeSpan allowedEndTime = new TimeSpan(22, 0, 0); //  set the upper limit of time to 22:00
        TimeSpan currentTime = wibNow.TimeOfDay; // get the current time on indonesian time zone

        if (currentTime < allowedStartTime || currentTime > allowedEndTime)
        {
            // if current time is out of range the from the limit then return false
            return false;
        }

        // Loop through each facility (inner medical facility have the scheduled of the doctor should be stand by on that)
        foreach (var facility in medicalFacilities)
        {
            if (facility.MedicalFacilityCategoryId == 1)
            {
                // Check if there is a schedule for today
                foreach (var schedule in facility.Schedule)
                {
                    if (schedule.Day == wibNow.ToString("dddd", new CultureInfo("id-ID")))
                    {
                        var scheduleStart = TimeSpan.Parse(schedule.TimeScheduleStart!);
                        var scheduleEnd = TimeSpan.Parse(schedule.TimeScheduleEnd!);

                        // Check if current time is within the schedule time range
                        if (currentTime >= scheduleStart && currentTime <= scheduleEnd)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        // Return true if all facilities meet the conditions for availability
        return true;
    }
}
