using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WatchList.DTO.DTOs.External;
using WatchList.Business.Abstract;
using Microsoft.Extensions.Configuration;

public class TMDbSeriesService : ITMDbSeriesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    private readonly string _bearerToken;

    public TMDbSeriesService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["TMDb:ApiKey"];
        _baseUrl = configuration["TMDb:BaseUrl"];
        _bearerToken = configuration["TMDb:BearerToken"]; // Bearer Token'ı buradan alıyoruz
    }

    public async Task<List<TMDbSeriesSearchResultDto>> SearchSeriesAsync(string query)
    {
        var url = $"{_baseUrl}/search/tv?api_key={_apiKey}&query={Uri.EscapeDataString(query)}&language=tr-TR";

        // Bearer Token'ı header'a ekleyelim
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return new List<TMDbSeriesSearchResultDto>();

        var content = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(content);
        var results = jsonDoc.RootElement.GetProperty("results");

        var seriesList = new List<TMDbSeriesSearchResultDto>();

        foreach (var item in results.EnumerateArray())
        {
            seriesList.Add(new TMDbSeriesSearchResultDto
            {
                Id = item.GetProperty("id").GetInt32(),
                Title = item.GetProperty("name").GetString(), // Dizi adı "name" olarak gelir
                PosterPath = "https://image.tmdb.org/t/p/w500" + item.GetProperty("poster_path").GetString(),
            });
        }

        return seriesList;
    }
}
