using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Moq;


using Galaxy.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Utility;
using Galaxy.Service.SystemManage;

namespace Galaxy.Test
{
    public class UnitTest1
    {

        [Fact(DisplayName = "Repository_Insert")]
        public void Test_Insert()
        {
            //User user = new User
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Account = "admin",
            //    IsAdministrator = true,
            //    Email = "admin@gg.com",
            //    NickName = "内置管理员",
            //    RoleId = ""
            //};
            //user.Create("uid");
            //UserLogOn userLogOn = new UserLogOn
            //{
            //    Id = user.Id,
            //    UserId = user.Id,
            //    LogOnCount = 0,
            //    UserPassword = Md5Encrypt.Md5(AES.Encrypt("123456", "1234567891234567").ToLower(), 32).ToLower(),
            //    UserSecretkey = "1234567891234567"
            //};

            //var mock = new Mock<IUserRepository>();
            //mock.Setup(o => o.Get(user.Id)).Returns(user);


            var mockClubRepository = new Mock<IUserRepository>();

            mockClubRepository.Setup(mr => mr.Get(It.IsAny<Guid>()));







            //Assert.NotNull(u);
        }

        //[Fact(DisplayName = "Repository_Update")]
        //public void Test_Update()
        //{
        //    var u = _userRepository.Get(o => o.Account == "admin");
        //    u.RoleId = Guid.NewGuid().ToString();
        //    u.Modify("mid");
        //    _userRepository.UpdateAsync(u);

        //    var newu = _userRepository.Get(u.Id);
        //    Assert.True(u.RoleId == newu.RoleId);
        //}

        //[Fact(DisplayName = "Repository_Delete")]
        //public void Test_Delete()
        //{

        //    var u = _userRepository.Get(o => o.Account == "admin");
        //    _userRepository.DeleteAsync(u.Id);

        //    var newu = _userRepository.Get(u.Id);

        //    Assert.Equal(null, newu);
        //}
    }
}
