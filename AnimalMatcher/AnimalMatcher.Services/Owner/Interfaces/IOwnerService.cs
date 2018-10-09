using AnimalMatcher.Services.Models.Owner;

namespace AnimalMatcher.Services.Owner.Interfaces
{

    public interface IOwnerService
    {
        OwnerWithPetsServiceModel GetOwnerWithPetsById(string id);
    }
}
