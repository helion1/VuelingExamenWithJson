using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infrastructure.Repository.Contracts {
    public interface IClientRepository<T> {
        T GetClientByPolicyId(string idPolicy);
        T GetByName(string name);
        T GetById(string id);
    }
}
