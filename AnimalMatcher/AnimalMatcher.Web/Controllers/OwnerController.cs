namespace AnimalMatcher.Web.Controllers
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Animal.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly UserManager<Owner> userManager;

        public OwnerController(IAnimalService animalService, UserManager<Owner> userManager)
        {
            this.animalService = animalService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            string ownerId = this.userManager.GetUserId(this.User);
            var animalsByOwner = this.animalService.GetOwnersAnimals(ownerId);

            return this.View();
        }
    }
}
