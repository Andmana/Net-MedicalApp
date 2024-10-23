using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMMedicalItemController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse response = new VMResponse();

        public apiMMedicalItemController(Med341aContext _db)
        {
            db = _db;
        }

        // GET: api/<apiMMedivalItemController>
        [HttpGet("GetAll")]
        public List<VMedicalItem> GetAll()
        {
            List<VMedicalItem> data = (from m in db.MMedicalItems
                                       where m.IsDelete == false
                                       select new VMedicalItem
                                       {
                                           Id = m.Id,
                                           Name = m.Name,
                                           Packaging = m.Packaging,
                                           PriceMin = m.PriceMin,
                                           PriceMax = m.PriceMax,
                                           Indication = m.Indication,
                                           ImagePath = m.ImagePath,

                                           MedicalItemCategoryId = m.MedicalItemCategoryId,
                                           MedicalItemSegmentationId = m.MedicalItemSegmentationId,
                                       }).ToList();
            return data;
        }

        
    }
}
