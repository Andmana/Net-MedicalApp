using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VPurchaseHeader
    {
        public long? Id { get; set; }
        public long? CustomerId { get; set; }
        public string? CustomerName { get; set; }


        public int ItemCount { get; set; }
        public int TotalQty { get; set; }
        public decimal Amount { get; set; }


        public List<VPurchaseDetail> ListDetails { get; set; }



        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool? IsDelete { get; set; }
    }
}
