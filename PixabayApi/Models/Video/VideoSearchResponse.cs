using System.Text.Json.Serialization;

namespace PixabayApi.Models
{
    public class VideoSearchResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("totalHits")]
        public int TotalHits { get; set; }

        [JsonPropertyName("hits")]
        public PixabayVideo[] Videos { get; set; }
    }
}