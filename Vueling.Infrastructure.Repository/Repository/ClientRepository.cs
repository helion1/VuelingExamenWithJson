using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Layer;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Repository {
    public class ClientRepository : IClientRepository {

        public FileManager fm;

        public ClientRepository() : this(new FileManager()) {
            #region Init Log

            #endregion
        }

        public ClientRepository(FileManager fileManager) {
            fm = fileManager;
        }
        

        public List<ClientEntity> SaveList(List<ClientEntity> listClientEntities) {
            if (HasTheDbBeenModified(listClientEntities)) {
                fm.SaveClients(listClientEntities);
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
            }
            #region Exceptions and Log
            catch (ArgumentException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, ex);

            } catch (VuelingException ex) {
                throw ex;
            }
            #endregion
        }

        public ClientEntity GetByName(string name) {
            try {
                List<ClientEntity> clientsList = fm.GetAllClients();
                ClientEntity client = clientsList
                                        .FirstOrDefault(x => x.Name.Equals(name));
                return client;
            }
            #region Exceptions and Log
            catch (ArgumentException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, ex);

            } catch (VuelingException ex) {
                throw ex;
                #endregion
            }
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
            }
            #region Exceptions and Log
            catch (ArgumentException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, ex);

            } catch (VuelingException ex) {
                throw ex;
                #endregion
            }
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
