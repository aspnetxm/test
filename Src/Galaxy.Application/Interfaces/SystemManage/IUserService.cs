using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Domain.Dto;

namespace Galaxy.Application.Interfaces.SystemManage
{
    public interface IUserService
    {
        Task<UserVerifyResult> Verification(string username, string password);
    }
}
