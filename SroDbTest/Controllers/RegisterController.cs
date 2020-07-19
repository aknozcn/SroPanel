using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Newtonsoft.Json;
using SroDbTest.CustomCaptcha;
using SroDbTest.CustomCryptography;
using SroDbTest.Data.Contexts;
using SroDbTest.Data.Interfaces;
using SroDbTest.Models;
using SroDbTest.Models.AccountDb;
using SroDbTest.Models.DTOs;
using SroDbTest.Models.ViesModels;

namespace SroDbTest.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public readonly IAuthorizationService _authorizationService;

        public RegisterController(IAccountRepository accountRepository, IAuthorizationService authorizationService)
        {
            _accountRepository = accountRepository;
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> Index()
        {
            if ((await _authorizationService.AuthorizeAsync(User, "Admin")).Succeeded)
            {
                return NotFound(); // if alredy login, then cant see this page
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO model)
        {
            var response = HttpContext.Request.Form["g-recaptcha-response"];
            const string secret = "6Lc8AbAZAAAAAKWccCm-GDX3zEgCrzLPgLx1dtSR";

            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            if (ModelState.IsValid)
            {
                if (!captchaResponse.Success)
                    ModelState.AddModelError("", "Lütfen güvenliği doğrulayınız");
                else
                {
                    var result = new TB_User
                    {
                        StrUserID = model.StrUserID,
                        password = MD5.Create(model.password),
                        Email = model.Email,
                        address = model.address,
                        sec_primary = 3,
                        sec_content = 3
                    };
                    if (await _accountRepository.AddAccount(result))
                    {
                        TempData["Success"] = "Başarılı bir şekilde kayıt olundu";
                    }
                    else
                    {
                        TempData["Fail"] = "Girmeye çalıştığınız Kullanıcı Adı veya Email zaten sistemde bulunmakta.";
                    }

                }
            }

            return View(model);
        }

    }
}
