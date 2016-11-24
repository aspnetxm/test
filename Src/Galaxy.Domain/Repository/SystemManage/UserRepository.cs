/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public void Delete(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<User>(t => t.Id == keyValue);
                db.Delete<UserLogOn>(t => t.UserId == keyValue);
                db.Commit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="userLogOnEntity"></param>
        public void Update(User userEntity, UserLogOn userLogOnEntity)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Update(userEntity);
                db.Update(userLogOnEntity);
                db.Commit();
            }
        }


        public void Insert(User userEntity, UserLogOn userLogOnEntity)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                userLogOnEntity.Id = userEntity.Id;
                userLogOnEntity.UserId = userEntity.Id;
                userLogOnEntity.UserSecretkey = Md5Encrypt.Md5(Common.CreateNo(), 16).ToLower();
                userLogOnEntity.UserPassword = Md5Encrypt.Md5(AES.Encrypt(Md5Encrypt.Md5(userLogOnEntity.UserPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
                db.Insert(userEntity);
                db.Insert(userLogOnEntity);
                db.Commit();
            }
        }
    }
}
