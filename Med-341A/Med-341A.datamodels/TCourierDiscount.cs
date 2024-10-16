using System;
using System.Collections.Generic;

namespace Med_341A.datamodels;

public partial class TCourierDiscount
{
    public long Id { get; set; }

    public long? CourierTypeId { get; set; }

    public decimal? Value { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public bool IsDelete { get; set; }
}
