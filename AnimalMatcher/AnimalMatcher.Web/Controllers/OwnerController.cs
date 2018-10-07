namespace AnimalMatcher.Web.Controllers
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Pet.Interfaces;
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

        public OwnerController(IPetService petService, UserManager<Owner> userManager, IMapper mapper)
        {
            this.petService = petService;
            this.userManager = userManager;
            this.mapper = mapper;
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
    }
}
