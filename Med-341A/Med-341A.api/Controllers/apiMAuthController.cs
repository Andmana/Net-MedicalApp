using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMAuthController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse response = new VMResponse();

        public apiMAuthController(Med341aContext _db)
        {
            this.db = _db;
        }

        [HttpGet("CheckLogin/{email}/{password}")]
        public VMUser CheckLogin(string email, string password)
        {
            VMUser data = (from user in db.MUsers
                           join bio in db.MBiodata 
                           on user.BiodataId equals bio.Id
                           into biouser from bio in biouser.DefaultIfEmpty()
                           where user.IsDelete == false && user.Email == email && user.Password == password
                           select new VMUser
                           {
                               Id = user.Id,
                               RoleId = user.RoleId,
                               Fullname = bio.Fullname,
                           }).FirstOrDefault()!;

            return data;
        }

        [HttpGet("CheckEmailIsValid/{email}")]
        public bool CheckEmailIsValid(string email)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email).FirstOrDefault()!;

            return data != null;
        }

        [HttpGet("CheckPasswordIsValid/{email}/{password}")]
        public bool CheckPasswordIsValid(string email, string password)
        {
            var data = db.MUsers.Where(a => a.IsDelete == false && a.Email == email && a.Password == password).FirstOrDefault()!;

            return data != null;
        }
    }
}
