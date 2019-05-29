using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using StructureMap.Web;
using StructureMap;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain;
using Aghsat.ServiceLayer.Interface;
using Aghsat.ServiceLayer.Services;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aghsat.Ioc
{
    public class SchObjectFactory
    {
        #region Fields

        private static readonly Lazy<Container> ContainerBuilder = new Lazy<Container>(DefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion

        #region Properties

        public static IContainer Container
        {
            get { return ContainerBuilder.Value; }
        }
        #endregion


        public static Container DefaultContainer()
        {
            return new Container(ioc =>
            {
                ioc.Scan(x =>
                {
                    x.AssemblyContainingType<IApplicationUserManagerService>();
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });

                ioc.For<IIdentity>().Use(() => GetIdentity());
                ioc.For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use(() => new AghsatContext());

                ioc.For<AghsatContext>().HybridHttpOrThreadLocalScoped().Use(context => (AghsatContext)context.GetInstance<IUnitOfWork>());
                ioc.For<DbContext>().HybridHttpOrThreadLocalScoped().Use(context => (AghsatContext)context.GetInstance<IUnitOfWork>());

                ioc.For<IUserStore<User, int>>().HybridHttpOrThreadLocalScoped().Use<UserStore>();
                ioc.For<IRoleStore<Role, int>>().HybridHttpOrThreadLocalScoped().Use<RoleStore<Role, int, UserRole>>();

                ioc.For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);

                ioc.For<IApplicationSignInManagerServices>().HybridHttpOrThreadLocalScoped().Use<ApplicationSignInManagerService>();

                ioc.For<IApplicationRoleManagerService>().HybridHttpOrThreadLocalScoped().Use<ApplicationRoleManagerService>();
                ioc.For<IIdentityMessageService>().Use<SmsService>();
                ioc.For<IIdentityMessageService>().Use<EmailService>();
                ioc.For<IApplicationUserManagerService>().HybridHttpOrThreadLocalScoped().Use<ApplicationUserManagerService>()
                    .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
                    .Ctor<IIdentityMessageService>("emailService").Is<EmailService>()
                    .Setter(userManager => userManager.SmsService).Is<SmsService>()
                    .Setter(userManager => userManager.EmailService).Is<EmailService>();

                ioc.For<IRoleStore>().HybridHttpOrThreadLocalScoped().Use<RoleStore>();
                ioc.For<IUserStore>().HybridHttpOrThreadLocalScoped().Use<UserStore>();

            });
        }

        private static IIdentity GetIdentity()
        {
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                return HttpContext.Current.User.Identity;
            }

            return ClaimsPrincipal.Current != null ? ClaimsPrincipal.Current.Identity : null;
        }
    }
}