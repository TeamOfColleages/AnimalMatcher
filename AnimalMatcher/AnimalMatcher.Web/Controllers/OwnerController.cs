namespace AnimalMatcher.Web.Controllers
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Owner.Interfaces;
    using AnimalMatcher.Services.Pet.Interfaces;
    using AnimalMatcher.Web.Models.Owner;
    using AnimalMatcher.Web.Models.Pet;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class OwnerController : Controller
    {
        private readonly IPetService petService;
        private readonly UserManager<Owner> userManager;
        private readonly IMapper mapper;
        private readonly IOwnerService ownerService;

        public OwnerController(IPetService petService, UserManager<Owner> userManager, IMapper mapper, IOwnerService ownerService)
        {
            this.petService = petService;
            this.userManager = userManager;
            this.mapper = mapper;
            this.ownerService = ownerService;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            string ownerId = this.userManager.GetUserId(this.User);
            var petsByOwner = this.petService
                .GetOwnersPets(ownerId)
                .Select(petServiceModel => this.mapper.Map<PetShortViewModel>(petServiceModel));

            return this.View(petsByOwner);
        }

        public IActionResult Details(string id)
        {
            var ownerWithPets = ownerService.GetOwnerWithPetsById(id);
            var ownerWithPetsViewModel = this.mapper.Map<OwnerViewModel>(ownerWithPets);
            return this.View(ownerWithPetsViewModel);
        }
    }
}
