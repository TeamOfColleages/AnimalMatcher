namespace AnimalMatcher.Web.Models.Message
{
    using AnimalMatcher.Web.Models.Pet;

    public class MessageViewModel
    {
        public PetShortViewModel Sender { get; set; }

        public string Body { get; set; }
    }
}
