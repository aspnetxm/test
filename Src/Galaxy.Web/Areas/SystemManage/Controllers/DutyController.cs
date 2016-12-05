/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Service.SystemManage;
using Galaxy.Utility;
using Galaxy.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Galaxy.Web.Areas.SystemManage.Controllers
{
    public class DutyController : ControllerBase
    {
        private IDutyService _dutyApp;

        public DutyController(IDutyService dutyApp) {
            _dutyApp = dutyApp;
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _dutyApp.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _dutyApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(Role roleEntity, string keyValue)
        {
            _dutyApp.SubmitForm(roleEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _dutyApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
