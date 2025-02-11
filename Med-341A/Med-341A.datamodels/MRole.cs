﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Med_341A.datamodels;

[Table("m_role")]
public partial class MRole
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("code")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Code { get; set; }

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
