using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;

using Galaxy.Repository.SystemManage;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Data;

namespace Galaxy.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Repository_Insert")]
        public void Test_Insert()
        {
            User user = new User
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

            var u = userRepository.Get(user.Id);

            Assert.NotNull(u);
        }

        [Fact(DisplayName = "Repository_Update")]
        public void Test_Update()
        {

            var userRepository = new UserRepository();
            var u = userRepository.Get(o => o.Account == "admin");

            u.RoleId = Guid.NewGuid().ToString();
            u.Modify("mid");
            userRepository.Update(u);

            var newu = userRepository.Get(u.Id);
            Assert.True(u.RoleId == newu.RoleId);
        }

        [Fact(DisplayName = "Repository_Delete")]
        public void Test_Delete()
        {
            var userRepository = new UserRepository();
            var u = userRepository.Get(o => o.Account == "admin");
            userRepository.Delete(u.Id);

            var newu = userRepository.Get(u.Id);

            Assert.Equal(null, newu);
        }

        [Fact]
        public void TR_Test()
        {
           var t= new Task(() =>
            {
                using (var rb = new RepositoryBase().BeginTrans())
                {
                    User ue = rb.FindEntity<User>("60c36787-4b75-4ff1-8c0e-fdef76fc7ffc");
                    ue.ManagerId = "aaaa";
                    rb.Update<User>(ue);
                    //Thread.Sleep(5000);
                    rb.Commit();
                    Console.WriteLine("aa");
                   
                }
            });
            t.Start();

            new Task(() =>
            {
                using (var rb = new RepositoryBase().BeginTrans())
                {
                    User ue = rb.FindEntity<User>("60c36787-4b75-4ff1-8c0e-fdef76fc7ffc");
                    rb.Delete<User>(ue);
                    Thread.Sleep(3000);
                    rb.Commit();
                    Console.WriteLine("bb");
                }
            }).Start();



            Console.WriteLine("ok");
        }
    }
}
