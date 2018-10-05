namespace AnimalMatcher.Services.Pet.Interfaces
{
    using AnimalMatcher.Services.Models.Pet;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetServiceModel> GetOwnersPets(string ownerId);
    }
}
