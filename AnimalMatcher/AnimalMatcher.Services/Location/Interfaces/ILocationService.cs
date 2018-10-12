namespace AnimalMatcher.Services.Location.Interfaces
{
    using System.Collections.Generic;
    using AnimalMatcher.Services.Models.Location;
    using AnimalMatcher.Services.Models.Pet;

    public interface ILocationService
    {
        IEnumerable<PetServiceModel> GetPetsInRadius(LocationDTO location, double radius);
    }
}
