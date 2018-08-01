using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Dto;
using Moq;
using Vueling.Facade.ApiTests1;

namespace Vueling.Facade.Api.Controllers.UnitTest.Tests {
    
    [TestClass()]
    public class PolicyApiControllerUnitTests {

        private IPolicyService mockObject;
        private PolicyDto policyDto;
        private List<PolicyDto> listPolicies;

        [TestInitialize]
        public void Setup() {
            var mock = new Mock<IPolicyService>();
            listPolicies = new List<PolicyDto>();


            policyDto = new PolicyDto(ResourceUnitTests.policyid2,
                                       Convert.ToDecimal(ResourceUnitTests.amountInsured2),
                                       ResourceUnitTests.policyEmail2,
                                       Convert.ToDateTime(ResourceUnitTests.policyDateTime2),
                                       true,
                                       ResourceUnitTests.policyIdClient2
                                       );

            for (var i = 0; i < 91; i++) {
                listPolicies.Add(policyDto);
            }


            mock.Setup(x => x.GetPoliciesByUserName(ResourceUnitTests.nameOfUserTest1))
                .Returns(listPolicies);

            mockObject = mock.Object;
        }


        [TestCategory("Get")]
        [TestMethod]
        public void GetTest() {
            var result = mockObject.GetPoliciesByUserName(ResourceUnitTests.nameOfUserTest1);
            Assert.AreEqual(result.Count, listPolicies.Count);
        }

    }
    
}