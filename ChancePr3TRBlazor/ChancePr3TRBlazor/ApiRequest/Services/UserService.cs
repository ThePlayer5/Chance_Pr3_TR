namespace ChancePr3TRBlazor.ApiRequest.Services
{
    public class UserService
    {
        public User CurrentUser { get; private set; }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetUser(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            CurrentUser = null;
        }
    }

    public class User
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public string? token { get; set; }
    }
}
