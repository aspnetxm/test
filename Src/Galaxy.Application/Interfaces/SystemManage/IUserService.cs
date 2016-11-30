using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Domain.Dto;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Data;

namespace Galaxy.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserVerifyResult> Verification(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<User>> GetList(Pagination pagination, string keyword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<User> GetById(string keyValue);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        Task DeleteById(string keyValue);

        /// <summary>
        /// 添加或更新
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task SubmitForm(User userEntity, UserLogOn userLogOnEntity, string keyValue);

    }
}
