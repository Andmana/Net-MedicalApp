﻿using Azure;
using Med_341A.datamodels;
using Med_341A.Services;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Med_341A.Controllers
{
    public class RoleController : Controller
    {
        private static VPage page = new VPage();
        private RoleService roleService;

        private int idUser = 1;

        public RoleController(RoleService _roleService)
        {
            roleService = _roleService;
        }

        public async Task< IActionResult > Index(VPage page)
        {
            //
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

            List<VRole> data = await roleService.GetAll();

            if (!string.IsNullOrEmpty(page.searchString))
            {
                data = data.Where(a => a.Name.ToLower().Contains( page.searchString.ToLower() )
                                    || a.Code.ToLower().Contains( page.searchString.ToLower() ))
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

        public async Task<JsonResult> IsRoleExists(int id, string name, string code)
        {
            VFlagExists response = await roleService.IsRoleExists(id, name, code);
            return Json(new { dataResponse = response });
        }

        public IActionResult Add()
        {
            MRole data = new MRole();
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MRole dataForm)
        {
            dataForm.CreatedBy = idUser;
            dataForm.CreatedOn = DateTime.Now;

            VMResponse response = await roleService.Add(dataForm);

            if (response.Success)
            {
                return Json(new { dataResponse = response });
            }

            return PartialView(dataForm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            MRole data = await roleService.GetById(id);

            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MRole dataForm)
        {
            dataForm.ModifiedBy = idUser;
            dataForm.ModifiedOn = DateTime.Now;

            VMResponse response = await roleService.Edit(dataForm);

            if (response.Success)
            {
                return Json(new { dataResponse = response });
            }

            return PartialView(dataForm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            MRole data = await roleService.GetById(id);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> SureDelete(int id)
        {
            VMResponse response = await roleService.Delete(id, idUser);

            if (response.Success)
            {
                return Json(new { dataResponse = response });
            }
            return RedirectToAction("Index");
        }
    }
}
