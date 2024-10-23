using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Med_341A.viewmodels
{
    public class VMUser
    {
        public long Id { get; set; }

        public long? BiodataId { get; set; }

        // start: dari tabel biodata
        public string? Fullname { get; set; }

        public string? MobilePhone { get; set; }

        public byte[]? Image { get; set; }

        public string? ImagePath { get; set; }
        // end: dari tabel biodata

        public long? RoleId { get; set; }

        public string? NameRole { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? LoginAttempt { get; set; }

        public DateOnly? Dob { get; set; }

        public bool? IsLocked { get; set; }

        public DateTime? LastLogin { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool? IsDelete { get; set; }
        
    }
}