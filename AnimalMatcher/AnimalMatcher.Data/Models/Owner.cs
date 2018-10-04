namespace AnimalMatcher.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class Owner : IdentityUser
    {
        public ICollection<Animal> Pets { get; set; } = new List<Animal>();
    }
}
