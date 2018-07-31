using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .RegisterType<ClientService>()
                .As<IClientService>()
                .InstancePerRequest();

            builder
               .RegisterType<PolicyService>()
               .As<IPolicyService>()
               .InstancePerRequest();

            builder
                .RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<PolicyRepository>()
                .As<IPolicyRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new RepositoryModule());

            base.Load(builder);
        }
    }
}
