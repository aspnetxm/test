/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Utility;
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Repository.Interface.SystemSecurity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Service.SystemSecurity
{
    public class FilterIPService
    {
        private IFilterIPRepository _filterIPRepository;
        private IUnitOfWork _unitOfWork;

        public FilterIPService(IUnitOfWork unitOfWork, IFilterIPRepository filterIPRepository)
        {
            _unitOfWork = unitOfWork;
            _filterIPRepository = filterIPRepository;
        }

        public List<FilterIP> GetList(string keyword)
        {
            var expression = LinqExt.True<FilterIP>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.StartIP.Contains(keyword));
            }
            return _filterIPRepository.IQueryable(expression).OrderByDescending(t => t.DeleteTime).ToList();
        }

        public async Task<FilterIP> GetForm(string keyValue)
        {
            return await _filterIPRepository.GetAsync(keyValue);
        }
        public async Task DeleteForm(string keyValue)
        {
            await _unitOfWork.DeleteAsync<FilterIP>(t => t.Id == keyValue);
            await _unitOfWork.CommitAsync();
        }
        public async Task SubmitForm(FilterIP filterIPEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIPEntity.Modify();
                await _unitOfWork.UpdateAsync<FilterIP>(filterIPEntity);
            }
            else
            {
                filterIPEntity.Create();
                await _unitOfWork.InsertAsync<FilterIP>(filterIPEntity);
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
