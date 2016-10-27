﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Domain.IRepository.SystemSecurity;
using Galaxy.Repository.SystemSecurity;
using Galaxy.Data;


namespace Galaxy.Application.SystemSecurity
{
    public class LogApp
    {
        private ILogRepository service = new LogRepository();

        public List<LogEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExt.True<LogEntity>();
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
            return service.FindList(expression, pagination);
        }
        public void RemoveLog(string keepTime)
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
            var expression = LinqExt.True<LogEntity>();
            expression = expression.And(t => t.Date <= operateTime);
            service.Delete(expression);
        }

        public void WriteLog(bool result, string resultLog, string ip)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Id = Common.GuId();
            logEntity.Date = DateTime.Now;
            logEntity.Account = OperatorProvider.Provider.GetCurrent().UserCode;
            logEntity.NickName = OperatorProvider.Provider.GetCurrent().UserName;
            //logEntity.IPAddress = Net.Ip;
            //logEntity.IPAddressName = Net.GetLocation(logEntity.IPAddress);
            logEntity.Result = result;
            logEntity.Description = resultLog;
            logEntity.Create();
            service.Insert(logEntity);
        }

        public void WriteLog(LogEntity logEntity)
        {
            logEntity.Id = Common.GuId();
            logEntity.Date = DateTime.Now;
            //logEntity.IPAddress = "117.81.192.182";
            //logEntity.IPAddressName = Net.GetLocation(logEntity.IPAddress);
            logEntity.Create();
            service.Insert(logEntity);
        }
    }
}
