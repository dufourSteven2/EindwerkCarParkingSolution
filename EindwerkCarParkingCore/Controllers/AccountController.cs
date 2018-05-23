using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EindwerkCarParkingCore.Data.Entities;
using EindwerkCarParkingCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EindwerkCarParkingCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ParkingUser> _signInManager;
        private readonly UserManager<ParkingUser> userManager;
        private readonly IConfiguration config;

        public AccountController(ILogger<AccountController> logger, SignInManager<ParkingUser> signInManager, 
            UserManager<ParkingUser> UserManager, IConfiguration config
            )
        {
            _logger = logger;
            _signInManager = signInManager;
            userManager = UserManager;
            this.config = config;
        }

        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,
                    model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else { }
                    RedirectToAction("Home", "Index");
                } 
            }
            ModelState.TryAddModelError("", "Failed to login");
            return View();
        }

        [HttpGet]
        public async Task <IActionResult> Logout()
        {
          await  _signInManager.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }


        //beveiliging van de api via een token
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result =await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        //create the token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            config["Tokens: Issuer"],

                            config["Tokens:Audience"],
                            claims, 
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: creds
                            );
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            experiation = token.ValidTo
                        };
                        return Created("", results);
                    }
                }
            }
            return BadRequest();
        }
    }
}