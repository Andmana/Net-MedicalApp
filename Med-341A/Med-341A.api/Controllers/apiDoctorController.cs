using Azure;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiDoctorController : ControllerBase
    {
        private readonly Med341aContext db;
        private int idUser = 1;

        public apiDoctorController(Med341aContext _db)
        {
            db = _db;
        }

        [HttpGet("GetAll")]
        public List<VMDoctor> GetAll()
        {
            List<VMDoctor> data = (from d in db.MDoctors select new VMDoctor { Id = d.Id, Str = d.Str }).ToList();

            return data;
        }

    }
}
