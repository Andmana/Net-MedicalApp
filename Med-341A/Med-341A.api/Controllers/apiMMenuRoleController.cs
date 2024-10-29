using Med_341A.api.Services;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiMMenuRoleController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse response = new VMResponse();
        private MenuRoleService mrService;
        private long idUser = 1;

        public apiMMenuRoleController(Med341aContext _db)
        {
            db = _db;
            mrService = new MenuRoleService(db);
        }


        [HttpGet("GetMenuAccess_ById/{id}")]
        public async Task<VRole> GetMenuAccess_ById(int id)
        {
            VRole result = db.MRoles.Where(a => a.Id == id)
                                          .Select(a => new VRole()
                                          {
                                              Id = a.Id,
                                              Name = a.Name,
                                          })
                                          .FirstOrDefault()!;

            result.role_menu = await mrService.GetMenuAccessParentChildByRoleId(result.Id, 0, false);
            return result;
        }

        [HttpPut("Edit_MenuAccess")]
        public VMResponse Edit_MenuAccess(VRole data)
        {
            MRole dt = db.MRoles.Where(a => a.Id == data.Id).FirstOrDefault()!;

            if (dt != null)
            {
                dt.Name = data.Name;
                dt.ModifiedBy = 1;
                dt.ModifiedOn = DateTime.Now;

                try
                {
                    db.Update(dt);

                    //SAVE MenuAccess
                    List<MMenuRole> roleMenuDB = db.MMenuRoles.Where(a => a.RoleId == data.Id).ToList();

                    if (roleMenuDB.Count() > 0)
                    {
                        // delete unused data 
                        // 
                        List<MMenuRole> roleMenuRemove = roleMenuDB.Where(a => ! (data.role_menu.Where( b => b.is_selected && b.IdMenu == a.MenuId ).Select(b => b.Id)  )
                                                                   .Any())
                                                                   .ToList();
                        foreach (MMenuRole item in roleMenuRemove)
                        {
                            //db.Remove(item);

                            item.IsDelete = true;
                            item.ModifiedBy = 1;
                            item.ModifiedOn = DateTime.Now;
                            db.Update(item);
                        }

                        // update existing data
                        List<MMenuRole> roleMenuUpdate = roleMenuDB.Where(a =>
                        (data.role_menu.Where(b => b.is_selected && b.IdMenu == a.MenuId).Select(b => b.Id)).Any()
                        ).ToList();
                        foreach (MMenuRole item in roleMenuUpdate)
                        {
                            if (item.IsDelete == true)
                            {
                                item.IsDelete = false;
                                item.ModifiedBy = idUser;
                                item.ModifiedOn = DateTime.Now;
                                db.Update(item);
                            }
                        }
                    }

                    // insert new data role menu
                    List<MMenuRole> roleMenuAdd = data.role_menu.Where(a =>
                    !(roleMenuDB.Where(b => b.MenuId == a.IdMenu).Select(b => b.Id)).Any() && a.is_selected
                        ).Select(a => new MMenuRole()
                        {
                            MenuId = a.IdMenu,
                            RoleId = data.Id,
                            IsDelete = false,
                            CreatedBy = idUser,
                            CreatedOn = DateTime.Now
                        }).ToList();
                    foreach (MMenuRole item in roleMenuAdd)
                    {
                        db.Add(item);
                    }

                    db.SaveChanges();

                    response.Message = "Data success saved";
                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.Message = "Failed saved : " + e.Message;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Data not found";
            }

            return response;
        }

        [HttpGet("MenuAccess/{IdRole}")]
        public List<VMenuRole> MenuAccess(int IdRole)
        {
            List<VMenuRole> listMenu = (from parent in db.MMenus
                                        join ma in db.MMenuRoles on parent.Id equals ma.MenuId
                                        where parent.ParentId == 0 && ma.RoleId == IdRole
                                        && parent.IsDelete == false && ma.IsDelete == false
                                        select new VMenuRole
                                        {
                                            Id = parent.Id,
                                            MenuName = parent.Name,
                                            MenuAction = parent.Url,
                                            MenuController = parent.Name,
                                            MenuIconBig = parent.BigIcon,
                                            MenuIconSmall = parent.SmallIcon,
                                            IdRole = ma.RoleId,
                                            MenuSorting = parent.Id,
                                            List_Child = (from child in db.MMenus
                                                          join ma2 in db.MMenuRoles on child.Id equals ma2.MenuId
                                                          where child.ParentId == parent.Id && child.IsDelete == false
                                                          && ma2.IsDelete == false && ma2.RoleId == IdRole
                                                          select new VMenuRole
                                                          {
                                                              Id = child.Id,
                                                              MenuName = child.Name,
                                                              MenuAction = child.Url,
                                                              MenuController = child.Name,
                                                              MenuIconBig = child.BigIcon,
                                                              MenuIconSmall = child.SmallIcon,
                                                              IdRole = IdRole,
                                                              MenuSorting = child.Id,
                                                              MenuParent = child.ParentId,

                                                          }).OrderBy(a => a.MenuSorting).ToList()

                                        }).OrderBy(a => a.MenuSorting).ToList();


            //List<VMenuRole> listMenu = (from parent in db.MMenus
            //                            where parent.ParentId == 0 
            //                            && parent.IsDelete == false 
            //                            select new VMenuRole
            //                            {
            //                                Id = parent.Id,
            //                                MenuName = parent.Name,
            //                                MenuAction = parent.Url,

            //                                MenuController = parent.Name,
            //                                MenuIconBig = parent.BigIcon,
            //                                MenuIconSmall = parent.SmallIcon,
            //                                IdRole = IdRole,
            //                                MenuSorting = parent.Id,
            //                                List_Child = (from child in db.MMenus 
            //                                              join menuAccess in db.MMenuRoles on child.Id equals menuAccess.MenuId
            //                                              where 
            //                                                child.ParentId == parent.Id
            //                                                && child.IsDelete == false
            //                                                && menuAccess.IsDelete == false
            //                                                && menuAccess.RoleId == IdRole
            //                                              select new VMenuRole
            //                                              {
            //                                                  Id = child.Id,
            //                                                  MenuName = child.Name,
            //                                                  MenuAction = child.Url,
            //                                                  MenuController = child.Name,
            //                                                  MenuIconBig = child.BigIcon,
            //                                                  MenuIconSmall = child.SmallIcon,
            //                                                  IdRole = IdRole,
            //                                                  MenuSorting = child.Id,
            //                                                  MenuParent = child.ParentId,

            //                                              }).OrderBy(a => a.MenuSorting).ToList()

            //                            }).Where(menu => menu.List_Child.Any())
            //                              .OrderBy(a => a.MenuSorting).ToList();

            return listMenu;
        }
    }
}
