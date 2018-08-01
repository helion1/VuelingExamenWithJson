using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Application.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Autofac.Extras.Moq;
using Vueling.Application.Services.Unit.Tests;
using Moq;

namespace Vueling.Application.Services.Service.Integration.Tests {
    [TestClass()]
    public class ClientServiceUnitTests {

        private IClientRepository mockObject;
        private ClientEntity entity;

        [TestInitialize]
        public void Setup() {
            var mock = new Mock<IClientRepository>();

            entity = new ClientEntity("a0ece5db-cd14-4f21-812f-966633e7be86",
                                       "Britney",
                                       "britneyblankenship@quotezart.com",
                                       "admin");

            mock.Setup(x => x.GetById(Resource_Service_Unit.id1)).Returns(entity);
            mock.Setup(x => x.GetByName(Resource_Service_Unit.name1)).Returns(entity);
            mock.Setup(x => x.GetClientByPolicyId(Resource_Service_Unit.idPolicy1)).Returns(entity);

            mockObject = mock.Object;
        }


        [TestCategory("Get")]
        [TestMethod]
        public void GetByIdTest() {
            var result = mockObject.GetById(Resource_Service_Unit.id1);
            Assert.AreEqual(result.Id, entity.Id);
        }


        [TestCategory("Get")]
        [TestMethod]
        public void GetByNameTest() {
            var result = mockObject.GetByName(Resource_Service_Unit.name1);
            Assert.AreEqual(result, entity);
        }


        [TestCategory("Get")]
        [TestMethod]
        public void GetByIdPolicyTest() {
            var result = mockObject.GetClientByPolicyId(Resource_Service_Unit.idPolicy1);
            Assert.AreEqual(result.Id, entity.Id);
        }

    }



    /*
    ClientEntity client1 = new ClientEntity {
        Id = Resource_Service_Unit.id1,
        Name = Resource_Service_Unit.name1,
        Email = Resource_Service_Unit.email1,
        Role = Resource_Service_Unit.role1
    };


    [TestMethod]
    public void ClientRepositoryTest() {

        using (var mock = AutoMock.GetLoose()) {

            mock.Mock<IClientRepository>()
                .Setup(x => x.GetById(Resource_Service_Unit.id1)).Returns(client1);
            var sut = mock.Create<ClientService>();

            var actual = sut.GetById(Resource_Service_Unit.id1);

            mock.Mock<IClientRepository>().Verify(x => x.GetById(Resource_Service_Unit.id1));
            Assert.Equals(client1, actual);

        }
    }
    */

}