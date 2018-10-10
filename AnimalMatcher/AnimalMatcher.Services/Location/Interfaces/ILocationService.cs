namespace AnimalMatcher.Services.Location.Interfaces
{
    using AnimalMatcher.Services.Models.Pet;
    using System.Collections.Generic;

    public interface ILocationService
    {
        IEnumerable<PetServiceModel> GetPetsInRadius(double latitude, double longitude, double radius);
    }
}
