using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Vueling.Application.Dto;
using Vueling.Application.JsonModels;
using Vueling.Application.Services.Contracts;
using Vueling.Common.Layer;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;

namespace Vueling.Application.Services.Service {
    public class HTTPService : IHTTPService{

        public HttpClient client;
        public IClientService clientService;
        public IPolicyService policyService;
        private readonly ILogger log;

        #region Constructors

        public HTTPService(HttpClient httpClient, IClientService clientService,
             IPolicyService policyService, ILogger log) {

            this.client = httpClient;
            this.clientService = clientService;
            this.policyService = policyService;
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["uriWebServiceClientsPolicies"]);
        }
        
        #endregion

        public void InitDb() {
            GetAllClients();
            GetAllPolicies();
        }


        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientDto>> GetAllClients() {
            ContainerJsonClientDto ContainerJsonClients = new ContainerJsonClientDto();
            List<ClientDto> listClientDtos = new List<ClientDto>();

            try {
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync(ConfigurationManager.AppSettings["pathToAllClients"]).Result;

                if (response.IsSuccessStatusCode) {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    ContainerJsonClients = JsonConvert.DeserializeObject<ContainerJsonClientDto>(jsonString);

                    for (int i = 0; i < ContainerJsonClients.clientDto.Length; i++) {
                        listClientDtos.Add(ContainerJsonClients.clientDto[i]);
                    }

                    clientService.AddList(listClientDtos);
                }
            #region Exceptions and log
            } catch (ArgumentNullException e) {
                log.Error(Resource_Application_Services.ArgumentError
                    + e.Message + Resource_Application_Services.ErrorLogSeparation
                    + e.Data + Resource_Application_Services.ErrorLogSeparation
                    + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.ArgumentError, e);
            }
            #endregion

            return listClientDtos;
        }


        /// <summary>
        /// Get all policies
        /// </summary>
        /// <returns></returns>
        public async Task<List<PolicyDto>> GetAllPolicies() {
            ContainerJsonPolicyDto ContainerJsonPolicies = new ContainerJsonPolicyDto();
            List<PolicyDto> listPolicyDtos = new List<PolicyDto>();

            try {
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync(ConfigurationManager.AppSettings["pathToAllPolicies"]).Result;

                if (response.IsSuccessStatusCode) {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    ContainerJsonPolicies = JsonConvert.DeserializeObject<ContainerJsonPolicyDto>(jsonString);

                    for (int i = 0; i < ContainerJsonPolicies.policyDto.Length; i++) {
                        listPolicyDtos.Add(ContainerJsonPolicies.policyDto[i]);
                    }

                    policyService.AddList(listPolicyDtos);

                }
            #region Exceptions and log
            } catch (ArgumentNullException e) {
                log.Error(Resource_Application_Services.ArgumentError
                    + e.Message + Resource_Application_Services.ErrorLogSeparation
                    + e.Data + Resource_Application_Services.ErrorLogSeparation
                    + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.ArgumentError, e);
            } 
            #endregion
            return listPolicyDtos;
        }

    }
}
