using Microsoft.EntityFrameworkCore;
using SroDbTest.Models.ShardDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Data.Contexts
{
    public class ShardDbContext : DbContext
    {
        public ShardDbContext(DbContextOptions<ShardDbContext> options) : base(options)
        {

        }

        public DbSet<_Char> _Char { get; set; }

    }
}
