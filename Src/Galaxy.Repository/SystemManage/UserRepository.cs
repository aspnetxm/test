/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }


        //public async Task DeleteAsync(string keyValue)
        //{
        //    _uk.BeginTransaction();
        //    await _uk.DeleteAsync<User>(o => o.Id == keyValue);
        //    await _uk.DeleteAsync<UserLogOn>(o => o.UserId == keyValue);
        //    await _uk.CommitAsync();
        //}

        //public async Task UpdateAsync(User user, UserLogOn userLogOn)
        //{
        //    _uk.BeginTransaction();
        //    await _uk.UpdateAsync<User>(user);
        //    await _uk.UpdateAsync<UserLogOn>(userLogOn);
        //    await _uk.CommitAsync();
        //}

        //public async Task InsertAsync(User user, UserLogOn userLogOn)
        //{
        //    userLogOn.Id = user.Id;
        //    userLogOn.UserId = user.Id;
        //    userLogOn.UserSecretkey = Md5Encrypt.Md5(Common.CreateNo(), 16).ToLower();
        //    userLogOn.UserPassword = Md5Encrypt.Md5(AES.Encrypt(Md5Encrypt.Md5(userLogOn.UserPassword, 32).ToLower(), userLogOn.UserSecretkey).ToLower(), 32).ToLower();

        //    _uk.BeginTransaction();
        //    await _uk.InsertAsync<User>(user);
        //    await _uk.InsertAsync<UserLogOn>(userLogOn);
        //    await _uk.CommitAsync();
        //}

    }
}