using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Application.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Common.Framework.IntegrationTest.Layer;
using Vueling.Application.Services.Modules;
using Vueling.Application.Services.Contracts;

namespace Vueling.Application.Services.Service.Integration.Tests {
    [TestClass()]
    public class PolicyServiceIntegrationTests
        : IoCSupportedTest<ServiceModule>{

        private IPolicyService policyService;

        
        [TestInitialize]
        public void TestInitialize() {
            policyService = Resolve<IPolicyService>();
        }


        /// <summary>
        /// Testing total rows
        /// </summary>
        [TestMethod()]
        public void GetTest() {
            List<PolicyDto> listPolicytDto = policyService.Get();

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
            List<PolicyDto> listPolicytDto = policyService.GetPoliciesByUserName(name);

            foreach (var policy in listPolicytDto) {
                Assert.AreEqual(policy.ClientId, id);
            }
        }
    }
}