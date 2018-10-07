namespace AnimalMatcher.Data.Models
{
    using AnimalMatcher.Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [Range(PetConstants.MinAge, PetConstants.MaxAge)]
        public int Age { get; set; }

        [Required]
        [MaxLength(PetConstants.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(PetConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public Owner Owner { get; set; }

        public ICollection<Like> WhoYouLiked { get; set; } = new List<Like>();

        public ICollection<Like> WhoLikedYou { get; set; } = new List<Like>();

        public ICollection<Message> SentMessages { get; set; } = new List<Message>();

        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
