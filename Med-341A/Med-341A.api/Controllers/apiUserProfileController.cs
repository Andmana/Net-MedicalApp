using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Threading.Tasks.Dataflow;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiUserProfileController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse respon = new VMResponse();
        public apiUserProfileController(Med341aContext db)
        {
            this.db = db;
        }

        //Mendapatkan semua data akun dan biodata user berdasarkan id user
        [HttpGet("GetDataUser/{id}")]
        public VMUser GetDataUser(int id)
        {
            VMUser data = (from u in db.MUsers
                           join b in db.MBiodata
                           on u.BiodataId equals b.Id
                           join c in db.MCustomers
                           on b.Id equals c.BiodataId
                           where u.Id == id && u.IsDelete == false
                           select new VMUser
                           {
                               Id = u.Id,
                               Fullname = b.Fullname,
                               BiodataId = u.BiodataId,
                               MobilePhone = b.MobilePhone,
                               ImagePath = b.ImagePath,
                               Dob = c.Dob,
                               Email = u.Email,
                               Password = u.Password,
                               CreatedOn = b.CreatedOn,
                               CreatedBy = b.CreatedBy
                           }).FirstOrDefault()!;
            return data;
        }
        [HttpPut("UbahPribadi")]
        public VMResponse UbahPribadi(VMUser dataAwal)
        {
            MBiodatum dataBio = db.MBiodata.Where(a => a.Id == dataAwal.BiodataId).FirstOrDefault()!;
            MCustomer dataCust = db.MCustomers.Where(a => a.BiodataId == dataAwal.BiodataId).FirstOrDefault()!;
            if(dataBio != null && dataCust != null)
            {
                dataBio.Fullname = dataAwal.Fullname;
                dataBio.MobilePhone = dataAwal.MobilePhone;
                dataBio.ModifiedBy = dataAwal.Id;
                dataBio.ModifiedOn = DateTime.Now;

                dataCust.Dob = dataAwal.Dob;
                dataCust.ModifiedBy = dataAwal.Id;
                dataCust.ModifiedOn = DateTime.Now;
                try
                {
                    db.Update(dataBio);
                    db.Update(dataCust);
                    db.SaveChanges();
                    respon.Message = "Data Success Updated";
                }
                catch(Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Failed Updated" + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Not Found";
            }
            return respon;

        }
        [HttpPut("UbahGambar")]
        public VMResponse UbahGambar(VMUploadGambar dataInput)
        {
            MBiodatum data = db.MBiodata.Where(a => a.Id == dataInput.BiodataId).FirstOrDefault()!;
            if(data != null)
            {
                if (dataInput.ImagePath != null)
                {
                    data.ImagePath = dataInput.ImagePath;
                }
                data.ModifiedBy = dataInput.Id;
                data.ModifiedOn = DateTime.Now;
                try
                {
                    db.Update(data);
                    db.SaveChanges();
                    respon.Message = "Unggah Gambar Berhasil";
                }
                catch (Exception ex)
                {
                    respon.Success = false;
                    respon.Message = "Gagal Unggah, Pesan Error: " + ex.Message;
                }
            }
            else
            {
                respon.Success = false;
                respon.Message = "Data Tidak Ditemukan";
            }
            return respon;
        }
    }
}
