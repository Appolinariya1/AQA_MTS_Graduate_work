using System.Text.Json.Serialization;

namespace Graduate_work.Models.API;

public class ErrorField
{
    [JsonPropertyName("field")] public string Field { get; set; }
    [JsonPropertyName("error")] public string Error { get; set; }
}