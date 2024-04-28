using System.Text.Json.Serialization;

namespace Graduate_work.Models.API;

public class Project
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}