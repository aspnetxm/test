using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entity.SystemManage;

namespace Galaxy.Application.Service
{
    public interface IUserService
    {
        Task<R<UserEntity>> Login(string username, string password);
    }
}
