/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Galaxy.Utility;
using Galaxy.Service.SystemManage;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Web.Areas.SystemManage.Controllers
{
    public class RoleController : ControllerBase
    {
        private IRoleService _roleApp;
        private IRoleAuthorizeService _roleAuthorizeApp;
        private IModuleButtonService _moduleButtonApp;

        public RoleController(IRoleService roleApp, IRoleAuthorizeService roleAuthorizeApp,  IModuleButtonService moduleButtonApp) {
            _roleApp = roleApp;
            _roleAuthorizeApp = roleAuthorizeApp;
            _moduleButtonApp = moduleButtonApp;
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _roleApp.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _roleApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(Role roleEntity, string permissionIds, string keyValue)
        {
            _roleApp.SubmitForm(roleEntity, permissionIds.Split(','), keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _roleApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
