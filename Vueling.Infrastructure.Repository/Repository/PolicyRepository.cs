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
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Repository {
    public class PolicyRepository : IPolicyRepository {

        public FileManager fm;

        public PolicyRepository() : this(new FileManager()) {
            #region Init Log
            #endregion
        }

        public PolicyRepository(FileManager fileManager) {
            fm = fileManager;
            #region Init Log

            #endregion
        }

        public List<PolicyEntity> SaveList(List<PolicyEntity> listPolicyEntities) {
            if (HasTheDbBeenModified(listPolicyEntities)) {
                try {
                    fm.SavePolicies(listPolicyEntities);

                } catch (VuelingException e) {
                  throw e;
                }
            }
            return listPolicyEntities;
        }

        #region Exceptions With Log
            /*
                               catch (DbUpdateConcurrencyException e) {
                           Log.Error(Resource_Infrastructure_Repository.ConcurrencyError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);
                           throw new VuelingException(Resource_Infrastructure_Repository.ConcurrencyError, e);

                       } catch (DbUpdateException e) {
                           Log.Error(Resource_Infrastructure_Repository.DbUpdateError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);

                           throw new VuelingException(Resource_Infrastructure_Repository.DbUpdateError, e);

                       } catch (DbEntityValidationException e) {
                           Log.Error(Resource_Infrastructure_Repository.DbEntityValidationError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);

                           throw new VuelingException(Resource_Infrastructure_Repository.DbEntityValidationError, e);

                       } catch (NotSupportedException e) {
                           Log.Error(Resource_Infrastructure_Repository.NotSuportedError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);

                           throw new VuelingException(Resource_Infrastructure_Repository.NotSuportedError, e);

                       } catch (ObjectDisposedException e) {
                           Log.Error(Resource_Infrastructure_Repository.ObjectDisposedError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);

                           throw new VuelingException(Resource_Infrastructure_Repository.ObjectDisposedError, e);

                       } catch (InvalidOperationException e) {
                           Log.Error(Resource_Infrastructure_Repository.InvalidOperationError
                               + e.Message + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.Data + Resource_Infrastructure_Repository.ErrorLogSeparation
                               + e.StackTrace);

                           throw new VuelingException(Resource_Infrastructure_Repository.InvalidOperationError, e);
               }
               */
            #endregion

        public List<PolicyEntity> GetAll() {
            List<PolicyEntity> policiesList;
            try {
                policiesList = fm.GetAllPolicies();

                #region Exceptions and Log
            } catch (ArgumentException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, ex);

            } catch (VuelingException ex) {
                throw ex;
                #endregion
            }
            return policiesList;
        }

        public List<PolicyEntity> GetPoliciesByUserName(string username) {
            List<PolicyEntity> policiesList;
            List<ClientEntity> clientsList;
            ClientEntity client;
            List<PolicyEntity> policiesOfClient;

            try {
                policiesList = fm.GetAllPolicies();
                clientsList = fm.GetAllClients();

                client = clientsList.FirstOrDefault(x => x.Name.Equals(username));
                policiesOfClient = policiesList.Where(x => x.ClientId.Equals(client.Id)).ToList();

            #region Exceptions and Log
            } catch (ArgumentException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, ex);

            } catch (VuelingException ex) {
                throw ex;
            #endregion
            }
            return policiesOfClient;
        }

        public bool HasTheDbBeenModified(List<PolicyEntity> newListPolicies) {
            List<PolicyEntity> currentListPolicies = fm.GetAllPolicies();

            if (newListPolicies.Count() == currentListPolicies.Count()) {

                try {
                    newListPolicies = newListPolicies.OrderBy(x => x.Id).ToList();
                    currentListPolicies = currentListPolicies.OrderBy(x => x.Id).ToList();

                    for (int i = 0; i < currentListPolicies.Count(); i++) {
                        if (!currentListPolicies[i].Id.Equals(newListPolicies[i].Id)) {
                            return true;
                        }
                    }
                #region Exceptions and Log
                } catch (ArgumentException ex) {
                    throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, ex);

                } catch (VuelingException ex) {
                    throw ex;
                    #endregion
                }
            } else return true;
            return false;
        }
    }
}
