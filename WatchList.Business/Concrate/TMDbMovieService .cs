using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WatchList.DTO.DTOs.External;
using WatchList.Business.Abstract;

public class TMDbMovieService : ITMDbMovieService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    private readonly string _bearerToken;

    public TMDbMovieService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["TMDb:ApiKey"];
        _baseUrl = configuration["TMDb:BaseUrl"];
        _bearerToken = configuration["TMDb:BearerToken"]; // Bearer Token'ı buradan alıyoruz
    }

    public async Task<List<TMDbMovieSearchResultDto>> SearchMoviesAsync(string query)
    {
        var url = $"{_baseUrl}/search/movie?api_key={_apiKey}&query={Uri.EscapeDataString(query)}&language=tr-TR";

        // Bearer Token'ı header'a ekleyelim
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return new List<TMDbMovieSearchResultDto>();

        var content = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(content);
        var results = jsonDoc.RootElement.GetProperty("results");

        var movies = new List<TMDbMovieSearchResultDto>();

        foreach (var item in results.EnumerateArray())
        {
            movies.Add(new TMDbMovieSearchResultDto
            {
                Id = item.GetProperty("id").GetInt32(),
                Title = item.GetProperty("title").GetString(),
                ReleaseDate = item.GetProperty("release_date").GetString(),
                PosterPath = "https://image.tmdb.org/t/p/w500" + item.GetProperty("poster_path").GetString()
            });
        }

        return movies;
    }
}
