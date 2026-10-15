using Authorize_chanse.DatabaseContext;
using Microsoft.AspNetCore.SignalR;

namespace Authorize_chanse.Hubs
{
    public class ChatHub : Hub
    {
        private readonly Contextdatabase _context;

        public ChatHub (Contextdatabase context) { _context = context; }

        public static Dictionary<int, string> ActiveUsers = new();
        public static Dictionary<int, string> ChatUsers = new();

        public async Task AddActiveUser(int userId)
        {
            if (ActiveUsers.ContainsKey(userId)) return;

            ActiveUsers[userId] = Context.ConnectionId;
            await Clients.All.SendAsync("UpdateActiveUsers", ActiveUsers.Keys.ToList());
        }

        public async Task AddChatUser(int userId, int chatId)
        {
            if (ChatUsers.ContainsKey(userId)) return;

            ChatUsers[userId] = Context.ConnectionId;

            string chatGroup = chatId.ToString();

            await Groups.AddToGroupAsync(ChatUsers[userId], chatGroup);
            await Clients.Group(chatGroup).SendAsync("UpdateChatUsers", ChatUsers.Keys.ToList());
        }

        public async Task SendMessage(int chatId, int senderId, string text)
        {
            string chatGroup = chatId.ToString();

            await Clients.Group(chatGroup).SendAsync("NewMessage", chatId, senderId, text, DateTime.UtcNow);
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            var activeUser = ActiveUsers.FirstOrDefault(au => au.Value == Context.ConnectionId);

            if (activeUser.Key != null)
            {
                ActiveUsers.Remove(activeUser.Key);
                await Clients.All.SendAsync("UpdateActiveUsers", ActiveUsers.Keys.ToList());
            }

            var chatUser = ChatUsers.FirstOrDefault(cu => cu.Value == Context.ConnectionId);

            if (chatUser.Key != null)
            {
                ChatUsers.Remove(chatUser.Key);
                await Clients.All.SendAsync("UpdateChatUsers", ChatUsers.Keys.ToList());
            }

            await base.OnDisconnectedAsync(ex);
        }
    }
}
