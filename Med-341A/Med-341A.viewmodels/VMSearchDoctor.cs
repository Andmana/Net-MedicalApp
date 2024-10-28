namespace Med_341A.viewmodels;

public class VMSearchDoctor
{
    public long IdDoctor { get; set; }

    public string? Fullname { get; set; }

    public string? ImagePath { get; set; }

    public long? SpecializationId { get; set; }

    public string? SpecializationName { get; set; }

    public DateOnly? EarliestStartWork { get; set; }
    
    public DateOnly? LatestEndWork { get; set; }

    public List<VMMedicalFacility> MedicalFacilities { get; set; } = [];

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
}

public class VMSearchPageDoctor
{
    public int? LocationId { get; set; }

    public int? LocationName { get; set; }

    public string? NameDoctor { get; set; }

    public int? SpecializationId { get; set; }

    public string? SpecializationName { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public int? CurrentPageSize { get; set; }
}