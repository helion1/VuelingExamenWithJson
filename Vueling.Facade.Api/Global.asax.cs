using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vueling.Facade.Api.App_Start;
using Vueling.Facade.Api.Controllers;

namespace Vueling.Facade.Api {
    public class WebApiApplication : System.Web.HttpApplication {

        /*
        private HTTPApiController httpApiController;

        public WebApiApplication(HTTPApiController httpApiController) {
            this.httpApiController = httpApiController;
        }
        */

        protected async void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //httpApiController.InitBDAsync();
            log4net.Config.XmlConfigurator.Configure();
            AutofacConfigure.Configure();
        }
    }
}
