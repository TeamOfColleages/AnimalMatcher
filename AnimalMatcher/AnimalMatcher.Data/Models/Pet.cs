namespace AnimalMatcher.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Pet
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

        public ICollection<Like> WhoYouLiked { get; set; } = new List<Like>();

        public ICollection<Like> WhoLikedYou { get; set; } = new List<Like>();
    }
}
