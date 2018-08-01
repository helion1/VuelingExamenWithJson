using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Application.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Facade.Api.Controllers;
using Vueling.Application.Dto;
using Vueling.Application.Services.Modules;
using Vueling.Application.Services.Contracts;
using Vueling.Common.Framework.IntegrationTest.Layer;
using Vueling.Infrastructure.Repository.Modules;

namespace Vueling.Application.Services.Service.UnitTest.Tests {
    [TestClass()]
    public class ClientServiceIntegrationTest 
        :  IoCSupportedTest<ServiceModule> {

        private IClientService clientService;


        [TestInitialize]
        public void TestInitialize() {
            clientService = Resolve<IClientService>();
        }


        /// <summary>
        /// Testing total rows
        /// </summary>
        [TestMethod()]
        public void GetAllTest() {
            List<ClientDto> listClientDto = clientService.Get();

            Assert.IsTrue(listClientDto.Count() == 194);
        }



        /// <summary>
        /// Testing GetById method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning")]
        [DataRow("a3b8d425-2b60-4ad7-becc-bedf2ef860bd", "Barnett")]
        [DataTestMethod]
        public void GetByIdTest(string id, string name) {
            ClientDto clientDto = clientService.GetById(id);

            Assert.AreEqual(clientDto.Id, id);
            Assert.AreEqual(clientDto.Name, name);
        }


        /// <summary>
        /// Testing GetByName method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning")]
        [DataRow("a3b8d425-2b60-4ad7-becc-bedf2ef860bd", "Barnett")]
        [DataTestMethod]
        public void GetByNameTest(string id, string name) {
            ClientDto clientDto = clientService.GetByName(name);

            Assert.AreEqual(clientDto.Id, id);
            Assert.AreEqual(clientDto.Name, name);
        }



        /// <summary>
        /// Testing GetUserByPolicyId method
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="name"></param>
        /// <param name="idPolicy"></param>
        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney", "7b624ed3-00d5-4c1b-9ab8-c265067ef58b")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning", "56b415d6-53ee-4481-994f-4bffa47b5239")]
        [DataTestMethod]
        public void GetUserByPolicyIdTest(string idClient, string name, string idPolicy) {
            ClientDto clientDto = clientService.GetUserByPolicyId(idPolicy);

            Assert.AreEqual(clientDto.Id, idClient);
            Assert.AreEqual(clientDto.Name, name);
        }
    }
}