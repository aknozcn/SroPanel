using Microsoft.EntityFrameworkCore;
using SroDbTest.CustomCryptography;
using SroDbTest.Data.Contexts;
using SroDbTest.Data.Interfaces;
using SroDbTest.Models;
using SroDbTest.Models.AccountDb;
using SroDbTest.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Data.Repositories
{
    public class AccountRepository<TEntity> : IAccountRepository where TEntity : DbContext
    {
        private readonly AccountDbContext _accountDbContext;

        public AccountRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task Add<T>(T entity) where T : class
        {
            _accountDbContext.Set<T>().Add(entity);
            await _accountDbContext.SaveChangesAsync();
        }

        public async Task<bool> AddAccount(TB_User user)
        {
            var dbUser = await _accountDbContext.TB_User.SingleOrDefaultAsync(u => u.StrUserID == user.StrUserID || u.Email == user.Email);
            if (dbUser == null)
            {
                _accountDbContext.Set<TB_User>().Add(user);
                await _accountDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> LoginUser(LoginDTO user)
        {
            var dbUser = await _accountDbContext.TB_User.SingleOrDefaultAsync(u => u.StrUserID == user.StrUserID && u.password == user.password);
            if (dbUser != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckMemberOrAdmin(MemberOrAdminDTO user)
        {
            var isAdmin = await _accountDbContext.TB_User.SingleOrDefaultAsync(u => u.StrUserID == user.StrUserID && u.sec_primary == 1 && u.sec_content == 1);
            if (isAdmin != null)
            {
                return true;
            }
            return false;
        }
    }
}
