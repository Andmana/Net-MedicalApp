using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMPasien
    {
        public long CustomerMemberID { get; set; }
        public long? IdUser { get; set; }
        public long? IdCustomer { get; set; }
        public long? BiodataId { get; set; }
        public long? BloodGroupId { get; set; }
        public long? ParentBiodataID { get; set; }
        public long? CustomerRelationID { get; set; }
        public string? NameRelation { get; set; }
        public string? Fullname { get; set; }
        public DateOnly? Dob { get; set; }
        public string? Gender { get; set; }
        public string? CodeBlood { get; set; }
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

        public List<VMTCustomerChat>? listCustomerChat { get; set; }
        public List<VMTAppointment>? listCustomerJanji { get; set; }
    }
}
