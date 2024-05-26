
using Newtonsoft.Json;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

public class OmdbApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "dc4771ca"; // Replace with your IMDb API key

    public OmdbApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Movie> GetMovieByIdAsync(string id)
    {
        var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={_apiKey}&i={id}");
        return JsonConvert.DeserializeObject<Movie>(response);
    }

    public async Task<MovieSearchResult> SearchMoviesAsync(string keyword)
    {
        Console.WriteLine(keyword);
        var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={_apiKey}&t={keyword}");
        
        return JsonConvert.DeserializeObject<MovieSearchResult>(response);
    }

    public async Task<Movie> GetMovieByTitle(string title)
    {
        var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={_apiKey}&t={title}");
        return JsonConvert.DeserializeObject<Movie>(response);
    }
}

public class MovieSearchResult
{
    public List<Movie> Results { get; set; }
}


