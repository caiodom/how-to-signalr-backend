using HowToSignalR.Chat.API.Hubs;
using HowToSignalR.Chat.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HowToSignalR.Chat.API.Controllers
{
    // Define an API controller to handle chat requests
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHub;

        // Constructor that injects the Hub context
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _chatHub=hubContext;
        }

        // HTTP POST endpoint to send messages
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto message)
        {
            // Send the message to all connected clients
            await _chatHub.Clients.All.SendAsync("ReceiveMessage", message.User, message.Message);
            return Ok();
        }

    }
}
