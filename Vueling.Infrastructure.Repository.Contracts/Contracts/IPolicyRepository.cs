using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;

namespace Vueling.Infrastructure.Repository.Contracts {
    public interface IPolicyRepository {
        List<PolicyEntity> GetPoliciesByUserName(string username);
        List<PolicyEntity> GetAll();
        List<PolicyEntity> SaveList(List<PolicyEntity> list);
    }
}
