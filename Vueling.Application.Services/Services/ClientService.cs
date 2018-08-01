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
using Vueling.Common.Layer.Utils.Log4net;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Repository;

namespace Vueling.Application.Services.Service {
    public class ClientService : IClientService {
        private readonly IClientRepository clientRepository;
        private readonly ILogger log;

       
        public ClientService(IClientRepository clientRepository, ILogger log) {
            this.clientRepository = clientRepository;
            this.log = log;
        }


        public List<ClientDto> AddList(List<ClientDto> listClientDto) {
            List<ClientEntity> ListClientEntities;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, ClientDto>().ReverseMap());
                IMapper iMapper = config.CreateMapper();

                ListClientEntities = iMapper.Map<List<ClientDto>, List<ClientEntity>>(listClientDto);

                List<ClientEntity> ListClientEntitiesAdded = clientRepository.SaveList(ListClientEntities);

                List<ClientDto> listClientDtoAdded = iMapper.Map<List<ClientEntity>, List<ClientDto>>(ListClientEntitiesAdded);

                return listClientDtoAdded;

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
            #endregion
            }
        }
        
        /// <summary>
        /// Return all clients
        /// </summary>
        /// <returns></returns>
        public List<ClientDto> Get() {

            List<ClientEntity> ListClientEntities;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, ClientDto>().ReverseMap());
                IMapper iMapper = config.CreateMapper();

                ListClientEntities = clientRepository.GetAll();

                List<ClientDto> listClientDto =  iMapper.Map<List<ClientEntity>, List<ClientDto>>(ListClientEntities);

                return listClientDto;

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
            #endregion
            }
        }

        /// <summary>
        /// Get an User by his Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientDto GetById(string id) {
            ClientEntity clientEntity;
            ClientDto clientDto;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, ClientDto>());
                IMapper iMapper = config.CreateMapper();

                clientEntity = clientRepository.GetById(id);

                clientDto = iMapper.Map<ClientEntity, ClientDto>(clientEntity);

                return clientDto;

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

        /// <summary>
        /// Get an User by his name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClientDto GetByName(string name) {
            ClientEntity clientEntity;
            ClientDto clientDto;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, ClientDto>());
                IMapper iMapper = config.CreateMapper();

                clientEntity = clientRepository.GetByName(name);

                clientDto = iMapper.Map<ClientEntity, ClientDto>(clientEntity);

                return clientDto;

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

        /// <summary>
        /// Get an User by a Policy Id
        /// </summary>
        /// <param name="idPolicy"></param>
        /// <returns></returns>
        public ClientDto GetUserByPolicyId(string idPolicy) {
            ClientEntity clientEntity;
            ClientDto clientDto;

            try {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, ClientDto>());
                IMapper iMapper = config.CreateMapper();

                clientEntity = clientRepository.GetClientByPolicyId(idPolicy);

                clientDto = iMapper.Map<ClientEntity, ClientDto>(clientEntity);

                return clientDto;

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
