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

namespace Vueling.Facade.Api.Controllers
{
    public class PolicyApiController : ApiController {

        private readonly IPolicyService policyService;
        private readonly ILogger log;

        #region Constructors
        public PolicyApiController(IPolicyService policyService, ILogger log) {
            this.policyService = policyService;
            this.log = log;
        }
        #endregion

        /// <summary>
        /// Get all policies
        /// </summary>
        /// <returns></returns>
        // GET: api/PolicyApi
        public List<PolicyDto> Get() {
            List<PolicyDto> policies = null;

            try {
                policies = policyService.Get();
                if (policies == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return policies;

            } catch (VuelingException ex) {
                throw ex;
            }
        }

        
        /// <summary>
        /// Get all policies from one client by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/PolicyApi/policiesByClientName/{name}")]
        public List<PolicyDto> GetPoliciesByUserName(string name) {
            List<PolicyDto> policies = null;

            try {
                policies = policyService.GetPoliciesByUserName(name);
                if (policies == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                    return policies;

            } catch (VuelingException ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Add a policy
        /// </summary>
        /// <param name="policyDto"></param>
        /// <returns></returns>
        // POST: api/PolicyApi
        /*
        [ResponseType(typeof(PolicyDto))]
        public IHttpActionResult Post(PolicyDto policyDto) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            PolicyDto policyDtoAdded = new PolicyDto();

            try {
                policyDtoAdded = policyService.Add(policyDto);
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
                new { id = policyDtoAdded.Id }, policyDtoAdded);
        }
        */
    }

}
