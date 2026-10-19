namespace ChancePr3TRBlazor.ApiRequest.Models
{
    // Register
    public class RegUserData
    {
        public int userId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string fullname { get; set; }
        public string college { get; set; }
    }

    public class UserRegData
    {
        public bool status { get; set; }
    }

    // Authorize
    public class AuthUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public bool status { get; set; }
        public string? token { get; set; }
        public int userId { get; set; }
        public int roleId { get; set; }
    }

    // CheckProfile
    public class UserDataShort
    {
        public int userId { get; set; }
        public string? email { get; set; }
        public string? fullname { get; set; }
        public string? college { get; set; }
        public string? password { get; set; }
    }

    public class UserData
    {
        public UserDataShort data { get; set; }
        public bool status { get; set; }
    }
}
