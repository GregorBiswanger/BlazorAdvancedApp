using System.Reactive.Subjects;
using System.Text.Json;

namespace BlazorAdvancedApp.Pages.Index.Services
{
    public class ChucknorrisService : IChucknorrisService
    {
        private readonly HttpClient _httpClient;

        public BehaviorSubject<bool> ReloadJoke { get; set; } = new BehaviorSubject<bool>(false);

        public ChucknorrisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Joke> LoadJokeAsync()
        {
            var url = "https://api.chucknorris.io/jokes/random?category=dev";
            var result = await _httpClient.GetAsync(url);
            return await result.Content.ReadFromJsonAsync<Joke>();

            // For the Blazor 5 user
            //var stream = await result.Content.ReadAsStreamAsync();
            //return await JsonSerializer.DeserializeAsync<Joke>(stream);
        }
    }

    public class Joke
    {
        public string[] categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}
