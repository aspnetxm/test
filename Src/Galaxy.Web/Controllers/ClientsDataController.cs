using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Galaxy.Service.SystemManage;
using Galaxy.Utility;
using Galaxy.Entity.SystemManage;

namespace Galaxy.Web.Controllers
{
    [HandlerLogin]
    public class ClientsDataController : Controller
    {
        private IItemsDetailService _itemsDetailService;
        private IItemsService _itemsService;
        private IOrganizeService _organizeService;
        private IRoleService _roleService;
        private IDutyService _dutyService;
        private IRoleAuthorizeService _roleAuthorizeService;
         

        public ClientsDataController(IItemsDetailService itemsDetailService, IItemsService itemsService, IOrganizeService organizeService, IRoleService roleService, IDutyService dutyService, IRoleAuthorizeService roleAuthorizeService)
        {
            _itemsDetailService = itemsDetailService;
            _itemsService = itemsService;
            _organizeService = organizeService;
            _roleService = roleService;
            _dutyService = dutyService;
            _roleAuthorizeService = roleAuthorizeService;
        }

        [HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                duty = this.GetDutyList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = this.GetMenuButtonList(),
            };
            return Content(data.ToJson());
        }
        private object GetDataItemList()
        {
            var itemdata =  _itemsDetailService.GetList();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            foreach (var item in _itemsService.GetList())
            {
                var dataItemList = itemdata.FindAll(t => t.ItemId.Equals(item.Id));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.ItemCode, itemList.ItemName);
                }
                dictionaryItem.Add(item.EnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }
        private object GetOrganizeList()
        {
            
            var data = _organizeService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Organize item in data)
            {
                var fieldItem = new
                {
                    encode = item.EnCode,
                    fullname = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }
        private object GetRoleList()
        {
            var data = _roleService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Role item in data)
            {
                var fieldItem = new
                {
                    encode = item.EnCode,
                    fullname = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }
        private object GetDutyList()
        {
            var data = _dutyService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Role item in data)
            {
                var fieldItem = new
                {
                    encode = item.EnCode,
                    fullname = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }
        private object GetMenuList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(_roleAuthorizeService.GetMenuList(roleId), "0");
        }
        private string ToMenuJson(List<Module> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<Module> entitys = data.FindAll(t => t.ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        private object GetMenuButtonList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            var data = _roleAuthorizeService.GetButtonList(roleId);
            var dataModuleId = data.Distinct(new ExtList<ModuleButton>("ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleButton item in dataModuleId)
            {
                var buttonList = data.Where(t => t.ModuleId.Equals(item.ModuleId));
                dictionary.Add(item.ModuleId, buttonList);
            }
            return dictionary;
        }
    }
}