namespace AnimalMatcher.Services.Pet
{
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Data.Models;
    using System.Collections.Generic;
    using AnimalMatcher.Specifications;
    using AutoMapper;
    using System.Linq;
    using AnimalMatcher.Services.Pet.Interfaces;
    using AnimalMatcher.Services.Models.Pet;

    public class PetService : IPetService
    {
        private readonly IGenericRepository<Pet> petRepository;
        private readonly IMapper mapper;

        public PetService(IGenericRepository<Pet> petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }

        public void Register(PetRegisterServiceModel pet)
        {
            var petDataModel = this.mapper.Map<Pet>(pet);

            this.petRepository.Add(petDataModel);
            this.petRepository.Save();
        }

        public PetServiceModel GetById(int petId)
        {
            var getWithOwnerByIdSpecification = new Specification<Pet>(pet => pet.Id == petId);
            getWithOwnerByIdSpecification.AddInclude(pet => pet.Owner);

            var petServiceModel = this.petRepository
                .List(getWithOwnerByIdSpecification)
                .Select(petDataModel => this.mapper.Map<PetServiceModel>(petDataModel))
                .FirstOrDefault();

            return petServiceModel;
        }

        public IEnumerable<PetServiceModel> GetOwnersPets(string ownerId)
        {
            var getAnimalByOwnerSpecification = new Specification<Pet>(pet => pet.OwnerId.Equals(ownerId));
            getAnimalByOwnerSpecification.AddInclude(pet => pet.Owner);

            var petsForOwner = this.petRepository
                .List(getAnimalByOwnerSpecification)
                .Select(petDataModel => this.mapper.Map<PetServiceModel>(petDataModel))
                .ToList();

            return petsForOwner;
        }
    }
}
