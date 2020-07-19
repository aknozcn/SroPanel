using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SroDbTest.CustomCaptcha;
using SroDbTest.CustomCryptography;
using SroDbTest.Data.Contexts;
using SroDbTest.Data.Interfaces;
using SroDbTest.Models;
using SroDbTest.Models.AccountDb;
using SroDbTest.Models.DTOs;

namespace SroDbTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {


            var result = new LoginDTO
            {
                StrUserID = loginDTO.StrUserID,
                password = MD5.Create(loginDTO.password)
            };

            var isAdmin = new MemberOrAdminDTO
            {
                StrUserID = loginDTO.StrUserID,
                sec_primary = 1,
                sec_content = 1
            };

            if (await _accountRepository.CheckMemberOrAdmin(isAdmin))
            {
                if (await _accountRepository.LoginUser(result))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDTO.StrUserID),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
            }

            else
            {
                if (await _accountRepository.LoginUser(result))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDTO.StrUserID),
                    new Claim(ClaimTypes.Role, "Member")
                };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);



                    return RedirectToAction("Index", "Home", new { Area = "Member"});
                }
            }

            return View(loginDTO);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
