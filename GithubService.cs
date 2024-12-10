using System.Diagnostics;
using System.Text.Json;
using github_activity.Model;

namespace github_activity;


public class GithubService
{
    private readonly HttpClient _httpClient = new HttpClient();
    
    public async Task<List<Event>> GetActivityForUser(string username)
    {
        string url = $"https://api.github.com/users/{username}/events";
        _httpClient.DefaultRequestHeaders.Add("User-agent", "github-activity");
        var response = await _httpClient.GetStringAsync(url);
        var events = JsonSerializer.Deserialize<List<Event>>(response);
        Console.WriteLine($"Fetched {events.Count} events for {username}");
        return events;
    }
}