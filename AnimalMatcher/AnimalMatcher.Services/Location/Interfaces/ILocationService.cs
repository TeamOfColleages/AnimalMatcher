namespace AnimalMatcher.Services.Location.Interfaces
{
    using System.Collections.Generic;
    using AnimalMatcher.Services.Models.Pet;

    public interface ILocationService
    {
        IEnumerable<PetServiceModel> GetPetsInRadius(double latitude, double longitude, double radius);
    }
}
