namespace AnimalMatcher.Services.Location
{
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Data.Models;
    using System.Collections.Generic;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Specifications;
    using System;
    using AnimalMatcher.Services.Location.Interfaces;
    using System.Linq;

    public class LocationService : ILocationService
    {
        private readonly IGenericRepository<Pet> petRepository;

        public LocationService(IGenericRepository<Pet> petRepository)
        {
            this.petRepository = petRepository;
        }

        public IEnumerable<PetServiceModel> GetPetsInRadius(double latitude, double longitude, double radius)
        {
            const int earthRaduis = 6371;
            const double radiansInDegree = 0.0174532925;
            double latitudeInRadians = latitude * radiansInDegree;
            double longitudeInRadians = longitude * radiansInDegree;

            var petsInRadiusSpecification = new Specification<Pet>(pet => Math.Acos(Math.Sin(latitudeInRadians) * Math.Sin(pet.Latitude * radiansInDegree)
            + Math.Cos(latitudeInRadians) * Math.Cos(pet.Latitude * radiansInDegree) * Math.Cos(pet.Longitude * radiansInDegree - longitudeInRadians))
            * earthRaduis <= radius);

            var petsInRadius = this.petRepository.List(petsInRadiusSpecification).ToList();

            return null;
        }
    }
}
