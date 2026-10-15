namespace ChancePr3TRBlazor.ApiRequest
{
    public class RequestApi
    {
        private readonly HttpClient _httpClient;

        public RequestApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


    }
}
