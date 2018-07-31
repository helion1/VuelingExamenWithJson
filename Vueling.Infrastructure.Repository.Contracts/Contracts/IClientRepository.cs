using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;

namespace Vueling.Infrastructure.Repository.Contracts {
    public interface IClientRepository {
        ClientEntity GetClientByPolicyId(string idPolicy);
        ClientEntity GetByName(string name);
        ClientEntity GetById(string id);
        List<ClientEntity> GetAll();
        List<ClientEntity> SaveList(List<ClientEntity> list);
    }
}
