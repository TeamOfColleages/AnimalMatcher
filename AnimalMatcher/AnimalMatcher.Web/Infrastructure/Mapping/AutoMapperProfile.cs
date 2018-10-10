namespace AnimalMatcher.Web.Infrastructure.Mapping
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Message;
    using AnimalMatcher.Services.Models.Owner;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Web.Models.Message;
    using AnimalMatcher.Web.Models.Owner;
    using AnimalMatcher.Web.Models.Pet;
    using AutoMapper;
    using System.Collections.Generic;

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

            this.CreateMap<Pet, PetWithOwnerServiceModel>();

            this.CreateMap<Pet, PetServiceModel>();

            this.CreateMap<Pet, PetWithMessagesServiceModel>();
        }

        private void OwnerRegistrations()
        {
            this.CreateMap<Owner, OwnerServiceModel>()
                .ForMember(ownerServiceModel => ownerServiceModel.Username, cfg => cfg.MapFrom(ownerDataModel => ownerDataModel.UserName));

            this.CreateMap<Owner, OwnerWithPetsServiceModel>();

            this.CreateMap<OwnerWithPetsServiceModel, OwnerViewModel>();
        }

        private void MessageRegistrations()
        {
            this.CreateMap<ICollection<Message>, ICollection<MessageServiceModel>>();
            this.CreateMap<MessageServiceModel, MessageViewModel>();
        }
    }
}
