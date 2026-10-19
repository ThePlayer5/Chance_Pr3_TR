using Microsoft.AspNetCore.SignalR.Client;

namespace ChancePr3TRBlazor.ApiRequest.Services
{
    public class ChatService
    {
        private HubConnection _hubConnection;

        public List<int> ActiveUsers { get; set; } = new();
        public List<int> ChatUsers { get; set; } = new();

        public List<MessageModel> Messages { get; set; } = new();

        public Action OnActiveUsersUpdate { get; set; }
        public Action OnChatUsersUpdate { get; set; }
        public Action OnMessageReceived { get; set; }

        public async Task Connect()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7041/chat")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<List<int>>("UpdateActiveUsers", (activeUsers) =>
            {
                ActiveUsers = activeUsers;
                OnActiveUsersUpdate?.Invoke();
            });

            _hubConnection.On<List<int>>("UpdateChatUsers", (chatUsers) =>
            {
                ChatUsers = chatUsers;
                OnChatUsersUpdate?.Invoke();
            });

            _hubConnection.On<int, int, string, DateTime>("NewMessage", (chatId, senderId, text, sendTime) =>
            {
                Messages.Add(new MessageModel
                {
                    ChatId = chatId,
                    SenderId = senderId,
                    Text = text,
                    SendTime = sendTime
                });
                OnMessageReceived?.Invoke();
            });

            await _hubConnection.StartAsync();
        }

        public async Task AddActiveUser(int userId)
        {
            if (_hubConnection?.State == HubConnectionState.Connected)
            {
                await _hubConnection.InvokeAsync("AddActiveUser", userId);
                IsUserActive = true;
            }
        }

        public async Task AddChatUser(int userId, int chatId)
        {
            if (_hubConnection?.State == HubConnectionState.Connected)
            {
            await _hubConnection.InvokeAsync("AddChatUser", userId, chatId);
            }
        }

        public async Task SendMessage(int chatId, int senderId, string text)
        {
            if (_hubConnection?.State == HubConnectionState.Connected)
        {
            await _hubConnection.InvokeAsync("SendMessage", chatId, senderId, text);
        }
        }

        public bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;
        public bool IsUserActive { get; set; }
    }

    public class MessageModel
    {
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
    }
}
