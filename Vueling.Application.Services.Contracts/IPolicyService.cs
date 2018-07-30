using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;

namespace Vueling.Application.Services.Contracts {
    public interface IPolicyService {
        List<PolicyDto> GetPoliciesByUserName(string username);
        List<PolicyDto> Get();
        List<PolicyDto> AddList(List<PolicyDto> listClientDto);
    }
}
