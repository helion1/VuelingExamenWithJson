using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Modules;
using Vueling.Application.Services.Service;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;
using Vueling.Facade.Api.Controllers;

namespace Vueling.Facade.Api.Modules {
    public class WebApiModule : Autofac.Module {

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<HTTPApiController>()
                .InstancePerRequest();


            builder
                .RegisterType<HTTPService>()
                .As<IHTTPService>()
                .InstancePerRequest();


            builder
                .RegisterType<ClientService>()
                .As<IClientService>()
                .InstancePerRequest();

            builder
               .RegisterType<PolicyService>()
               .As<IPolicyService>()
               .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new ServiceModule());

            base.Load(builder);
        }
    }
}