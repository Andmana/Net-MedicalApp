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
                                       ParentBiodataID = user.BiodataId,
                                       CustomerRelationID = crelation.Id,
                                       CustomerMemberID = cmember.Id,
                                       Dob = c.Dob,
                                       Fullname = b.Fullname,
                                       NameRelation = crelation.Name
                                   }).ToList();
            return data;
        }

    }
}
