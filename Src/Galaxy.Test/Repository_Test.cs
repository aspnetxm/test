using System;
using System.Linq;
using Xunit;

using Galaxy.Repository.SystemManage;
using Galaxy.Entity.SystemManage;

namespace Galaxy.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Repository_Insert")]
        public void Test_Insert()
        {
            UserEntity user = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                Account = "admin",
                IsAdministrator = true,
                Email = "admin@gg.com",
                NickName = "内置管理员",
                RoleId = ""
            };
            user.Create("uid");
            var userRepository = new UserRepository();
            userRepository.Insert(user);

            var u = userRepository.FindEntity(user.Id);

            Assert.NotNull(u);
        }

        [Fact(DisplayName = "Repository_Update")]
        public void Test_Update()
        {

            var userRepository = new UserRepository();
            var u = userRepository.FindEntity(o => o.Account == "admin");

            u.RoleId = Guid.NewGuid().ToString();
            u.Modify("mid");
            userRepository.Update(u);

            var newu = userRepository.FindEntity(u.Id);
            Assert.True(u.RoleId == newu.RoleId);
        }

        [Fact(DisplayName = "Repository_Delete")]
        public void Test_Delete()
        {
            var userRepository = new UserRepository();
            var u = userRepository.FindEntity(o => o.Account == "admin");
            userRepository.Delete(u.Id);

            var newu = userRepository.FindEntity(u.Id);

            Assert.Equal(null, newu);
        }

    }
}
