using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Med_341A.Services;

using Newtonsoft.Json;
using Med_341A.datamodels;
namespace Med_341A.Controllers
{
    public class MedicalItemController : Controller
    {
        private MedicalItemService miService;
        public MedicalItemController(MedicalItemService _miService)
        {
            miService = _miService;
        }
        public async Task<IActionResult> Index(VSearchPage dataSearch)
        {
            List<VMedicalItem> data = await  miService.GetAll();

            // Set viewbag as filter history
            ViewBag.Max = dataSearch.MaxAmount;
            ViewBag.Min = dataSearch.MinAmount;

            dataSearch.MinAmount = dataSearch.MinAmount == null ? decimal.MinValue : dataSearch.MinAmount;
            dataSearch.MaxAmount = dataSearch.MaxAmount == null ? decimal.MaxValue : dataSearch.MaxAmount;

            // Filter indicator and name item
            if (dataSearch.Name != null)
            {
                data = data.Where(a => a.Name.ToLower().Contains(dataSearch.Name.ToLower())
                                    || a.Indication.ToLower().Contains(dataSearch.Name.ToLower())
                                   ).ToList();
            }

            // Category filter
            if (dataSearch.CategoryId != null)
            {
                data = data.Where(a => a.MedicalItemCategoryId ==  dataSearch.CategoryId).ToList();
                ViewBag.CategoryName = await miService.GetCategoryName(dataSearch.CategoryId ?? 0);
            }

            // Segmen filter
            if (dataSearch.SegmentationId != null)
            {
                data = data.Where(a => a.MedicalItemSegmentationId == dataSearch.SegmentationId).ToList();
                ViewBag.SegmentationName = await miService.GetSegmentationName(dataSearch.SegmentationId ?? 0);

            }

            // Price Filter
            if (dataSearch.MinAmount != null && dataSearch.MaxAmount != null)
                data = data.Where(a => a.PriceMax >= dataSearch.MinAmount
                                    && a.PriceMax <= dataSearch.MaxAmount).ToList();

            //Get session in VMOrderHeader first load
            VPurchaseHeader dataHeader = HttpContext.Session.GetComplexData<VPurchaseHeader>("ListCart");
            if (dataHeader == null)
            {
                dataHeader = new VPurchaseHeader();
                dataHeader.ListDetails = new List<VPurchaseDetail>();
            }else
            {
                // Used in case DataHeader exists but listdetails is null
                // FIx Error on jquery when listdetails is null
                if (dataHeader.ListDetails == null)
                    dataHeader.ListDetails = new List<VPurchaseDetail>();
            }

            // Set ViewBag
            // Used in client side when reopen the site 
            var ListDetail = JsonConvert.SerializeObject(dataHeader.ListDetails);
            ViewBag.dataHeader = dataHeader;
            ViewBag.dataDetail = ListDetail;

            // Setting viewbag history 
            ViewBag.Search = dataSearch;
            ViewBag.CurrentPageSize = dataSearch.pageSize ?? 4;

            return View(VPaginatedList<VMedicalItem>.CreateAsync(data, dataSearch.pageNumber ?? 1,
                        dataSearch.pageSize ?? 4));
        }

        public async Task<IActionResult> SearchMenu()
        {
            // get dropdown option for filter option
            ViewBag.DropdownCategory = await miService.GetCategory();
            ViewBag.RadioSegmentation = await miService.GetSegmentation();

            return PartialView();
        }

        [HttpPost]
        public JsonResult SetSession(VPurchaseHeader dataHeader)
        {
            // Set Session -> replace current session with new input
            HttpContext.Session.SetComplexData("ListCart", dataHeader);
            return Json("");
        }
    }
}
