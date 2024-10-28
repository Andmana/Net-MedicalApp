using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMRiwayatPraktek
    {
        public long? IdDoctorOffice { get; set; }
        public long? DoctorId { get; set; }
        public long? MedicalFaciltyId { get; set; }
        public string Specialization { get; set; } = null!;
        public long? ServiceUnitId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public long? IdMedicalFacility { get; set; }
        public string? NameMedicalFacility { get; set; }
        public long? MedicalFacilityCategoryId { get; set; }
        public long? LocationId { get; set; }
        public string? FullAddress { get; set; }
        public string? Email { get; set; }
        public string? PhoneCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
    }
}
