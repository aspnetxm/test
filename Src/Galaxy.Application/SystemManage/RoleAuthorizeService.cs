/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Galaxy.Utility;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Repository.SystemManage;
using Galaxy.Entity.SystemManage;
using Galaxy.Data.Infrastructure;
using Galaxy.DTO.SystemManage;


namespace Galaxy.Service.SystemManage
{
    public class RoleAuthorizeService: IRoleAuthorizeService
    {
        private IUnitOfWork _unitOfWork;
        private IRoleAuthorizeRepository _roleAuthorizeRepository;
        private ModuleService _moduleApp;
        private ModuleButtonService _moduleButtonApp;

        public RoleAuthorizeService()
        {
            _unitOfWork = new UnitOfWork();
            _roleAuthorizeRepository = new RoleAuthorizeRepository(_unitOfWork);
            _moduleApp = new ModuleService(_unitOfWork, new ModuleRepository(_unitOfWork));
            _moduleButtonApp = new ModuleButtonService(_unitOfWork, new ModuleButtonRepository(_unitOfWork));
        }

        public RoleAuthorizeService(IUnitOfWork unitOfWork, IRoleAuthorizeRepository roleAuthorizeRepository, IModuleButtonRepository moduleButtonRepository, IModuleRepository moduleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleAuthorizeRepository = roleAuthorizeRepository;
            _moduleApp = new ModuleService(_unitOfWork, moduleRepository);
            _moduleButtonApp = new ModuleButtonService(_unitOfWork, moduleButtonRepository);
        }

        public List<RoleAuthorize> GetList(string ObjectId)
        {
            return _roleAuthorizeRepository.IQueryable(t => t.ObjectId == ObjectId).ToList();
        }

        public List<Module> GetMenuList(string roleId)
        {
            var data = new List<Module>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = _moduleApp.GetList();
            }
            else
            {
                var moduledata = _moduleApp.GetList();
                var authorizedata = _roleAuthorizeRepository.IQueryable(t => t.ObjectId == roleId && t.ItemType == 1).ToList();
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
                data = _moduleButtonApp.GetList();
            }
            else
            {
                var buttondata = _moduleButtonApp.GetList();
                var authorizedata = _roleAuthorizeRepository.IQueryable(t => t.ObjectId == roleId && t.ItemType == 2).ToList();
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
            var authorizeurldata = new List<AuthorizeActionDTO>();
            var cachedata = CacheFactory.Cache().Get<List<AuthorizeActionDTO>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata = _moduleApp.GetList();
                var buttondata = _moduleButtonApp.GetList();
                var authorizedata = _roleAuthorizeRepository.IQueryable(t => t.ObjectId == roleId).ToList();
                foreach (var item in authorizedata)
                {
                    if (item.ItemType == 1)
                    {
                        Module moduleEntity = moduledata.Find(t => t.Id == item.ItemId);
                        authorizeurldata.Add(new AuthorizeActionDTO { Id = moduleEntity.Id, UrlAddress = moduleEntity.UrlAddress });
                    }
                    else if (item.ItemType == 2)
                    {
                        ModuleButton moduleButtonEntity = buttondata.Find(t => t.Id == item.ItemId);
                        authorizeurldata.Add(new AuthorizeActionDTO { Id = moduleButtonEntity.ModuleId, UrlAddress = moduleButtonEntity.UrlAddress });
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
