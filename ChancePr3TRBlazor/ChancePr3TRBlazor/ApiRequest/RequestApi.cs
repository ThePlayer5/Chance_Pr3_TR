using ChancePr3TRBlazor.ApiRequest.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ChancePr3TRBlazor.ApiRequest
{
    public class RequestApi
    {
        private readonly HttpClient _httpClient;

        public RequestApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // MOOD
        public async Task<MoodData> GetMoodAsync()
        {
            var url = "api/User/GetMood";

            try
            {
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(responseContent))
                {
                    return new MoodData();
                }

                var data = JsonSerializer.Deserialize<MoodData>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                return data ?? new MoodData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе: {ex.Message}");
                return new MoodData();
            }
        }

        public async Task<MoodCreateData> CreateMoodAsync(string authorization, ReqDataMood reqDataMood)
        {
            var url = $"api/User/CreateMood";

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization);
                request.Content = JsonContent.Create(reqDataMood);

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseContent))
                {
                    return new MoodCreateData();
                }

                var data = JsonSerializer.Deserialize<MoodCreateData>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                return data ?? new MoodCreateData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе: {ex.Message}");
                return new MoodCreateData();
            }
        }

        // DOCTOR
        public async Task<DocsData> GetDoctorsAsync()
        {
            var url = "api/User/GetDoctors";

            try
            {
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(responseContent))
                {
                    return new DocsData();
                }

                var data = JsonSerializer.Deserialize<DocsData>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                return data ?? new DocsData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе: {ex.Message}");
                return new DocsData();
            }
        }

        // USER ACCOUNT
        public async Task<UserRegData> RegisterAsync(RegUserData regUserData)
        {
            var url = "api/Auth/Register";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, regUserData);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<UserRegData>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                return data ?? new UserRegData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе: {ex.Message}");
                return new UserRegData();
            }
        }

        public async Task<AuthResponse> AuthUserAsync(AuthUser authUser)
        {
            var url = "api/Auth/Authorize";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, authUser);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseContent))
                {
                    return new AuthResponse();
                }

                var data = JsonSerializer.Deserialize<AuthResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return data ?? new AuthResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе: {ex.Message}");
                return new AuthResponse();
            }
        }

        public async Task<UserData> CheckProfileAsync(string authorization)
        {
            var url = $"api/User/CheckProfile";

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization);

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();


                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(responseContent))
                {
                    return new UserData();
                }

                var data = JsonSerializer.Deserialize<UserData>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                return data ?? new UserData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе: {ex.Message}");
                return new UserData();
            }
        }
    }
}
