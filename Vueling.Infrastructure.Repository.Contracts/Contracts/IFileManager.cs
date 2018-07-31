using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Domain.Entities;

namespace Vueling.Infrastructure.Repository.Contracts {
    public interface IFileManager {
        void SaveClients(List<ClientEntity> listClients);
        void SavePolicies(List<PolicyEntity> listPolicies);

        List<ClientEntity> GetAllClients();
        List<PolicyEntity> GetAllPolicies();

    }
}
