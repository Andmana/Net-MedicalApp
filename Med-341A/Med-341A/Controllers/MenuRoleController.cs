using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.Controllers
{
    public class MenuRoleController : Controller
    {
        private MenuRoleService mrService;
        private RoleService rService;
        private VMResponse vmResponse = new VMResponse();
        private int idUser = 1;


        public MenuRoleController(MenuRoleService _mrService, RoleService _rService)
        {
            mrService = _mrService;
            rService = _rService;
        }

        //UNTUK ATUR MENU ACCESS
        public async Task<IActionResult> Index(VPage page)
        {
            page.showData = page.showData ?? 5;

            ViewBag.nameSort = string.IsNullOrEmpty(page.sortOrder) ? "name_desc" : "";
            ViewBag.codeSort = page.sortOrder == "code" ? "code_desc" : "code";
            ViewBag.currentSort = page.sortOrder;
            ViewBag.currentShowData = page.showData;

            if (page.searchString != null)
            {

            }
            else
            {
                page.currentFilter = page.searchString;
            }

            ViewBag.currentFilter = page.searchString;

            List<VRole> data = await rService.GetAll();

            if (!string.IsNullOrEmpty(page.searchString))
            {
                data = data.Where(a => a.Name.ToLower().Contains(page.searchString.ToLower())
                                    || a.Code.ToLower().Contains(page.searchString.ToLower()))
                           .ToList();
            }

            switch (page.sortOrder)
            {
                case "code_desc":
                    data = data.OrderByDescending(a => a.Code).ToList();
                    break;
                case "code":
                    data = data.OrderBy(a => a.Code).ToList();
                    break;
                case "name_desc":
                    data = data.OrderByDescending(a => a.Name).ToList();
                    break;
                default:
                    data = data.OrderBy(a => a.Name).ToList();
                    break;
            }

            return View(VPaginatedList<VRole>.CreateAsync(data, page.pageNumber ?? 1, page.showData ?? 5));
        }

        public async Task<IActionResult> Edit_MenuAccess(int id)
        {
            VRole data = await mrService.GetMenuAccess_ById(id);
            ViewBag.role_menu = data.role_menu;
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_MenuAccess(VRole dataParam)
        {
            dataParam.ModifiedBy = idUser;

            VMResponse response = await mrService.Edit_MenuAccess(dataParam);

            if (response.Success)
            {
                return Json(new { dataResponse = response });
            }

            return View(dataParam);
        }
    }
}
