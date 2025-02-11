﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Med_341A.datamodels;

[Table("m_biodata_address")]
public partial class MBiodataAddress
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("biodata_id")]
    public long? BiodataId { get; set; }

    [Column("label")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Label { get; set; }

    [Column("recipent")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Recipent { get; set; }

    [Column("recipent_phone_number")]
    [StringLength(15)]
    [Unicode(false)]
    public string? RecipentPhoneNumber { get; set; }

    [Column("location_id")]
    public long? LocationId { get; set; }

    [Column("postal_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [Column("address", TypeName = "text")]
    public string? Address { get; set; }

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
