using Microsoft.EntityFrameworkCore;
using SroDbTest.Models.PanelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Data.Contexts
{
    public class PanelDbContext:DbContext
    {
        public PanelDbContext(DbContextOptions<PanelDbContext> options) : base(options)
        {

        }

        public DbSet<_news> _news { get; set; }

    }
}
