﻿namespace AnimalMatcher.Web.Models.Pet
{
    using System.ComponentModel.DataAnnotations;
    using AnimalMatcher.Common.Constants;

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

        [Display(Name = "Pet location latitude")]
        [Range(LocationConstants.DegreesMinValue, LocationConstants.DegreesMaxValue)]
        public double Latitude { get; set; }

        [Display(Name = "Pet location logitude")]
        [Range(LocationConstants.DegreesMinValue, LocationConstants.DegreesMaxValue)]
        public double Longitude { get; set; }
    }
}
