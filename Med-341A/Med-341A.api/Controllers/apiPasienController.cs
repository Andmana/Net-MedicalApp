using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

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
                                       NameRelation = crelation.Name,
                                       listCustomerChat = (from chat in db.TCustomerChats
                                                           where chat.CustomerId == c.Id
                                                           select new VMTCustomerChat
                                                           {
                                                               Id = chat.Id,
                                                               CustomerId = chat.CustomerId,
                                                               DoctorId = chat.DoctorId
                                                           }).ToList(),
                                       listCustomerJanji = (from janji in db.TAppointments
                                                            where janji.CustomerId == c.Id
                                                            select new VMTAppointment
                                                            {
                                                                Id = janji.Id,
                                                                CustomerId = janji.CustomerId,
                                                                DoctorOfficeId = janji.DoctorOfficeId
                                                            }).ToList()
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
            if (user != null)
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
                catch (Exception ex)
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
                             into bloodGroupJoin
                             from blood in bloodGroupJoin.DefaultIfEmpty()
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
        [HttpPut("EditPasien")]
        public VMResponse EditPasien(VMPasien dataForm)
        {
            MCustomer customer = db.MCustomers.Where(a => a.Id == dataForm.IdCustomer).FirstOrDefault();
            if (customer != null)
            {
                if (customer.Dob != dataForm.Dob || customer.Gender != dataForm.Gender || customer.BloodGroupId != dataForm.BloodGroupId ||
                   customer.RhesusType != dataForm.RhesusType || customer.Height != dataForm.Height || customer.Weight != dataForm.Weight)
                {
                    customer.Dob = dataForm.Dob;
                    customer.Gender = dataForm.Gender;
                    customer.BloodGroupId = dataForm.BloodGroupId;
                    customer.RhesusType = dataForm.RhesusType;
                    customer.Height = dataForm.Height;
                    customer.Weight = dataForm.Weight;
                    customer.ModifiedBy = dataForm.IdUser;
                    customer.ModifiedOn = DateTime.Now;
                }
                MBiodatum biodata = db.MBiodata.Where(a => a.Id == customer.BiodataId).FirstOrDefault();
                if (biodata.Fullname != dataForm.Fullname)
                {
                    biodata.Fullname = dataForm.Fullname;
                    biodata.ModifiedBy = dataForm.IdUser;
                    biodata.ModifiedOn = DateTime.Now;
                }
                MCustomerMember member = db.MCustomerMembers.Where(a => a.Id == dataForm.CustomerMemberID).FirstOrDefault();
                if (member.CustomerRelationId != dataForm.CustomerRelationID)
                {
                    member.CustomerRelationId = dataForm.CustomerRelationID;
                    member.ModifiedBy = dataForm.IdUser;
                    member.ModifiedOn = DateTime.Now;
                }
                try
                {
                    db.Update(customer);
                    db.Update(biodata);
                    db.Update(member);
                    db.SaveChanges();
                    respon.Message = "Data Sukses di Ubah";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Data Gagal di Ubah: " + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Tidak ditemukan";
            }
            return respon;
        }
        [HttpDelete("DeletePasien/{idUser}/{idCustomer}")]
        public VMResponse DeletePasien(int idUser, int idCustomer)
        {
            MCustomer customer = db.MCustomers.Where(a => a.Id == idCustomer).FirstOrDefault()!;
            if (customer != null)
            {
                customer.IsDelete = true;
                customer.DeletedOn = DateTime.Now;
                customer.DeletedBy = idUser;

                MBiodatum biodata = db.MBiodata.Where(a => a.Id == customer.BiodataId).FirstOrDefault()!;
                biodata.IsDelete = true;
                biodata.DeletedOn = DateTime.Now;
                biodata.DeletedBy = idUser;

                MCustomerMember member = db.MCustomerMembers.Where(a => a.CustomerId == idCustomer).FirstOrDefault()!;
                member.IsDelete = true;
                member.DeletedOn = DateTime.Now;
                member.DeletedBy = idUser;
                try
                {
                    db.Update(customer);
                    db.Update(biodata);
                    db.Update(member);
                    db.SaveChanges();
                    respon.Message = "Data Sukses di Hapus";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Data Gagal di Hapus: " + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Tidak ditemukan";
            }
            return respon;
        }
        [HttpPut("MultipleDelete")]
        public VMResponse MultipleDelete(VMMultipleDelete data)
        {
            if (data.ListId.Count > 0)
            {
                foreach (int item in data.ListId)
                {
                    MCustomer customer = db.MCustomers.Where(a => a.Id == item).FirstOrDefault();
                    customer.IsDelete = true;
                    customer.DeletedOn = DateTime.Now;
                    customer.DeletedBy = data.IdUser;

                    MBiodatum biodata = db.MBiodata.Where(a => a.Id == customer.BiodataId).FirstOrDefault()!;
                    biodata.IsDelete = true;
                    biodata.DeletedOn = DateTime.Now;
                    biodata.DeletedBy = data.IdUser;

                    MCustomerMember member = db.MCustomerMembers.Where(a => a.CustomerId == item).FirstOrDefault()!;
                    member.IsDelete = true;
                    member.DeletedOn = DateTime.Now;
                    member.DeletedBy = data.IdUser;

                    db.Update(customer);
                    db.Update(biodata);
                    db.Update(member);
                }
                try
                {
                    db.SaveChanges();
                    respon.Message = "Data Sukses di Hapus";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Data Gagal di Hapus: " + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Tidak ditemukan";
            }
            return respon;
        }
    }
}
