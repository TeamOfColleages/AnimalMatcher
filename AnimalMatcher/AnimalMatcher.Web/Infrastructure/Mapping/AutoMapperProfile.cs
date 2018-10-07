namespace AnimalMatcher.Web.Infrastructure.Mapping
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Owner;
    using AnimalMatcher.Services.Models.Pet;
    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Pet, PetServiceModel>();

            this.CreateMap<Owner, OwnerServiceModel>()
                .ForMember(ownerServiceModel => ownerServiceModel.Username, cfg => cfg.MapFrom(ownerDataModel => ownerDataModel.UserName));
        }
    }
}
