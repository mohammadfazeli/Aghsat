using Aghsat.DataLayer.AghsatContext;
using Aghsat.ServiceLayer.Interface;
using Aghsat.ServiceLayer.Services;
using Aghsat.ViewModel.Account;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aghsat.Domain;
using System.Net;
using Aghsat.UI.Classes.Attributes;
using Microsoft.AspNet.Identity;

namespace Aghsat.UI.Controllers
{
    public partial class AccountController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IApplicationSignInManagerServices _signInManager;
        private readonly IApplicationUserManagerService _userManager;
        private readonly IApplicationRoleManagerService _roleManager;



        public AccountController(IUnitOfWork uow,
                                 IAuthenticationManager authenticationManager,
                                 IApplicationSignInManagerServices signInManager,
                                 IApplicationUserManagerService userManager,
                                 IApplicationRoleManagerService RoleManager)
        {
            _uow = uow;
            _authenticationManager = authenticationManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = RoleManager;


        }
        // GET: Account
        public virtual ActionResult Index()
        {
            return View();

        }
        public virtual ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction(MVC.Home.Index());
        }

        [HttpGet]
        [Title(" ورود به سایت")]
        [Icone("fa fa-sign-in")]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(Login_ViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // NOTE: You must add your claims **before** sign the user in.
            // At the end of its execution chain SignInManager.PasswordSignInAsync method calls for SignInAsync method
            // which is basically responsible for setting an authentication cookie which contains multiple claims about
            // a user (one of them is its name).

            // This doesn't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false).ConfigureAwait(false);
            switch (result)
            {
                case SignInStatus.Success:
                    return _roleManager.IsUserInRole(int.Parse(User.Identity.GetUserId()), "Admin") ? RedirectToAction(MVC.Admin.VehicleManagment.Index()) : redirectToLocal(returnUrl);

                //return redirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }

        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        [Title(" ثبت نام")]
        [Icone("\tfa fa-registered")]
        public virtual ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(Register_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Aghsat.Domain.User { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id).ConfigureAwait(false);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                    await _userManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>").ConfigureAwait(false);
                    ViewBag.Link = callbackUrl;
                    return View("DisplayEmail");
                }
                //addErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        private ActionResult redirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}