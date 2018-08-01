using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;
using Vueling.Common.Framework.IntegrationTest.Layer;
using Vueling.Infrastructure.Repository.Modules;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Repository.Integration.Tests {
    [TestClass()]
    public class PolicyRepositoryIntegrationTests 
        : IoCSupportedTest<RepositoryModule> {

        private IPolicyRepository policyRepository;


        [TestInitialize]
        public void TestInitialize() {
            policyRepository = Resolve<IPolicyRepository>();
        }


        /// <summary>
        /// Testing total rows
        /// </summary>
        [TestMethod()]
        public void GetTest() {
            List<PolicyEntity> listPolicyEntities = policyRepository.GetAll();

            Assert.IsTrue(listPolicyEntities.Count() == 193);
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
            List<PolicyEntity> listPolicyEntities = policyRepository.GetPoliciesByUserName(name);

            foreach (var policy in listPolicyEntities) {
                Assert.AreEqual(policy.ClientId, id);
            }
        }
    }
}