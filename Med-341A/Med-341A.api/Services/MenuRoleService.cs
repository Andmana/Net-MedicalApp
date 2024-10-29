using Med_341A.datamodels;
using Med_341A.viewmodels;

namespace Med_341A.api.Services
{
    public class MenuRoleService
    {
        private readonly Med341aContext db;
        private VMResponse response = new VMResponse();

        public MenuRoleService(Med341aContext db)
        {
            this.db = db;
        }

        public async Task<List<VMenuRole>> GetMenuAccessParentChildByRoleId(long idRole, long MenuParent, bool onlySelected = false)
        {
            List<VMenuRole> result = new List<VMenuRole>();

            // Get Parent menu if MenuParent = 0 (parent menu have parentId = 0)
            // Get Child Menu if MenuParent (id parent) > 0
            List<MMenu> data = db.MMenus.Where(a => a.ParentId == MenuParent && a.IsDelete == false)
                                            .ToList();

            // Get child menu form each menu
            foreach (MMenu item in data)
            {
                VMenuRole list = new VMenuRole();

                list.IdMenu = item.Id;
                list.MenuName = item.Name;
                list.IsParent = item.ParentId == 0;
                list.MenuParent = item.ParentId;
                list.is_selected = db.MMenuRoles.Where(a => a.RoleId == idRole && a.MenuId == item.Id && a.IsDelete == false).Any();
                
                // 
                list.List_Child = await GetMenuAccessParentChildByRoleId(idRole, item.Id, onlySelected);

                if (onlySelected)
                {
                    if (list.is_selected)
                        result.Add(list);
                }
                else
                    result.Add(list);
            }

            return result;

        }
    }
}
