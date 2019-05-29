namespace Aghsat.UI.App_Start
{
    public partial class Startup
    {
         
        //public  void ConfigureAuth(IAppBuilder App)
        //{
        //    SchObjectFactory.Container.Configure(config =>
        //    {
        //        config.For<IDataProtectionProvider>().HybridHttpOrThreadLocalScoped().Use(() => App.GetDataProtectionProvider());
        //    });

        //    App.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Account/Login"),
        //        Provider = new CookieAuthenticationProvider
        //        {
        //            OnValidateIdentity = SchObjectFactory.Container.GetInstance<IApplicationUserManagerService>().OnValidateIdentity()

        //        },
        //        SlidingExpiration = true,
        //        CookieName = "SevenSystem_Account",
        //        ExpireTimeSpan = TimeSpan.FromMinutes(720)
        //    });
        //    App.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        //    // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
        //    App.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

        //    // Enables the application to remember the second login verification factor such as phone or email.
        //    // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
        //    // This is similar to the RememberMe option when you log in.
        //    App.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

        //    // Uncomment the following lines to enable logging in with third party login providers
        //    //app.UseMicrosoftAccountAuthentication(
        //    //    clientId: "",
        //    //    clientSecret: "");

        //    //app.UseTwitterAuthentication(
        //    //   consumerKey: "",
        //    //   consumerSecret: "");

        //    //app.UseFacebookAuthentication(
        //    //   appId: "",
        //    //   appSecret: "");

        //    //App.UseGoogleAuthentication(
        //    //    clientId: "982425694530-hh13d40ptl6gnn8njosoa4128munuh4h.apps.googleusercontent.com",
        //    //    clientSecret: "xfdmd2Zw_15QJCwPmh8cqvOO");

        //}
    }
}