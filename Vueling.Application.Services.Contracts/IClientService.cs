using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;

namespace Vueling.Application.Services.Contracts {
    public interface IClientService {
        ClientDto GetUserByPolicyId(string idPolicy);
        ClientDto GetByName(string name);
        ClientDto GetById(string id);
        List<ClientDto> Get();
        List<ClientDto> AddList(List<ClientDto> listClientDto);
    }
}
