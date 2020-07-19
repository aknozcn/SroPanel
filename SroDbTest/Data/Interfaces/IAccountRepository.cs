using SroDbTest.Models;
using SroDbTest.Models.AccountDb;
using SroDbTest.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task Add<T>(T entity) where T : class;
        Task<bool> AddAccount(TB_User user);
        Task<bool> LoginUser(LoginDTO user);
        Task<bool> CheckMemberOrAdmin(MemberOrAdminDTO user);
    }
}
