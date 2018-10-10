namespace AnimalMatcher.Services.Messages
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Messages.Interfaces;
    using AnimalMatcher.Services.Models.Message;
    using AnimalMatcher.Services.Pet;
    using AutoMapper;
    using System.Collections.Generic;

    public class MessageService : IMessageService
    {
        private readonly PetService petService;
        private readonly IMapper mapper;

        public MessageService(PetService petService, IMapper mapper)
        {
            this.petService = petService;
            this.mapper = mapper;
        }

        public ICollection<MessageServiceModel> GetReceivedMessagesForPet(int PetId)
        {
            var PetWithMessagesServiceModel = petService.GetPetWithMessagesServiceModelById(PetId);
            var ReceivedMessages = PetWithMessagesServiceModel.ReceivedMessages;
            
            return mapper.Map<ICollection<MessageServiceModel>>(ReceivedMessages);
        }
    }
}
