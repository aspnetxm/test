/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Service.Interfaces;
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Galaxy.Web.Areas.SystemManage.Controllers
{
    public class RoleAuthorizeController : ControllerBase
    {
        private IRoleAuthorizeService _roleAuthorizeApp;
        private IModuleService _moduleApp;
        private IModuleButtonService _moduleButtonApp;

        public RoleAuthorizeController(IRoleAuthorizeService roleAuthorizeApp, IModuleService moduleApp, IModuleButtonService moduleButtonApp)
        {
            _roleAuthorizeApp = roleAuthorizeApp;
            _moduleApp = moduleApp;
            _moduleButtonApp = moduleButtonApp;
        }

        public ActionResult GetPermissionTree(string roleId)
        {
            var moduledata = _moduleApp.GetList();
            var buttondata = _moduleButtonApp.GetList();
            var authorizedata = new List<RoleAuthorize>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizedata = _roleAuthorizeApp.GetList(roleId);
            }
            var treeList = new List<TreeViewModel>();
            foreach (Module item in moduledata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduledata.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.EnCode;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.ItemId == item.Id);
                tree.hasChildren = true;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            foreach (ModuleButton item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.EnCode;
                tree.parentId = item.ParentId == "0" ? item.ModuleId : item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.ItemId == item.Id);
                tree.hasChildren = hasChildren;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}
