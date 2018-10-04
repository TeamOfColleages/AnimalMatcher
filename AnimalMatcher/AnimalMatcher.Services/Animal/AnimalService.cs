namespace AnimalMatcher.Services.Animal
{
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Data.Models;
    using System.Collections.Generic;
    using AnimalMatcher.Specifications;
    using AutoMapper;
    using System.Linq;
    using AnimalMatcher.Services.Animal.Interfaces;
    using AnimalMatcher.Services.Models.Animal;

    public class AnimalService : IAnimalService
    {
        private readonly IGenericRepository<Animal> animalRepository;
        private readonly IMapper mapper;

        public AnimalService(IGenericRepository<Animal> animalRepository, IMapper mapper)
        {
            this.animalRepository = animalRepository;
            this.mapper = mapper;
        }

        public IEnumerable<AnimalServiceModel> GetOwnersAnimals(string ownerId)
        {
            var getAnimalByOwnerSpecification = new Specification<Animal>(animal => animal.OwnerId.Equals(ownerId));
            getAnimalByOwnerSpecification.AddInclude(animal => animal.Owner);

            var animalsForOwner = this.animalRepository
                .List(getAnimalByOwnerSpecification)
                .Select(animalDataModel => this.mapper.Map<AnimalServiceModel>(animalDataModel))
                .ToList();

            return animalsForOwner;
        }
    }
}
