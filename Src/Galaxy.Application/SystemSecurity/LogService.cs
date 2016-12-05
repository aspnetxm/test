/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Galaxy.Utility;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Repository.Infrastructure;
using Galaxy.Repository.Interface.SystemSecurity;
using Galaxy.DTO.CommonModule;


namespace Galaxy.Service.SystemSecurity
{
    public class LogService
    {
        private IUnitOfWork _unitOfWork;
        private ILogRepository _logRepository;

        public LogService(IUnitOfWork unitOfWork, ILogRepository logRepository)
        {
            _unitOfWork = unitOfWork;
            _logRepository = logRepository;
        }

        public List<OprLog> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExt.True<OprLog>();
            var queryParam = queryJson.ToObject();
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();
                expression = expression.And(t => t.Account.Contains(keyword));
            }
            if (!queryParam["timeType"].IsEmpty())
            {
                string timeType = queryParam["timeType"].ToString();
                DateTime startTime = DateTime.Today;
                DateTime endTime = DateTime.Today.AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                expression = expression.And(t => t.Date >= startTime && t.Date <= endTime);
            }
            return _logRepository.FindList(expression, pagination);
        }

        public async Task RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            var expression = LinqExt.True<OprLog>();
            expression = expression.And(t => t.Date <= operateTime);
            await _unitOfWork.DeleteAsync<OprLog>(expression);
            await _unitOfWork.CommitAsync();
        }

        public async Task WriteLog(bool result, string resultLog, string ip)
        {
            OprLog logEntity = new OprLog();
            logEntity.Id = Common.GuId();
            logEntity.Date = DateTime.Now;
            logEntity.Account = OperatorProvider.Provider.GetCurrent().UserCode;
            logEntity.NickName = OperatorProvider.Provider.GetCurrent().UserName;
            //logEntity.IPAddress = Net.Ip;
            //logEntity.IPAddressName = Net.GetLocation(logEntity.IPAddress);
            logEntity.Result = result;
            logEntity.Description = resultLog;
            logEntity.Create();
            await _unitOfWork.InsertAsync<OprLog>(logEntity);
        }

        public async Task WriteLog(OprLog logEntity)
        {
            logEntity.Id = Common.GuId();
            logEntity.Date = DateTime.Now;
            //logEntity.IPAddress = "117.81.192.182";
            //logEntity.IPAddressName = Net.GetLocation(logEntity.IPAddress);
            logEntity.Create();
            await _unitOfWork.InsertAsync<OprLog>(logEntity);
        }
    }
}
