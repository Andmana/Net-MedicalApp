using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMenu
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public long? ParentId { get; set; }
        public string? BigIcon { get; set; }
        public string? SmallIcon { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
