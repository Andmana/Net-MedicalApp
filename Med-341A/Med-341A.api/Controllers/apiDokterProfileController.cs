using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiDokterProfileController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse respon = new VMResponse();
        public apiDokterProfileController(Med341aContext db)
        {
            this.db = db;
        }
        [HttpGet("GetDataDokter/{id}")]
        public VMDoctor GetDataDokter(int id)
        {
            VMDoctor data = (from u in db.MUsers
                             join b in db.MBiodata
                             on u.BiodataId equals b.Id
                             join d in db.MDoctors
                             on b.Id equals d.BiodataId
                             where u.Id == id && u.IsDelete == false
                             select new VMDoctor
                             {
                                 IdUser = u.Id,
                                 BiodataId = u.BiodataId,
                                 CreatedBy = u.CreatedBy,
                                 CreatedOn = u.CreatedOn,

                                 Fullname = b.Fullname,
                                 ImagePath = b.ImagePath,

                                 Id = d.Id,
                                 Str = d.Str,
                             }).FirstOrDefault()!;
            return data;
        }
    }
}
