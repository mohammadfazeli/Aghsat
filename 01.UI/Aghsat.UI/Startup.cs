using Aghsat.ServiceLayer.Interface;
using Aghsat.ServiceLayer.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Optimization;
using Aghsat.Ioc;
using StructureMap.Web;

namespace Aghsat.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder App)
        {
            ConfigureAuth(App);
        }

        public void ConfigureAuth(IAppBuilder App)
        {
            SchObjectFactory.Container.Configure(config =>
            {
                config.For<IDataProtectionProvider>().HybridHttpOrThreadLocalScoped()
                .Use(() => App.GetDataProtectionProvider());
            });


            // This is necessary for `GenerateUserIdentityAsync` and `SecurityStampValidator` to work internally by ASP.NET Identity 2.x
            App.CreatePerOwinContext(createCallback: () => (ApplicationUserManagerService)SchObjectFactory.Container.GetInstance<IApplicationUserManagerService>());

            App.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString(value: "/Account/Login"),
                //Provider = new CookieAuthenticationProvider
                //{
                //    OnValidateIdentity = SchObjectFactory.Container.GetInstance<().OnValidateIdentity()

                //},
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.
                    OnValidateIdentity = context =>
                    {
                        if (shouldIgnoreRequest(context: context)) // How to ignore Authentication Validations for static files in ASP.NET Identity
                        {
                            return Task.FromResult(result: 0);
                        }
                        return SchObjectFactory.Container.GetInstance<IApplicationUserManagerService>().OnValidateIdentity().Invoke(context);
                    }
                },
                SlidingExpiration = true,
                CookieName = "__Aghsat_Account",
                ExpireTimeSpan = TimeSpan.FromMinutes(value: 720)
            });
            App.UseExternalSignInCookie(externalAuthenticationType: DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            App.UseTwoFactorSignInCookie(authenticationType: DefaultAuthenticationTypes.TwoFactorCookie, expires: TimeSpan.FromMinutes(value: 5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            App.UseTwoFactorRememberBrowserCookie(authenticationType: DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //App.UseGoogleAuthentication(
            //    clientId: "982425694530-hh13d40ptl6gnn8njosoa4128munuh4h.apps.googleusercontent.com",
            //    clientSecret: "xfdmd2Zw_15QJCwPmh8cqvOO");

        }

        private static bool shouldIgnoreRequest(CookieValidateIdentityContext context)
        {
            string[] reservedPath =
            {
                "/__browserLink",
                "/img",
                "/fonts",
                "/Scripts",
                "/Content",
                "/Uploads",
                "/Images"
            };
            return reservedPath.Any(path => context.OwinContext.Request.Path.Value.StartsWith(path, StringComparison.OrdinalIgnoreCase)) ||
                               BundleTable.Bundles.Select(bundle => bundle.Path.TrimStart('~')).Any(bundlePath => context.OwinContext.Request.Path.Value.StartsWith(bundlePath, StringComparison.OrdinalIgnoreCase));
        }

    }
}