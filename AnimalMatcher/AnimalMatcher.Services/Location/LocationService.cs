namespace AnimalMatcher.Services.Location
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Location;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Specifications;
    using AutoMapper;

    public class LocationService : ILocationService
    {
        private const int EarthRadiusInKm = 6371;
        private const double RadiansPerDegree = 0.0174532925;

        private readonly IGenericRepository<Pet> petRepository;
        private readonly IMapper mapper;

        public LocationService(IGenericRepository<Pet> petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }

        public IEnumerable<PetServiceModel> GetPetsInRadius(LocationDTO location, double radius)
        {
            double latitudeInRadians = location.Latitude * RadiansPerDegree;
            double longitudeInRadians = location.Longitude * RadiansPerDegree;

            var petsInRadiusSpecification = new Specification<Pet>(pet => Math.Acos(Math.Sin(latitudeInRadians) * Math.Sin(pet.Location.Latitude * RadiansPerDegree)
            + Math.Cos(latitudeInRadians) * Math.Cos(pet.Location.Latitude * RadiansPerDegree) * Math.Cos(pet.Location.Longitude * RadiansPerDegree - longitudeInRadians))
            * EarthRadiusInKm <= radius);
            petsInRadiusSpecification.AddInclude(pet => pet.Location);

            var petsInRadius = this.petRepository
                .List(petsInRadiusSpecification)
                .Select(petDataModel => this.mapper.Map<PetServiceModel>(petDataModel))
                .ToList();

            return petsInRadius;
        }
    }
}
