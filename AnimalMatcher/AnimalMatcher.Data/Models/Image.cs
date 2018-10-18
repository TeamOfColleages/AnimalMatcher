namespace AnimalMatcher.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }
    }
}
