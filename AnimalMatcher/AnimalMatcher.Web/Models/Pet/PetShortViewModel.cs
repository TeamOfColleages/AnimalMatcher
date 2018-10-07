namespace AnimalMatcher.Web.Models.Pet
{
    using System.ComponentModel.DataAnnotations;

    public class PetShortViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Owner username")]
        public string OwnerUsername { get; set; } 
    }
}
