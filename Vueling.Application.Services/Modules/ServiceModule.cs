using Autofac;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            //builder.RegisterModule(new RepositoryModule());

            base.Load(builder);
        }
    }
}
