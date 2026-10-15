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
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginT { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
