using System;
using System.Linq;
using System.Threading.Tasks;
using EindwerkCarParkingCore.extensions;
using EindwerkCarParkingCore.Services;
using EindwerkCarParkingCore.ViewModels;
using EindwerkCarParkingLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EindwerkCarParkingCore.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ParkingUsers> _signInManager;
        private readonly UserManager<ParkingUsers> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountController( SignInManager<ParkingUsers> signInManager, 
            UserManager<ParkingUsers> UserManager ,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
                     _signInManager = signInManager;
            _userManager = UserManager;
           _emailSender = emailSender;
            _logger = logger;
        }
        [HttpGet]
     //   [AllowAnonymous]
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Overzicht", "MyAccount");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,
                    model.RememberMe, false);

                // controle of de user het emailadres al bevestigd heeft, zoniet dit melden en een nieuwe mail sturen 
                var user = await _userManager.FindByEmailAsync(model.Username); bool isEmailconfirmed = await _userManager.IsEmailConfirmedAsync(user);
                if (!isEmailconfirmed)
                {
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user, "Confirm your account-Resend"); ViewBag.Message = "You must have a confirmed email to log on."; return View("Error");
                }

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }


                    else { RedirectToAction("Overzicht", "MyAccount"); }
                    
                }
                else
                {
                     ModelState.TryAddModelError("", "Failed to login");
                }

            }
            if (this.User.IsInRole("Admin"))
            {
                return RedirectToAction("Overzicht", "AdminController");
            }
            else
            return RedirectToAction("Overzicht", "MyAccount");
        }

        [HttpGet]
        public async Task <IActionResult> Logout()
        {
          await  _signInManager.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl =
        null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ParkingUsers
                {
                    EigenaarNaam = model.EigenaarNaam,
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    //  var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //  var callbackUrl = Url.EmailConfirmationLink(user.Id, code,
                    // Request.Scheme);
                    //   await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    string callbackUrl = await SendEmailConfirmationTokenAsync(user, "Confirm your account");
                    // onderstaande lijn in comment
                    // niet automatisch inloggen na registreren
                    // we vereisen emailconfirmatie
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    // uitcommentariëren
                    // standaard niet de startpagina tonen na registratie
                    //return RedirectToLocal(returnUrl);
                    // We voorzien een View met een melding
                    // dat een confirmatiemail werd verstuurd
                    ViewBag.Message = "Check your email and confirm your account "
                    + "you must be confirmed "
                    + "before you can log in.";
                    return View("Info");
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private async Task<string> SendEmailConfirmationTokenAsync(ParkingUsers user, string subject)
        {
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
            new { userId = user.Id, code = code }, protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, subject,
            "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>"
            );
            return callbackUrl;
        }
        #endregion
    }
}
