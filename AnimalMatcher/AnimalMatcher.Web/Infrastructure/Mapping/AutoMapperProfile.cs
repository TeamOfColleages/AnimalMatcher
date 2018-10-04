namespace AnimalMatcher.Web.Infrastructure.Mapping
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Animal;
    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Animal, AnimalServiceModel>()
                .ForMember(animalServiceModel => animalServiceModel.OwnerName, cfg => cfg.MapFrom(animalDataModel => animalDataModel.Owner.Email));
        }
    }
}
