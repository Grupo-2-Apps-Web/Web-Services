using Moq;
using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;

namespace CargoApp.UnitTests
{
    public class ClientUnitTst
    {
        [Fact]
        public async Task GetAll_Client_Success()
        {
            // Arrange
            var userClient = new User("Juan Perez", "926559113", "20000000001", "Av. Lima 123", "cliente@gmail.com", "contra1234567", "Premium");
            var userClientTwo = new User("Pedro Sanchez", "986559213", "20000000002", "Av. Peru 123", "cliente2@gmial.com", "contra1234567", "Basic");
            List<Client> clients = new List<Client>
            {
                new Client(1, userClient),
                new Client(2, userClientTwo)
            };
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.ListAsync()).ReturnsAsync(clients);
            
            // Act
            var returnedClients = await mockClientRepository.Object.ListAsync();
            
            // Assert
            mockClientRepository.Verify(repo => repo.ListAsync(), Times.Once);
            Assert.Equal(clients, returnedClients);
            Assert.Equal(2, returnedClients.Count());
        }
        
        [Fact]
        public async Task GetById_Client_Success()
        {
            // Arrange
            int validId = 1;
            int invalidId = 0;
            var userClient = new User("Juan Perez", "986559113", "20000000001", "Av. Lima 123", "cliente@gmail.com", "contra1234567", "Premium");
            var client = new Client(validId, userClient);
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.FindByIdAsync(validId)).ReturnsAsync(client);
            mockClientRepository.Setup(repo => repo.FindByIdAsync(invalidId)).ReturnsAsync((Client)null);

            // Act
            var returnedClient = await mockClientRepository.Object.FindByIdAsync(validId);
            var returnedNullClient = await mockClientRepository.Object.FindByIdAsync(invalidId);
            
            // Assert
            mockClientRepository.Verify(repo => repo.FindByIdAsync(validId), Times.Once);
            mockClientRepository.Verify(repo => repo.FindByIdAsync(invalidId), Times.Once);
            Assert.Equal(client, returnedClient);
            Assert.Null(returnedNullClient);
        }
        
        [Fact]
        public async Task Add_Client_Success()
        {
            // Arrange
            var userClient = new User("Juan Perez", "986559113", "20000000001", "Av. Lima 123", "cliente@gmail.com", "contra1234567", "Premium");
            var client = new Client(1, userClient);
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.AddAsync(client)).Returns(Task.CompletedTask);

            // Act
            await mockClientRepository.Object.AddAsync(client);

            // Assert
            mockClientRepository.Verify(repo => repo.AddAsync(client), Times.Once);
        }
    }
}