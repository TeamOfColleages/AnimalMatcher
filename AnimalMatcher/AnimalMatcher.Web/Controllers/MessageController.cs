namespace AnimalMatcher.Web.Controllers
{
    using AnimalMatcher.Services.Messages;
    using AnimalMatcher.Web.Models.Message;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class MessageController : Controller
    {
        private readonly MessageService messageService;
        private readonly IMapper mapper;

        public MessageController(MessageService messageService, IMapper mapper)
        {
            this.messageService = messageService;
            this.mapper = mapper;
        }

        public IActionResult Messages(int PetId)
        {
            var ReceivedMessagesServiceModel = messageService.GetReceivedMessagesForPet(PetId);
            var ReceivedMessagesViewModel = mapper.Map<MessageViewModel>(ReceivedMessagesServiceModel);
            return View(ReceivedMessagesViewModel);
        }
    }
}
