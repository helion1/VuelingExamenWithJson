using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;

namespace Vueling.Facade.Api.Controllers.UnitTest.Tests {
    [TestClass()]
    public class PolicyApiControllerIntegrationTests {

        private PolicyApiController policyApiController;

        [TestInitialize]
        public void TestInitialize() {
            policyApiController = new PolicyApiController();
        }


        /// <summary>
        /// Testing total rows
        /// </summary>
        [TestMethod()]
        public void GetTest() {
            List<PolicyDto> listPolicytDto = policyApiController.Get();

            Assert.IsTrue(listPolicytDto.Count() == 193);
        }



        /// <summary>
        /// Testing GetPoliciesByUserName method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        [DataRow("a0ece5db-cd14-4f21-812f-966633e7be86", "Britney")]
        [DataRow("e8fd159b-57c4-4d36-9bd7-a59ca13057bb", "Manning")]
        [DataTestMethod]
        public void GetPoliciesByUserNameTest(string id, string name) {
            List<PolicyDto> listPolicytDto = policyApiController.GetPoliciesByUserName(name);

            foreach(var policy in listPolicytDto) {
                Assert.AreEqual(policy.ClientId, id);
            }
        }
        
    }
}