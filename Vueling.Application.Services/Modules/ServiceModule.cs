using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Service;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Modules;
using Vueling.Infrastructure.Repository.Repository;

namespace Vueling.Application.Services.Modules {
    public class ServiceModule : Autofac.Module {

        protected override void Load(ContainerBuilder builder) {
           
            builder
                .RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerDependency();

            builder
                .RegisterType<ClientService>()
                .As<IClientService>()
                .InstancePerDependency();

            builder
                .RegisterType<PolicyService>()
                .As<IPolicyService>()
                .InstancePerDependency();

            builder
                .RegisterType<PolicyRepository>()
                .As<IPolicyRepository>()
                .InstancePerDependency();

            builder
                .RegisterType<HttpClient>()
                .InstancePerDependency();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerDependency();

            builder.RegisterModule(new RepositoryModule());

            base.Load(builder);
        }
    }
}
