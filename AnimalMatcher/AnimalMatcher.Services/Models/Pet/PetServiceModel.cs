namespace AnimalMatcher.Services.Models.Pet
{
    using System;
    using AnimalMatcher.Services.Models.Owner;

    public class PetServiceModel
    {
        public int Id { get; set; }

        public int Age { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
