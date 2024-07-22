namespace Ebtdaa.WebApi.Middlewares
{
    public class MyHttpClient
    {
        private readonly HttpClient _client;

        public MyHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetDataAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle error response
                return $"Error: {response.StatusCode}";
            }
        }
    }
}
