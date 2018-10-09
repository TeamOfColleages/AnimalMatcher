namespace AnimalMatcher.Web.Infrastructure.Mapping
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Owner;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Web.Models.Owner;
    using AnimalMatcher.Web.Models.Pet;
    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.PetRegistrations();
            this.OwnerRegistrations();
        }

        private void PetRegistrations()
        {
            this.CreateMap<PetRegisterServiceModel, Pet>();

            this.CreateMap<PetInputModel, PetRegisterServiceModel>();

            this.CreateMap<PetWithOwnerServiceModel, PetDetailedViewModel>();

            this.CreateMap<Pet, PetServiceModel>();

            this.CreateMap<Pet, PetWithOwnerServiceModel>();

            this.CreateMap<PetServiceModel, Pet>();
        }

        private void OwnerRegistrations()
        {
            this.CreateMap<Owner, OwnerServiceModel>()
                .ForMember(ownerServiceModel => ownerServiceModel.Username, cfg => cfg.MapFrom(ownerDataModel => ownerDataModel.UserName));

            this.CreateMap<Owner, OwnerWithPetsServiceModel>();

            this.CreateMap<OwnerWithPetsServiceModel, OwnerViewModel>();
        }
    }
}
