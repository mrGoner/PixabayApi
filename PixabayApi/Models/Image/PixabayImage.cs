using System.Text.Json.Serialization;
using PixabayApi.ResponseConverters;

namespace PixabayApi.Models
{
    public class PixabayImage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("pageURL")]
        public string PageUrl { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(ImageTypeConverter))]
        public ImageType Type { get; set; }

        [JsonPropertyName("tags")]
        [JsonConverter(typeof(ResponseTagsConverter))]
        public string[] Tags { get; set; }

        [JsonPropertyName("previewURL")]
        public string PreviewUrl { get; set; }

        [JsonPropertyName("previewWidth")]
        public int PreviewWidth { get; set; }

        [JsonPropertyName("previewHeight")]
        public int PreviewHeight { get; set; }

        [JsonPropertyName("webformatURL")]
        public string WebFormatUrl { get; set; }

        [JsonPropertyName("webformatWidth")]
        public int WebFormatWidth { get; set; }

        [JsonPropertyName("webformatHeight")]
        public int WebFormatHeight { get; set; }

        [JsonPropertyName("largeImageURL")]
        public string LargeImageUrl { get; set; }

        [JsonPropertyName("fullHDURL")]
        public string FullHdUrl { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("imageWidth")]
        public int ImageWidth { get; set; }

        [JsonPropertyName("imageHeight")]
        public int ImageHeight { get; set; }

        [JsonPropertyName("imageSize")]
        public int ImageSize { get; set; }

        [JsonPropertyName("views")]
        public int Views { get; set; }

        [JsonPropertyName("downloads")]
        public int Downloads { get; set; }

        [JsonPropertyName("favorites")]
        public int Favorites { get; set; }

        [JsonPropertyName("likes")]
        public int Likes { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("userImageURL")]
        public string UserImageUrl { get; set; }
    }
}