using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vueling.Application.Dto;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Service;
using Vueling.Common.Layer;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;

namespace Vueling.Facade.Api.Controllers{

    public class ClientApiController : ApiController {

        private readonly IClientService clientService;
        private readonly ILogger log;

        #region Constructors
        public ClientApiController(IClientService clientService, ILogger log) {
            this.clientService = clientService;
            this.log = log;
        }

        /*
        protected ClientApiController() {
            this.clientService = new ClientService();
            this.log = new Log4netAdapter();
        }
        */

        #endregion


        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>List</returns>
        // GET: api/ClientApi
        public List<ClientDto> Get() {
            List<ClientDto> clients = null;

            try {
                clients = clientService.Get();
                if (clients == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return clients;

            } catch (VuelingException ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Get client by his id
        /// </summary>
        /// <param name="idClient"></param>
        /// <returns></returns>
        // GET: api/ClientApi/5
        [HttpGet]
        [Route("api/ClientApi/{idClient}")]
        public ClientDto Get(string idClient) {
            ClientDto client = null;
            try {
                client = clientService.GetById(idClient);
                if (client == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return client;

            } catch (VuelingException ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Get a client by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A client</returns>
        [HttpGet]
        [Route("api/ClientApi/ClientName/{name}")]
        public ClientDto GetUserByName(string name) {
            ClientDto client = null;
            try {
                client = clientService.GetByName(name);
                if (client == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return client;

            } catch (VuelingException ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Get a client by id of a Policy
        /// </summary>
        /// <param name="idPolicy"></param>
        /// <returns>A client</returns>
        [HttpGet]
        [Route("apiClientApi/policy/{idPolicy}")]
        public ClientDto GetUserByPolicyId(string idPolicy) {
            ClientDto client = null;
            try {
                client = clientService.GetUserByPolicyId(idPolicy);
                if (client == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return client;

            } catch (VuelingException ex) {
                throw ex;
            }

        }


        /// <summary>
        /// Add a client
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns>Action HTTP Result</returns>
        // POST: api/ClientApi
        /*
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult Post(ClientDto clientDto) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            ClientDto clientDtoAdded = new ClientDto();

            try {
                clientDtoAdded = clientService.Add(clientDto);
            }
            #region Exceptions & Log
            catch (VuelingException e) {
                Log.Error(ResourceApi.AddError
                    + e.InnerException + ResourceApi.ErrorLogSeparation
                    + e.Message + ResourceApi.ErrorLogSeparation
                    + e.Data + ResourceApi.ErrorLogSeparation
                    + e.StackTrace);

                var response = new HttpResponseMessage(HttpStatusCode.NotFound);

                throw new HttpResponseException(response);
                #endregion
            }
            return CreatedAtRoute(ResourceApi.HttpRoute,
                new { id = clientDtoAdded.Id }, clientDtoAdded);
        }
        */
    }

}
