using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Unit.Tests;
using Vueling.Domain.Entities;
using Vueling.Application.Services.Service;

namespace Vueling.Infrastructure.Repository.Repository.Integration.Tests {
    [TestClass()]
    public class ClientRepositoryIntegrationTests {

        ClientEntity client1 = new ClientEntity {
            Id = Resource_Repository_Unit.id1,
            Name = Resource_Repository_Unit.name1,
            Email = Resource_Repository_Unit.email1,
            Role = Resource_Repository_Unit.role1
        };

        List<ClientEntity> list1 = new List<ClientEntity>();


        [TestMethod]
        public void Setup() {
            var mock = AutoMock.GetLoose();

            for (int i = 0; i < 194; i++) {
                list1.Add(new ClientEntity());
            }

            mock.Mock<IFileManager>().Setup(x => x.SaveClients(list1)).Returns(list1);
            var sut = mock.Create<ClientRepository>();

            var actual = sut.GetAll();

            mock.Mock<IClientRepository>().Verify(x => x.GetById(Resource_Repository_Unit.id1));
            Assert.Equals(list1.Count, actual.Count);

        }
    }
        
}