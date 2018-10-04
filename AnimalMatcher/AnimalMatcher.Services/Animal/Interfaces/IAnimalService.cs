namespace AnimalMatcher.Services.Animal.Interfaces
{
    using AnimalMatcher.Services.Models.Animal;
    using System.Collections.Generic;

    public interface IAnimalService
    {
        IEnumerable<AnimalServiceModel> GetOwnersAnimals(string ownerId);
    }
}
