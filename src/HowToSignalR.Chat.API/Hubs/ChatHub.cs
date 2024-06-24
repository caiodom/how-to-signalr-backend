using Microsoft.AspNetCore.SignalR;

namespace HowToSignalR.Chat.API.Hubs
{
    // Define a Hub to manage chat messages
    public class ChatHub:Hub
    {
        // Method to send messages to all connected clients
        public async Task SendMessage(string user, string message)
        {
            // Send the message to all clients, invoking the "ReceiveMessage" method
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
