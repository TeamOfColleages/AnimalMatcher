namespace AnimalMatcher.Services.Models.Animal
{
    public class AnimalServiceModel
    {
        public int Id { get; set; }

        public int Age { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string OwnerId { get; set; }

        public string OwnerName { get; set; }
    }
}
