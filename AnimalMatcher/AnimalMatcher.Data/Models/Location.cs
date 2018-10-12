﻿namespace AnimalMatcher.Data.Models
{
    using AnimalMatcher.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        public int Id { get; set; }

        [Required]
        [Range(LocationConstants.DegreesMinValue, LocationConstants.DegreesMaxValue)]
        public double Latitude { get; set; }

        [Required]
        [Range(LocationConstants.DegreesMinValue, LocationConstants.DegreesMaxValue)]
        public double Longitude { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
