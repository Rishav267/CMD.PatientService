using CMD.PatientService.Data.Repositories;
using CMD.PatientService.Domain.Managers;
using CMD.PatientService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace PatientWebAPIServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IManager, Manager>();
            unityContainer.RegisterType<IPatientRepository, PatientRepository>();
        }
    }
}
