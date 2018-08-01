using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Common.Framework.IntegrationTest.Layer;
using Vueling.Application.Services.Modules;
using Vueling.Facade.Api.Modules;

namespace Vueling.Facade.Api.Controllers.UnitTest.Tests {

    [TestClass()]
    public class ClientApiControllerIntegrationTests 
        : IoCSupportedTest<WebApiModule> {

        private ClientApiController clientApiController;


        [TestInitialize]
        public void TestInitialize() {
            clientApiController = Resolve<ClientApiController>();
        }



        /// <summary>
        /// Testing total rows
        /// </summary>
        [TestMethod()]
        public void GetAllTest() {
            List<ClientDto> listClientDto = clientApiController.Get();

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
            ClientDto clientDto = clientApiController.Get(id);

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
            ClientDto clientDto = clientApiController.GetUserByName(name);

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
            ClientDto clientDto = clientApiController.GetUserByPolicyId(idPolicy);

            Assert.AreEqual(clientDto.Id, idClient);
            Assert.AreEqual(clientDto.Name, name);
        }
    }
}