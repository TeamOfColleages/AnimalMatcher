namespace AnimalMatcher.Web.Controllers
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Pet.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : Controller
    {
        private readonly IPetService petService;
        private readonly UserManager<Owner> userManager;

        public OwnerController(IPetService petService, UserManager<Owner> userManager)
        {
            this.petService = petService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            string ownerId = this.userManager.GetUserId(this.User);
            var petsByOwner = this.petService.GetOwnersPets(ownerId);

            return this.View();
        }
    }
}
