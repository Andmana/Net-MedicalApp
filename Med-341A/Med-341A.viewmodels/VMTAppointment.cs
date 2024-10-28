using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMTAppointment
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? DoctorOfficeId { get; set; }
        public long? DoctorOfficeScheduleId { get; set; }
        public long? DoctorOfficeTreatmentId { get; set; }
        public DateOnly? AppointmentDate { get; set; }

        public long? IdDoctor {  get; set; }

    }
}
