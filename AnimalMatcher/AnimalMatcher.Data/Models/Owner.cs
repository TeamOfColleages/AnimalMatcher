namespace AnimalMatcher.Data.Models
{
    using AnimalMatcher.Common.Constants;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Owner : IdentityUser
    {
        [Required]
        [MinLength(OwnerConstants.NameMinLength)]
        [MaxLength(OwnerConstants.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
