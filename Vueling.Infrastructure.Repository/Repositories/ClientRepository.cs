using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Layer;
using Vueling.Common.Layer.Utils;
using Vueling.Common.Layer.Utils.Log4net;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Repository {
    public class ClientRepository : IClientRepository {

        public IFileManager fm;
        private readonly ILogger log;

        public ClientRepository(IFileManager fileManager, ILogger log) {
            fm = fileManager;
            this.log = log;
        }


        public List<ClientEntity> SaveList(List<ClientEntity> listClientEntities) {
            if (HasTheDbBeenModified(listClientEntities)) {
                try {
                    fm.SaveClients(listClientEntities);

                } catch (VuelingException e) {
                    throw e;
                }
            }
            return listClientEntities;
        }

        public List<ClientEntity> GetAll() {
            List<ClientEntity> clientsList = fm.GetAllClients();
            return clientsList;
        }

        public ClientEntity GetById(string id) {
            try {
                List<ClientEntity> clientsList = fm.GetAllClients();
                ClientEntity client = clientsList
                                        .FirstOrDefault(x => x.Id.Equals(id));
                return client;

                #region Exceptions and Log
            } catch (ArgumentException e) {
                log.Error(Resource_Infrastructure_Repository.ArgumentError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, e);

            } catch (VuelingException e) {
                throw e;
            }
            #endregion
        }

        public ClientEntity GetByName(string name) {
            try {
                List<ClientEntity> clientsList = fm.GetAllClients();
                ClientEntity client = clientsList
                                        .FirstOrDefault(x => x.Name.Equals(name));
                return client;

            #region Exceptions and Log
            } catch (ArgumentException e) {
                log.Error(Resource_Infrastructure_Repository.ArgumentError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, e);

            } catch (VuelingException e) {
                throw e;
            }
            #endregion
        }

        public ClientEntity GetClientByPolicyId(string idPolicy) {
            try {
                List<ClientEntity> clientsList = fm.GetAllClients();
                List<PolicyEntity> policiesList = fm.GetAllPolicies();

                PolicyEntity policy = policiesList
                                        .FirstOrDefault(x => x.Id.Equals(idPolicy));

                ClientEntity client = clientsList
                                        .FirstOrDefault(x => x.Id.Equals(policy.ClientId));
                return client;
            
            #region Exceptions and Log
            } catch (ArgumentException e) {
                log.Error(Resource_Infrastructure_Repository.ArgumentError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, e);

            } catch (VuelingException e) {
                throw e;
            }
            #endregion
        }

        public bool HasTheDbBeenModified(List<ClientEntity> newListClients) {
            List<ClientEntity> currentListClients = fm.GetAllClients();

            if (newListClients.Count() == currentListClients.Count()) {

                newListClients = newListClients.OrderBy(x => x.Name).ToList();
                currentListClients = currentListClients.OrderBy(x => x.Name).ToList();

                for (int i = 0; i < currentListClients.Count(); i++) {
                    if (!currentListClients[i].Id.Equals(newListClients[i].Id)) {
                        return true;
                    }
                }
            } else return true;

            return false;
            }
        }
    
}
