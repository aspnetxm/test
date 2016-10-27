using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Application.Service
{
    public interface IUserService
    {
        Task<UserEntity> Login(string username, string password);
    }
}
