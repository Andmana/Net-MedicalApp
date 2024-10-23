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
        [HttpGet("GetDataUser/{id}")]
        public VMDoctor GetDataDokter(int id)
        {
            VMDoctor data = db.MDoctors.Where(a => a.Id == id)
                .Select(a => new VMDoctor
                {
                    Id = a.Id,
                    BiodataId = a.BiodataId,
                    Str = a.Str
                }).FirstOrDefault()!;
            return data;
        }
    }
}
