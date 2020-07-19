using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SroDbTest.Data;
using SroDbTest.Data.Contexts;
using SroDbTest.Models;
using SroDbTest.Models.ViesModels;

namespace SroDbTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountDbContext _accountDbContext;
        private readonly ShardDbContext _shardDbContext;
        private readonly LogDbContext _logDbContext;
        private readonly PanelDbContext _panelDbContext;
        public HomeController(AccountDbContext accountDbContext, ShardDbContext shardDbContext, LogDbContext logDbContext, PanelDbContext panelDbContext)
        {
            _accountDbContext = accountDbContext;
            _shardDbContext = shardDbContext;
            _logDbContext = logDbContext;
            _panelDbContext = panelDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = new DatabasesViewModel()
            {
                panelNews = await _panelDbContext._news.ToListAsync(),

            };

            return View(result);
        }
    }
}
