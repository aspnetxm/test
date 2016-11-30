/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Data;
using Galaxy.Service.Interfaces;


namespace Galaxy.Service.SystemManage
{
    public class AreaService : IAreaService
    {
        private IAreaRepository _areaRepository;
        private IUnitOfWork _unitOfWork;

        public AreaService(IUnitOfWork unitOfWork, IAreaRepository areaRepository)
        {
            _unitOfWork = unitOfWork;
            _areaRepository = areaRepository;
        }

        public List<Area> GetList()
        {
            return _areaRepository.IQueryable().ToList();
        }
        public async Task<Area> GetForm(string keyValue)
        {
            return await _areaRepository.GetAsync(keyValue);
        }
        public async Task DeleteForm(string keyValue)
        {
            if (_areaRepository.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                await _unitOfWork.DeleteAsync<Area>(t => t.Id == keyValue);
                await _unitOfWork.CommitAsync();
            }
        }
        public void SubmitForm(Area areaEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                areaEntity.Modify(keyValue);
                _unitOfWork.Update(areaEntity);
            }
            else
            {
                areaEntity.Create();
                _unitOfWork.Insert(areaEntity);
            }
        }
    }
}
