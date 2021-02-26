using System.Text.Json.Serialization;

namespace PixabayApi.Models
{
    public class ImagesSearchResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("totalHits")]
        public int TotalHits { get; set; }

        [JsonPropertyName("hits")]
        public PixabayImage[] Images { get; set; }
    }
}