using Autofac;
using Autofac.Integration.WebApi;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Modules;
using Vueling.Application.Services.Service;
using Vueling.Common.Layer.Utils.Log4net;

namespace Vueling.Facade.Api.Modules {
    public class WebApiModule : Autofac.Module {

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

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