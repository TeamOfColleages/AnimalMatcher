namespace AnimalMatcher.Web.Infrastructure.Mapping
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Pet;
    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Pet, PetServiceModel>()
                .ForMember(petServiceModel => petServiceModel.OwnerName, cfg => cfg.MapFrom(petDataModel => petDataModel.Owner.UserName));
        }
    }
}
