using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Med_341A.datamodels;

[Table("t_doctor_office")]
public partial class TDoctorOffice
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doctor_id")]
    public long? DoctorId { get; set; }

    [Column("medical_facilty_id")]
    public long? MedicalFaciltyId { get; set; }

    [Column("specialization")]
    [StringLength(100)]
    [Unicode(false)]
    public string Specialization { get; set; } = null!;

    [Column("service_unit_id")]
    public long ServiceUnitId { get; set; }

    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("created_by")]
    public long CreatedBy { get; set; }

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column("modified_by")]
    public long? ModifiedBy { get; set; }

    [Column("modified_on", TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [Column("deleted_by")]
    public long? DeletedBy { get; set; }

    [Column("deleted_on", TypeName = "datetime")]
    public DateTime? DeletedOn { get; set; }

    [Column("is_delete")]
    public bool IsDelete { get; set; }
}
