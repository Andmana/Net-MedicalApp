using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiPasienController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse respon = new VMResponse();
        public apiPasienController(Med341aContext db)
        {
            this.db = db;
        }
        //Mendapatkan semua data relasi customer berdasarkan id user
        [HttpGet("GetAllData/{id}")]
        public List<VMPasien> GetAllData(int id)
        {
            MUser user = db.MUsers.Where(a => a.Id == id && a.IsDelete == false).FirstOrDefault()!;
            List<VMPasien> data = (from cmember in db.MCustomerMembers
                                   join crelation in db.MCustomerRelations
                                   on cmember.CustomerRelationId equals crelation.Id
                                   join c in db.MCustomers
                                   on cmember.CustomerId equals c.Id
                                   join b in db.MBiodata
                                   on c.BiodataId equals b.Id
                                   where cmember.ParentBiodataId == user.BiodataId && c.IsDelete == false
                                   select new VMPasien
                                   {
                                       IdUser = user.Id,
                                       IdCustomer = c.Id,
                                       BiodataId = b.Id,
                                       ParentBiodataID = cmember.ParentBiodataId,
                                       CustomerRelationID = cmember.CustomerRelationId,
                                       CustomerMemberID = cmember.Id,
                                       Dob = c.Dob,
                                       Fullname = b.Fullname,
                                       NameRelation = crelation.Name
                                   }).ToList();
            return data;
        }
        [HttpGet("GetAllRelasi")]
        public List<MCustomerRelation> GetAllRelasi()
        {
            List<MCustomerRelation> data = db.MCustomerRelations.Where(a => a.IsDelete == false).ToList();
            return data;
        }

        [HttpGet("GetAllGoldar")]
        public List<MBloodGroup> GetAllGoldar()
        {
            List<MBloodGroup> data = db.MBloodGroups.Where(a => a.IsDelete == false).ToList();
            return data;
        }

        [HttpPost("Simpan")]
        public VMResponse Simpan(VMPasien data)
        {
            MUser user = db.MUsers.Where(a => a.Id == data.IdUser).FirstOrDefault();
            if(user != null)
            {
                try
                {
                    //Menginputkan data biodata terlebih dahulu
                    MBiodatum biodata = new();
                    biodata.Fullname = data.Fullname;
                    biodata.CreatedBy = user.Id;
                    biodata.CreatedOn = DateTime.Now;
                    biodata.IsDelete = false;

                    //Simpan ke db
                    db.Add(biodata);
                    db.SaveChanges();

                    //Menginputkan data customer
                    MCustomer customer = new();
                    customer.BiodataId = biodata.Id;
                    customer.Dob = data.Dob;
                    customer.Gender = data.Gender;
                    customer.BloodGroupId = data.BloodGroupId;
                    customer.RhesusType = data.RhesusType;
                    customer.Height = data.Height;
                    customer.Weight = data.Weight;
                    customer.CreatedBy = user.Id;
                    customer.CreatedOn = DateTime.Now;
                    customer.IsDelete = false;

                    //simpan ke db
                    db.Add(customer);
                    db.SaveChanges();

                    //Menginput data customer relasi
                    MCustomerMember member = new();
                    member.ParentBiodataId = user.BiodataId;
                    member.CustomerId = customer.Id;
                    member.CustomerRelationId = data.CustomerRelationID;
                    member.CreatedBy = user.Id;
                    member.CreatedOn = DateTime.Now;
                    member.IsDelete = false;

                    db.Add(member);
                    db.SaveChanges();

                    respon.Message = "Data Sukses Ditambahkan";
                }
                catch(Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Gagal ditambahkan: " + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Pasien tidak bisa menambahkan data";
            }
            return respon;
        }
        [HttpGet("GetPasienByIdCustomer/{id}")]
        public VMPasien GetPasienByIdCustomer(int id)
        {
            VMPasien data = (from cmember in db.MCustomerMembers
                             join crelation in db.MCustomerRelations
                             on cmember.CustomerRelationId equals crelation.Id
                             join c in db.MCustomers
                             on cmember.CustomerId equals c.Id
                             join b in db.MBiodata
                             on c.BiodataId equals b.Id
                             join blood in db.MBloodGroups
                             on c.BloodGroupId equals blood.Id
                             into bloodGroupJoin from blood in bloodGroupJoin.DefaultIfEmpty()
                             where c.Id == id && c.IsDelete == false
                             select new VMPasien
                             {
                                 ParentBiodataID = cmember.ParentBiodataId,
                                 CustomerMemberID = cmember.Id,
                                 CustomerRelationID = cmember.CustomerRelationId,

                                 NameRelation = crelation.Name,

                                 CodeBlood = blood != null ? blood.Code : null,
                                 
                                 IdCustomer = c.Id,
                                 BiodataId = c.BiodataId,
                                 Dob = c.Dob,
                                 Gender = c.Gender,
                                 BloodGroupId = c.BloodGroupId,
                                 RhesusType = c.RhesusType,
                                 Height = c.Height,
                                 Weight = c.Weight,

                                 Fullname = b.Fullname
                             }).FirstOrDefault()!;
            return data;
        }
    }
}
