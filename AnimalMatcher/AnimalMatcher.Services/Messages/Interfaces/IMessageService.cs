using AnimalMatcher.Data.Models;
using AnimalMatcher.Services.Models.Message;
using System.Collections.Generic;

namespace AnimalMatcher.Services.Messages.Interfaces
{
    public interface IMessageService
    {
        ICollection<MessageServiceModel> GetReceivedMessagesForPet(int PetId);
    }
}
