using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VPurchaseDetail
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public long? MedicalItemPurchaseId { get; set; }

        public long? MedicalItemId { get; set; }


        public long? MedicalFacilityId { get; set; }

        public long? CourierId { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? SubTotal { get; set; }



        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool? IsDelete { get; set; }
    }

}