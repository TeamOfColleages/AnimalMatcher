namespace AnimalMatcher.Services.Test.Pet
{
    using System;
    using System.Linq;
    using AnimalMatcher.Common.Enums.Location;
    using AnimalMatcher.Data;
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository;
    using AnimalMatcher.Data.Repository.Interfaces;
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
        private const int PetId = 1;
        private const int PetLocationId = 1;
        private const string PetOwnerId = "PetOwnerId";

        private readonly AnimalMatcherDbContext animalMatcherDbContext;
        private readonly IMapper mapper;
        private readonly Mock<ILocationService> locationServiceMock;
        private readonly IGenericRepository<Pet> petRepository;

        private readonly PetService petService;

        public PetServiceFindPetsInRadiusTest()
        {
            this.animalMatcherDbContext = this.PrepareInMemoryDbContext();
            this.PopulateDatabase();

            var configuration = new MapperConfiguration(config => config.AddProfile<AutoMapperServicesProfile>());
            this.mapper = new Mapper(configuration);

            this.petRepository = new GenericRepository<Pet>(this.animalMatcherDbContext);

            this.locationServiceMock = new Mock<ILocationService>();

            this.petService = new PetService(this.petRepository, this.locationServiceMock.Object, this.mapper);
        }

        [Fact]
        public void FindOnePetInRadiusFromLocation()
        {
            // Arrange
            const double SearchRadiusInKm = 1;
            const double DistanceToPetInKm = 0.8;

            var testLocationInRadius = new LocationDTO
            {
                Latitude = 42.683074,
                Longitude = 23.293244
            };

            this.locationServiceMock.Setup(locationService => locationService.Distance(testLocationInRadius, It.IsAny<LocationDTO>(), It.IsAny<DistanceUnit>())).Returns(DistanceToPetInKm);

            string searcherId = "seacherId";

            // Act
            var petCollection = this.petService.FindPetsInRadius(searcherId, testLocationInRadius, SearchRadiusInKm);

            // Assert 
            petCollection
                .Should()
                .HaveCount(1);

            var pet = petCollection.FirstOrDefault();
            pet.Id.Should().Be(PetId);
            pet.Distance.Should().Be(DistanceToPetInKm);
        }

        private AnimalMatcherDbContext PrepareInMemoryDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AnimalMatcherDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AnimalMatcherDbContext(dbContextOptions);
        }

        private void PopulateDatabase()
        {
            const int PetLocationId = 1;
            const int PetId = 1;

            var petLocation = new Location
            {
                Id = PetLocationId,
                Latitude = 42.681976,
                Longitude = 23.294524,
                PetId = PetId
            };

            var petInRadius = new Pet
            {
                Id = PetId,
                Age = 2,
                Name = "Test pet in radius",
                OwnerId = PetOwnerId,
                LocationId = PetLocationId
            };

            this.animalMatcherDbContext.Add(petLocation);
            this.animalMatcherDbContext.Add(petInRadius);
            this.animalMatcherDbContext.SaveChanges();
        }
    }
}
