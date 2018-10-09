
namespace AnimalMatcher.Services.Models.Owner
{
    using AnimalMatcher.Services.Models.Pet;
    using System.Collections.Generic;

    public class OwnerWithPetsServiceModel : OwnerServiceModel
    {
        public ICollection<PetWithOwnerServiceModel> Pets { get; set; }
    }
}
