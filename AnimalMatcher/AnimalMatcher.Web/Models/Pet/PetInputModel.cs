namespace AnimalMatcher.Web.Models.Pet
{
    using AnimalMatcher.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class PetInputModel
    {
        [Required]
        [Range(PetConstants.MinAge, PetConstants.MaxAge)]
        public int Age { get; set; }

        [Required]
        [MaxLength(PetConstants.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(PetConstants.DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
