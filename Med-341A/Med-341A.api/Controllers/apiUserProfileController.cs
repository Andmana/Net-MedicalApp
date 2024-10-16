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
                               MobilePhone = b.MobilePhone,
                               ImagePath = b.ImagePath,
                               Dob = c.Dob,
                               Email = u.Email,
                               Password = u.Password

                           }).FirstOrDefault()!;
            return data;
        }
    }
}
