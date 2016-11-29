/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Galaxy.Code;
using Galaxy.Domain.Dto;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public class RoleAuthorizeApp
    {
        private IRoleAuthorizeRepository service = new RoleAuthorizeRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<RoleAuthorize> GetList(string ObjectId)
        {
            return service.IQueryable(t => t.ObjectId == ObjectId).ToList();
        }
        public List<Module> GetMenuList(string roleId)
        {
            var data = new List<Module>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = moduleApp.GetList();
            }
            else
            {
                var moduledata = moduleApp.GetList();
                var authorizedata = service.IQueryable(t => t.ObjectId == roleId && t.ItemType == 1).ToList();
                foreach (var item in authorizedata)
                {
                    Module moduleEntity = moduledata.Find(t => t.Id == item.ItemId);
                    if (moduleEntity != null)
                    {
                        data.Add(moduleEntity);
                    }
                }
            }
            return data.OrderBy(t => t.SortCode).ToList();
        }
        public List<ModuleButton> GetButtonList(string roleId)
        {
            var data = new List<ModuleButton>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = moduleButtonApp.GetList();
            }
            else
            {
                var buttondata = moduleButtonApp.GetList();
                var authorizedata = service.IQueryable(t => t.ObjectId == roleId && t.ItemType == 2).ToList();
                foreach (var item in authorizedata)
                {
                    ModuleButton moduleButtonEntity = buttondata.Find(t => t.Id == item.ItemId);
                    if (moduleButtonEntity != null)
                    {
                        data.Add(moduleButtonEntity);
                    }
                }
            }
            return data.OrderBy(t => t.SortCode).ToList();
        }
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            var authorizeurldata = new List<AuthorizeAction>();
            var cachedata = CacheFactory.Cache().Get<List<AuthorizeAction>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata = moduleApp.GetList();
                var buttondata = moduleButtonApp.GetList();
                var authorizedata = service.IQueryable(t => t.ObjectId == roleId).ToList();
                foreach (var item in authorizedata)
                {
                    if (item.ItemType == 1)
                    {
                        Module moduleEntity = moduledata.Find(t => t.Id == item.ItemId);
                        authorizeurldata.Add(new AuthorizeAction { Id = moduleEntity.Id, UrlAddress = moduleEntity.UrlAddress });
                    }
                    else if (item.ItemType == 2)
                    {
                        ModuleButton moduleButtonEntity = buttondata.Find(t => t.Id == item.ItemId);
                        authorizeurldata.Add(new AuthorizeAction { Id = moduleButtonEntity.ModuleId, UrlAddress = moduleButtonEntity.UrlAddress });
                    }
                }
                CacheFactory.Cache().Set("authorizeurldata_" + roleId, authorizeurldata, 5);
            }
            else
            {
                authorizeurldata = cachedata;
            }
            authorizeurldata = authorizeurldata.FindAll(t => t.Id.Equals(moduleId));
            foreach (var item in authorizeurldata)
            {
                if (!string.IsNullOrEmpty(item.UrlAddress))
                {
                    string[] url = item.UrlAddress.Split('?');
                    if (item.Id == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
