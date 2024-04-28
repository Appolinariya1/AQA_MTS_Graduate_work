using System.Text.Json.Serialization;

namespace Graduate_work.Models.API;

public class BaseApiResult<T>
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public T? Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
}