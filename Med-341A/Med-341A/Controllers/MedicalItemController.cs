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
            ViewBag.Max = dataSearch.MaxAmount;
            ViewBag.Min = dataSearch.MinAmount;
            dataSearch.MinAmount = dataSearch.MinAmount == null ? decimal.MinValue : dataSearch.MinAmount;
            dataSearch.MaxAmount = dataSearch.MaxAmount == null ? decimal.MaxValue : dataSearch.MaxAmount;

            if (dataSearch.Name != null)
            {
                data = data.Where(a => a.Name.ToLower().Contains(dataSearch.Name.ToLower())
                                    || a.Indication.ToLower().Contains(dataSearch.Name.ToLower())
                                   ).ToList();
            }

            if (dataSearch.CategoryId != null)
            {
                data = data.Where(a => a.MedicalItemCategoryId ==  dataSearch.CategoryId).ToList();
                ViewBag.CategoryName = await miService.GetCategoryName(dataSearch.CategoryId ?? 0);
            }

            if (dataSearch.SegmentationId != null)
            {
                data = data.Where(a => a.MedicalItemSegmentationId == dataSearch.SegmentationId).ToList();
                ViewBag.SegmentationName = await miService.GetSegmentationName(dataSearch.SegmentationId ?? 0);

            }

            if (dataSearch.MinAmount != null && dataSearch.MaxAmount != null)
                data = data.Where(a => a.PriceMax >= dataSearch.MinAmount
                                    && a.PriceMax <= dataSearch.MaxAmount).ToList();
            else if (dataSearch.MinAmount != null)
                data = data.Where(a => a.PriceMax >= dataSearch.MinAmount).ToList();
            else if (dataSearch.MaxAmount != null)
                data = data.Where(a => a.PriceMax <= dataSearch.MinAmount).ToList();

            //Get session in VMOrderHeader first load
            VChart dataChart = HttpContext.Session.GetComplexData<VChart>("ListCart");
            if (dataChart == null)
            {
                dataChart = new VChart();
                dataChart.listItem = new List<VChartItem>();
            }

            var listItem = JsonConvert.SerializeObject(dataChart.listItem);
            ViewBag.dataChart = dataChart;
            ViewBag.dataItem = listItem;

            ViewBag.Search = dataSearch;
            ViewBag.CurrentPageSize = dataSearch.pageSize;

            return View(VPaginatedList<VMedicalItem>.CreateAsync(data, dataSearch.pageNumber ?? 1,
                        dataSearch.pageSize ?? 3));
        }

        public async Task<IActionResult> SearchMenu()
        {
            ViewBag.DropdownCategory = await miService.GetCategory();
            ViewBag.RadioSegmentation = await miService.GetSegmentation();
            return PartialView();
        }

        [HttpPost]
        public JsonResult SetSession(VChart dataHeader)
        {
            HttpContext.Session.SetComplexData("ListCart", dataHeader);
            return Json("");
        }
    }
}
