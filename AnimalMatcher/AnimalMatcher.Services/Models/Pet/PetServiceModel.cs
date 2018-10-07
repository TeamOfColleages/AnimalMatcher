namespace AnimalMatcher.Services.Models.Pet
{
    using AnimalMatcher.Services.Models.Owner;

    public class PetServiceModel
    {
        public int Id { get; set; }

        public int Age { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public OwnerServiceModel Owner { get; set; }
    }
}
