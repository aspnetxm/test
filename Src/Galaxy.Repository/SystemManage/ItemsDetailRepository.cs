/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;


namespace Galaxy.Repository.SystemManage
{
    public class ItemsDetailRepository : RepositoryBase<ItemsDetail>, IItemsDetailRepository
    {

        IUnitOfWork _unitOfWork;
        public ItemsDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ItemsDetail> GetItemList(string enCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  d.*
                            FROM    Sys_ItemsDetail d
                                    INNER  JOIN Sys_Items i ON i.Id = d.ItemId
                            WHERE   1 = 1
                                    AND i.EnCode = @enCode
                                    AND d.EnabledMark = 1
                                    AND d.DeleteMark = 0
                            ORDER BY d.SortCode ASC");
            DbParameter[] parameter = 
            {
                 new SqlParameter("@enCode",enCode)
            };
            return this.FindList(strSql.ToString(), parameter);
        }
    }
}
