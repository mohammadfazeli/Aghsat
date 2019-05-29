using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.ServiceLayer.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Aghsat.Domain;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.DataLayer;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace Aghsat.ServiceLayer.Services
{

    public class ApplicationSignInManagerService :
       SignInManager<User, int>,
        IApplicationSignInManagerServices
    {
         readonly IApplicationUserManagerService _userManager;
         readonly IAuthenticationManager _authenticationManager;

        public ApplicationSignInManagerService(
            IApplicationUserManagerService userManager,
            IAuthenticationManager authenticationManager) :
            base((ApplicationUserManagerService)userManager, authenticationManager)
        {
            _userManager = userManager;
            _authenticationManager = authenticationManager;            
        }
    
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return _userManager.GenerateUserIdentityAsync(user);
        }

        /// <summary>
        /// How to refresh authentication cookies
        /// </summary>
        public async Task RefreshSignInAsync(User user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            // await _userManager.UpdateSecurityStampAsync(user.Id).ConfigureAwait(false); // = used for SignOutEverywhere functionality
            var claimsIdentity = await _userManager.GenerateUserIdentityAsync(user).ConfigureAwait(false);
            _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, claimsIdentity);
        }
    }
}
    //public class ApplicationSignInManagerService : SignInManager<User, int>,  IApplicationSignInManagerServices
    //{
    //    #region Fields

    //     readonly ApplicationUserManagerService _userManager;
    //     readonly IAuthenticationManager _authenticationManager;

    //    #endregion

    //    #region Methods

    //    #region Constructors

        
    //    public ApplicationSignInManagerService(ApplicationUserManagerService userManager, IAuthenticationManager authenticationManager)
    //         :base(userManager, authenticationManager)
    //    {
    //        _userManager = userManager;
    //        _authenticationManager = authenticationManager;
    //    }

    //    #endregion

    //    #endregion
    //}

