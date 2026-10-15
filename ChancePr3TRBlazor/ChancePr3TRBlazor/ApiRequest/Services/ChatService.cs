using Microsoft.AspNetCore.SignalR.Client;

namespace ChancePr3TRBlazor.ApiRequest.Services
{
    public class ChatService
    {
        private HubConnection _hubConnection;



        public async Task Connect()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("") // вставить ссылку из подключения к Api и добавить /chat
                .WithAutomaticReconnect()
                .Build();

            await _hubConnection.StartAsync();
        }

        public bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;
        public bool IsUserActive { get; set; }
    }
}
