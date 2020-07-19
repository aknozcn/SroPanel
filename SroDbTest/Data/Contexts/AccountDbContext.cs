using Microsoft.EntityFrameworkCore;
using SroDbTest.Models;
using SroDbTest.Models.AccountDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Data.Contexts
{
    public class AccountDbContext : DbContext
    {

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        
        }

        public DbSet<TB_User> TB_User { get; set; }

    }
}
