using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Application.Services.Contracts;
using Vueling.Common.Layer;
using Vueling.Common.Layer.Utils;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Repository;

namespace Vueling.Application.Services.Service {
    public class PolicyService : IPolicyService {

        private readonly IPolicyRepository policyRepository;
        private readonly ILogger log;


        public PolicyService(IPolicyRepository policyRepository, ILogger log) {
            this.policyRepository = policyRepository;
            this.log = log;
        }


        public List<PolicyDto> AddList(List<PolicyDto> listPolicyDto) {
            List<PolicyEntity> ListPolicyEntities;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PolicyEntity, PolicyDto>().ReverseMap());
                IMapper iMapper = config.CreateMapper();

                ListPolicyEntities = iMapper.Map<List<PolicyDto>, List<PolicyEntity>>(listPolicyDto);

                List<PolicyEntity> ListPolicyEntitiesAdded = policyRepository.SaveList(ListPolicyEntities);

                List<PolicyDto> listPolicyDtoAdded = iMapper.Map<List<PolicyEntity>, List<PolicyDto>>(ListPolicyEntitiesAdded);

                return listPolicyDtoAdded;

                #region Exceptions With Log
            } catch (NotSupportedException e) {
                log.Error(Resource_Application_Services.NotSuportedError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.NotSuportedError, e);

            } catch (ObjectDisposedException e) {
                log.Error(Resource_Application_Services.ObjectDisposedError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.ObjectDisposedError, e);

            } catch (InvalidOperationException e) {
                log.Error(Resource_Application_Services.InvalidOperationError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.InvalidOperationError, e);
            }
            #endregion
        }

            public List<PolicyDto> Get() {
            List<PolicyEntity> listPolicyEntities;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PolicyEntity, PolicyDto>().ReverseMap());
                IMapper iMapper = config.CreateMapper();

                listPolicyEntities = policyRepository.GetAll();

                List<PolicyDto> listPolicyDtos = iMapper.Map<List<PolicyEntity>, List<PolicyDto>>(listPolicyEntities);
                return listPolicyDtos;

                #region Exceptions With Log
            } catch (NotSupportedException e) {
                log.Error(Resource_Application_Services.NotSuportedError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.NotSuportedError, e);

            } catch (ObjectDisposedException e) {
                log.Error(Resource_Application_Services.ObjectDisposedError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.ObjectDisposedError, e);

            } catch (InvalidOperationException e) {
                log.Error(Resource_Application_Services.InvalidOperationError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.InvalidOperationError, e);
            }
            #endregion
        }


        public List<PolicyDto> GetPoliciesByUserName(string username) {
            List<PolicyDto> listPolicyDto;
            List<PolicyEntity> listPolicyEntities;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PolicyEntity, PolicyDto>());
                IMapper iMapper = config.CreateMapper();

                listPolicyEntities = policyRepository.GetPoliciesByUserName(username);

                listPolicyDto = iMapper.Map<List<PolicyEntity>, List<PolicyDto>>(listPolicyEntities);

                return listPolicyDto;
                #region Exceptions With Log
            } catch (NotSupportedException e) {
                log.Error(Resource_Application_Services.NotSuportedError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.NotSuportedError, e);

            } catch (ObjectDisposedException e) {
                log.Error(Resource_Application_Services.ObjectDisposedError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.ObjectDisposedError, e);

            } catch (InvalidOperationException e) {
                log.Error(Resource_Application_Services.InvalidOperationError
                               + e.Message + Resource_Application_Services.ErrorLogSeparation
                               + e.Data + Resource_Application_Services.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Application_Services.InvalidOperationError, e);
            }
            #endregion
        }
    }
}
