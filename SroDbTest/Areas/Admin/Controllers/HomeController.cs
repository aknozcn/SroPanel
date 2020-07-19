using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SroDbTest.Models.AccountDb;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using SroDbTest.Models;
using SroDbTest.CustomCryptography;
using SroDbTest.Data.Interfaces;
using SroDbTest.Models.DTOs;

namespace SroDbTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public readonly IAuthorizationService _authorizationService;

        public HomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            if ((await _authorizationService.AuthorizeAsync(User, "Admin")).Succeeded)
            {
                return View();
            }

            return View("Login");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");

        }
    }
}
