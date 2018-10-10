
namespace AnimalMatcher.Services.Models.Pet
{
    using AnimalMatcher.Data.Models;
    using System.Collections.Generic;

    public class PetWithMessagesServiceModel : PetServiceModel
    {
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
