using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Services.Service;
using Vueling.Application.Dto;

namespace Vueling.Facade.Api.Controllers.UnitTest.Tests {
    [TestClass()]
    public class ClientApiControllerTests {

        ClientService clientService = new ClientService();

        [TestMethod()]
        public void GetAllTest() {
            List<ClientDto> listClientDto = clientService.Get();
            Assert.IsTrue(listClientDto.Count() == 194);
        }




        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning")]
        [DataRow("a3b8d425-2b60-4ad7-becc-bedf2ef860bd", "Barnett")]
        [DataTestMethod]
        public void GetByIdTest(string id, string name) {
            ClientDto clientDto;
            clientDto = clientService.GetById(id);

            Assert.Equals(clientDto.Id, id);
            Assert.Equals(clientDto.Name, name);
        }



        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning")]
        [DataRow("a3b8d425-2b60-4ad7-becc-bedf2ef860bd", "Barnett")]
        [DataTestMethod]
        public void GetByNameTest(string id, string name) {
            ClientApiController clientApiController = new ClientApiController();

            ClientDto clientDto = clientApiController.GetUserByName(name);

            Assert.Equals(clientDto.Id, id);
            Assert.Equals(clientDto.Name, name);
        }




        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney", "7b624ed3-00d5-4c1b-9ab8-c265067ef58b")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning", "56b415d6-53ee-4481-994f-4bffa47b5239")]
        [DataTestMethod]
        public void GetUserByPolicyIdTest(string idClient, string name, string idPolicy) {
            ClientDto clientDto;
            clientDto = clientService.GetUserByPolicyId(idPolicy);

            Assert.Equals(clientDto.Id, idClient);
            Assert.Equals(clientDto.Name, name);
        }
    }
}