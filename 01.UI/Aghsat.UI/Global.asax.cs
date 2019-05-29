using Aghsat.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aghsat.ServiceLayer.Interface;
using Aghsat.Domain;
using AutoMapper;
using Aghsat.UI.App_Start;

namespace Aghsat.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetDbInitializer();
            //Set current Controller factory as StructureMapControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }
        static void SetDbInitializer()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataLayer.AghsatContext.AghsatContext, DataLayer.Migrations.Configuration>());

        }
    }



    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {

            if (controllerType == null)
            {
                throw new HttpException(404, $"Resource not found : {requestContext.HttpContext.Request.Path}");
            }
            return Ioc.SchObjectFactory.Container.GetInstance(controllerType) as Controller;
        }
    }
}
