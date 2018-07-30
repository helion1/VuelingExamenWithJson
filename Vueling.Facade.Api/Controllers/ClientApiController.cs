using Serilog;
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

namespace Vueling.Facade.Api.Controllers{

    public class ClientApiController : ApiController {

        private readonly ClientService clientService;

        /// <summary>
        /// Void Constructor
        /// </summary>
        public ClientApiController() : this(new ClientService()) {
            #region Init Log
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(ConfigurationManager.AppSettings["ErrorLog"].ToString(), fileSizeLimitBytes: 1000)
                .CreateLogger();
            #endregion
        }

        /// <summary>
        /// Void constructor
        /// </summary>
        /// <param name="clientService"></param>
        public ClientApiController(ClientService clientService) {
            this.clientService = clientService;
            #region Init Log
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(ConfigurationManager.AppSettings["ErrorLog"].ToString(), fileSizeLimitBytes: 1000)
                .CreateLogger();
            #endregion
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>List</returns>
        // GET: api/ClientApi
        public IHttpActionResult Get() {
            List<ClientDto> clients = null;

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                clients = clientService.Get();
                if (clients == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return Ok(clients);

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
            return clientService.GetById(idClient);
        }

        /// <summary>
        /// Get a client by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A client</returns>
        [HttpGet]
        [Route("api/ClientApi/ClientName/{name}")]
        public ClientDto GetUserByName(string name) {
            return clientService.GetByName(name);
        }

        /// <summary>
        /// Get a client by id of a Policy
        /// </summary>
        /// <param name="idPolicy"></param>
        /// <returns>A client</returns>
        [HttpGet]
        [Route("apiClientApi/policy/{idPolicy}")]
        public ClientDto GetUserByPolicyId(string idPolicy) {
            return clientService.GetUserByPolicyId(idPolicy);
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
