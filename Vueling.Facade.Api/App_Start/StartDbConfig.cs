using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Service;

namespace Vueling.Facade.Api.App_Start {
    public class StartDbConfig {
        static IHTTPService httpService;

        public StartDbConfig(IHTTPService httpS) {
            httpService = httpS;
        }


        public static void InitData() {
            httpService.GetAllClients();
            httpService.GetAllPolicies();
        }

    }
}