namespace AnimalMatcher.Web.Models.Owner
{
    using AnimalMatcher.Web.Models.Pet;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OwnerViewModel
    {
        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public ICollection<PetShortViewModel> Pets { get; set; }
    }
}
