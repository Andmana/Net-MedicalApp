namespace Med_341A.viewmodels
{
    public class VMDoctor
    {
        public long Id { get; set; }
        public long? IdUser { get; set; }
        public string? Str { get; set; }
        public long? BiodataId { get; set; }
        public string? Fullname { get; set; }
        public byte[]? Image { get; set; }

        public string? ImagePath { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDelete { get; set; }
    }
}
