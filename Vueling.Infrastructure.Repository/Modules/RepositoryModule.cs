using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Repository;

namespace Vueling.Infrastructure.Repository.Modules {
    public class RepositoryModule : Autofac.Module {

        protected override void Load(ContainerBuilder builder) {


            builder
               .RegisterType<ClientRepository>()
               .As<IClientRepository>()
               .InstancePerRequest();

            builder
               .RegisterType<PolicyRepository>()
               .As<IPolicyRepository>()
               .InstancePerRequest();


            builder
                .RegisterType<FileManager>()
                .As<IFileManager>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            base.Load(builder);

        }
    }
}
