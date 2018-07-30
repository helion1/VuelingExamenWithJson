using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vueling.Facade.Api.Modules;

namespace Vueling.Facade.Api.App_Start {
    public class AutofacConfigure {
        public static IContainer Configure() {

            var builder = new ContainerBuilder();

            builder.RegisterModule(new WebApiModule());

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}