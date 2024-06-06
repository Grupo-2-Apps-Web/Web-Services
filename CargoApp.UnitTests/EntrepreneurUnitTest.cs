using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;
using Moq;

namespace CargoApp.UnitTests;

public class EntrepreneurUnitTest
{
    [Fact]
    public async Task GetAll_Entrepreneur_Success()
    {
        // Arrange
        var userEntrepreneur1 = new User("Lucho Vega", "986559213", "20000000002", "Av. Peru 123",
            "empresario@gmail.com", "micontrasecreta", "Premium");
        var entrepreneur1 = new Entrepreneur(1, "logo.com/image.jpeg", userEntrepreneur1);

        var userEntrepreneur2 = new User("Carlos Perez", "986559214", "20000000003", "Av. Lima 123",
            "empresario2@gmail.com", "micontrasecreta2", "Premium");
        var entrepreneur2 = new Entrepreneur(2, "logo2.com/image.jpeg", userEntrepreneur2);

        var entrepreneurs = new List<Entrepreneur> { entrepreneur1, entrepreneur2 };

        var mockEntrepreneurRepository = new Mock<IEntrepreneurRepository>();
        mockEntrepreneurRepository.Setup(repo => repo.ListAsync()).ReturnsAsync(entrepreneurs);

        // Act
        var returnedEntrepreneurs = await mockEntrepreneurRepository.Object.ListAsync();

        // Assert
        mockEntrepreneurRepository.Verify(repo => repo.ListAsync(), Times.Once);
        Assert.Equal(entrepreneurs, returnedEntrepreneurs);
        Assert.Equal(2, returnedEntrepreneurs.Count());
    }
  
    [Fact]
    public async Task GetById_Entrepreneur_Success()
    {
        // Arrange
        int validId = 1;
        int invalidId = 0;
        var userEntrepreneur = new User("Lucho Vega", "986559213", "20000000002", "Av. Peru 123",
            "empresario@gmail.com", "micontrasecreta", "Premium");
        var entrepreneur = new Entrepreneur(validId, "logo.com/image.jpeg", userEntrepreneur);
        var mockEntrepreneurRepository = new Mock<IEntrepreneurRepository>();
        mockEntrepreneurRepository.Setup(repo => repo.FindByIdAsync(validId)).ReturnsAsync(entrepreneur);
        mockEntrepreneurRepository.Setup(repo => repo.FindByIdAsync(invalidId)).ReturnsAsync((Entrepreneur)null);
        // Act
        var returnedEntrepreneur = await mockEntrepreneurRepository.Object.FindByIdAsync(validId);
        var returnedNullEntrepreneur = await mockEntrepreneurRepository.Object.FindByIdAsync(invalidId);

        // Assert
        mockEntrepreneurRepository.Verify(repo => repo.FindByIdAsync(validId), Times.Once);
        mockEntrepreneurRepository.Verify(repo => repo.FindByIdAsync(invalidId), Times.Once);
        Assert.Equal(entrepreneur, returnedEntrepreneur);
        Assert.Null(returnedNullEntrepreneur);
    }

    [Fact]
    public async Task Add_Entrepreneur_Success()
    {
        // Arrange
        var userEntrepreneur = new User("Lucho Vega", "986559213", "20000000002", "Av. Peru 123",
            "empresario@gmail.com", "micontrasecreta", "Premium");
        var entrepreneur = new Entrepreneur(1, "logo.com/image.jpeg", userEntrepreneur);
        var mockEntrepreneurRepository = new Mock<IEntrepreneurRepository>();
        mockEntrepreneurRepository.Setup(repo => repo.AddAsync(entrepreneur)).Returns(Task.CompletedTask);

        // Act
        await mockEntrepreneurRepository.Object.AddAsync(entrepreneur);

        // Assert
        mockEntrepreneurRepository.Verify(repo => repo.AddAsync(entrepreneur), Times.Once);
    }
    
}