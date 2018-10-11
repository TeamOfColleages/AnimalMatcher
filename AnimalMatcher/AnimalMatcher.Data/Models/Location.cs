namespace AnimalMatcher.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        public int Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
