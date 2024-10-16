using System;
using System.Collections.Generic;

namespace Med_341A.datamodels;

public partial class MCustomer
{
    public long Id { get; set; }

    public long? BiodataId { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public long? BloodGroupId { get; set; }

    public string? RhesusType { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public bool IsDelete { get; set; }
}
