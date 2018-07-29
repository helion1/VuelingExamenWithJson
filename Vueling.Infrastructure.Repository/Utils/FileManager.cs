using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Common.Layer;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository {
    public class FileManager : IFileManager {
        public FileManager() {
            FileClients = Resource_Infrastructure_Repository.PathClients;
            FilePolicies = Resource_Infrastructure_Repository.PathPolicies;
            Path = Resource_Infrastructure_Repository.PathForFiles;
        }

        public string Path { get; set; }
        public string FileClients { get; set; }
        public string FilePolicies { get; set; }


        public void SaveClients(List<ClientEntity> listClients) {
            try {
                using (StreamWriter file = new StreamWriter(Path + FileClients, true)) { };
                var listClientsJSON = JsonConvert.SerializeObject(listClients, Formatting.Indented);
                File.WriteAllText(Path + FileClients, listClientsJSON);
                #region Exceptions and Log
            } catch (UnauthorizedAccessException e) {
                //LOG4NET
                throw new VuelingException(Resource_Infrastructure_Repository.Unauthorized, e);

            } catch (ArgumentException e) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, e);

            } catch (DirectoryNotFoundException e) {
                throw new VuelingException(Resource_Infrastructure_Repository.DirectoryNotFound, e);

            } catch (IOException e) {
                throw new VuelingException(Resource_Infrastructure_Repository.IOE, e);

            }
            #endregion
        }

        public void SavePolicies(List<PolicyEntity> listPolicies) {
            try {
                using (StreamWriter file = new StreamWriter(Path + FilePolicies, true)) { };
                var listPoliciesJSON = JsonConvert.SerializeObject(listPolicies, Formatting.Indented);
                File.WriteAllText(Path + FilePolicies, listPoliciesJSON);
                #region Exceptions and Log
            } catch (UnauthorizedAccessException e) {
                //LOG4NET
                throw new VuelingException(Resource_Infrastructure_Repository.Unauthorized, e);

            } catch (ArgumentException e) {
                throw new VuelingException(Resource_Infrastructure_Repository.ArgumentError, e);

            } catch (DirectoryNotFoundException e) {
                throw new VuelingException(Resource_Infrastructure_Repository.DirectoryNotFound, e);

            } catch (IOException e) {
                throw new VuelingException(Resource_Infrastructure_Repository.IOE, e);

            }
            #endregion
        }

        public List<ClientEntity> GetAllClients() {
            try {
                string fileJson = File.ReadAllText(Path + FileClients);
                List<ClientEntity> clientsList = JsonConvert.DeserializeObject<List<ClientEntity>>(fileJson);
                return clientsList;
            }
            #region Exceptions and Log
            catch (JsonReaderException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.JsonReader, ex);

            } catch (JsonSerializationException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.JsonSerialization, ex);

            } catch (JsonWriterException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.JsonWritter, ex);

            } catch (JsonException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.Json, ex);

            }
            #endregion

        }

        public List<PolicyEntity> GetAllPolicies() {
            try {
                string fileJson = File.ReadAllText(Path + FilePolicies);
                List<PolicyEntity> policiesList = JsonConvert.DeserializeObject<List<PolicyEntity>>(fileJson);
                return policiesList;
            }
            #region Exceptions and Log
            catch (JsonReaderException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.JsonReader, ex);

            } catch (JsonSerializationException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.JsonSerialization, ex);

            } catch (JsonWriterException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.JsonWritter, ex);

            } catch (JsonException ex) {
                throw new VuelingException(Resource_Infrastructure_Repository.Json, ex);

            }
            #endregion

        }

    }
}
