using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vueling.Application.Dto;
using Vueling.Application.JsonModels;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Service;
using Vueling.Common.Layer;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;
using Vueling.Facade.Api.ViewModels;

namespace Vueling.Facade.Api.Controllers {  
    /// <summary>
    /// controller that receives from the web service
    /// </summary>
    public class HTTPApiController {

        public IHTTPService httpService;
        private readonly ILogger log;

        #region Constructors
        public HTTPApiController(IHTTPService hTTPService, ILogger log) {
            httpService = hTTPService;
            this.log = log;
        }

        /*
        public HTTPApiController() {
            this.httpService = new HTTPService();
            this.log = new Log4netAdapter();
        }
        */
        #endregion
        



        /// <summary>
        /// Call GetAllClients and GetAllPolicies
        /// </summary>
        /// <returns></returns>
        public async void InitBDAsync() {
            await GetAllClients();
            await GetAllPolicies();
        }

        /// <summary>
        /// Get all Clients from an extern web service
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientDto>> GetAllClients() {

            try {
                var listClientDtos = httpService.GetAllClients().Result;
                return listClientDtos;

                #region Exceptions and log
            } catch (HttpRequestException e) {
                log.Error(ResourceApi.ArgumentNullError
                    + e.Message + ResourceApi.ErrorLogSeparation
                    + e.Data + ResourceApi.ErrorLogSeparation
                    + e.StackTrace);

                var response = new HttpResponseMessage(HttpStatusCode.NotFound) {
                    Content = new StringContent(string.Format(ResourceApi.HttpError)),
                    ReasonPhrase = ResourceApi.HttpReasonError
                };

                throw new HttpResponseException(response);

            } catch (AggregateException e) {
                log.Error(ResourceApi.AgreggateExc
                    + e.Message + ResourceApi.ErrorLogSeparation
                    + e.Data + ResourceApi.ErrorLogSeparation
                    + e.StackTrace);

                throw new VuelingException(ResourceApi.AgreggateExc, e);
            }
            #endregion

        }

        /// <summary>
        /// Get all Policies from an extern web service
        /// </summary>
        /// <returns></returns>
        public async Task<List<PolicyDto>> GetAllPolicies() {

            try {
                var listPolicytDtos = httpService.GetAllPolicies().Result;
                return listPolicytDtos;

                #region Exceptions and log
            } catch (HttpRequestException e) {
                log.Error(ResourceApi.ArgumentNullError
                    + e.Message + ResourceApi.ErrorLogSeparation
                    + e.Data + ResourceApi.ErrorLogSeparation
                    + e.StackTrace);

                var response = new HttpResponseMessage(HttpStatusCode.NotFound) {
                    Content = new StringContent(string.Format(ResourceApi.HttpError)),
                    ReasonPhrase = ResourceApi.HttpReasonError
                };

                throw new HttpResponseException(response);

            } catch (AggregateException e) {
                log.Error(ResourceApi.AgreggateExc
                    + e.Message + ResourceApi.ErrorLogSeparation
                    + e.Data + ResourceApi.ErrorLogSeparation
                    + e.StackTrace);

                throw new VuelingException(ResourceApi.AgreggateExc, e);
            }
            #endregion

        }
    }
}
