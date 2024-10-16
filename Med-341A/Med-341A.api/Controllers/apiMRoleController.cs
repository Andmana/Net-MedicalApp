using Med_341A.datamodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMRoleController : ControllerBase
    {
        private readonly Med341aContext db;

        public apiMRoleController(Med341aContext _db)
        {
            db = _db;
        }

        [HttpGet("GetAll")]
        public List<MRole> GetAll()
        {
            List<MRole> data = db.MRoles.ToList();
            return data;
        }
    }
}
