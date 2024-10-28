using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMTCustomerChat
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? DoctorId { get; set; }
    }
}
