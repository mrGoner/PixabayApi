using System.Text.Json.Serialization;

namespace PixabayApi.Models
{
    public class PixabayVideoInfo
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        public VideoSizeType SizeType { get; set; }
    }
}