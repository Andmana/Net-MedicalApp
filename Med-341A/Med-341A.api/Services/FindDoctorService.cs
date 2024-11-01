using Med_341A.viewmodels;

namespace Med_341A.api.Services;

public class FindDoctorService
{
    public double CalculateDoctorExperience(List<VMMedicalFacility> facilities)
    {
        // Sort periods by StartWork date
        var sortedFacilities = facilities
            .Where(f => f.StartWork.HasValue) // Ensure StartWork date exists
            .OrderBy(f => f.StartWork)
            .Select(f => new
            {
                Start = f.StartWork.Value,
                End = f.EndWork ?? DateOnly.FromDateTime(DateTime.Today)
            })
            .ToList();

        int totalExperienceInMonths = 0;
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

    // Helper method to calculate the difference in months between two dates
    private static int GetMonthDifference(DateOnly start, DateOnly end)
    {
        return ((end.Year - start.Year) * 12) + end.Month - start.Month;
    }
}
