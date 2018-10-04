namespace AnimalMatcher.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 100)]
        public int Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
