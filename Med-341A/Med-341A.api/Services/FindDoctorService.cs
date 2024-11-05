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

        // If there are any remaining days after counting full months, count it as an additional month
        if (end.Day > start.Day || monthDifference == 0)
        {
            monthDifference++;
        }

        return monthDifference;
    }

    public bool CheckDoctorAvailability(List<VMMedicalFacility> medicalFacilities)
    {
        // Menggunakan zona waktu Indonesia (WIB)
        TimeZoneInfo wibZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        DateTime wibNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, wibZone);

        // Mendapatkan hari dan waktu dalam format Indonesia
        var currentDay = wibNow.ToString("dddd", new CultureInfo("id-ID"));
        var currentTime = wibNow.TimeOfDay;

        foreach (var facility in medicalFacilities)
        {
            if (facility.MedicalFacilityCategoryId != 1)
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
        }
        return false;
    }
}
