namespace AnimalMatcher.Services.Test.Pet
{
    using System;
    using System.Linq;
    using AnimalMatcher.Common.Enums.Location;
    using AnimalMatcher.Data;
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository;
    using AnimalMatcher.Services.Infrastructure.Mapping;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Location;
    using AnimalMatcher.Services.Pet;
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class PetServiceFindPetsInRadiusTest
    {
        [Fact]
        public void FindOnePetInRadiusFromLocation()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AnimalMatcherDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var animalMatcherDbContext = new AnimalMatcherDbContext(dbContextOptions);

            const int PetLocationId = 1;
            const int PetId = 1;
            
            var petLocation = new Location
            {
                Id = PetLocationId,
                Latitude = 42.681976,
                Longitude = 23.294524,
                PetId = PetId
            };

            string petOwnerId = Guid.NewGuid().ToString();

            var petInRadius = new Pet
            {
                Id = PetId,
                Age = 2,
                Name = "Test pet in radius",
                OwnerId = petOwnerId,
                LocationId = PetLocationId
            };

            animalMatcherDbContext.Add(petLocation);
            animalMatcherDbContext.Add(petInRadius);
            animalMatcherDbContext.SaveChanges();

            var testLocation = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            var configuration = new MapperConfiguration(config => config.AddProfile<AutoMapperServicesProfile>());
            var mapper = new Mapper(configuration);

            var locationServiceMock = new Mock<ILocationService>();

            const double DistanceToPet = 0.8;
            locationServiceMock.Setup(locationService => locationService.Distance(testLocation, It.IsAny<LocationDTO>(), It.IsAny<DistanceUnit>())).Returns(DistanceToPet);

            var petRepository = new GenericRepository<Pet>(animalMatcherDbContext);

            var petService = new PetService(petRepository, locationServiceMock.Object, mapper);
            
            string callerId = petOwnerId + "caller";
            const double RadiusInKm = 1;

            // Act
            var petCollection = petService.FindPetsInRadius(callerId, testLocation, RadiusInKm);

            // Assert 
            petCollection
                .Should()
                .HaveCount(1);

            var pet = petCollection.FirstOrDefault();
            pet.Id.Should().Be(PetId);
            pet.Distance.Should().Be(DistanceToPet);
        }
    }
}
