using System.Text.Json.Serialization;
using PixabayApi.ResponseConverters;

namespace PixabayApi.Models
{
    public class PixabayVideo
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("pageURL")]
        public string PageUrl { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(VideoTypeConverter))]
        public VideoType Type { get; set; }

        [JsonPropertyName("tags")]
        [JsonConverter(typeof(ResponseTagsConverter))]
        public string[] Tags { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("picture_id")]
        public string PictureId { get; set; }

        [JsonPropertyName("views")]
        public int Views { get; set; }

        [JsonPropertyName("downloads")]
        public int Downloads { get; set; }

        [JsonPropertyName("favorites")]
        public int Favorites { get; set; }

        [JsonPropertyName("likes")]
        public int Likes { get; set; }

        [JsonPropertyName("comments")]
        public int Comments { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("userImageURL")]
        public string UserImage { get; set; }

        [JsonPropertyName("videos")]
        [JsonConverter(typeof(VideosInfoConverter))]
        public PixabayVideoInfo[] VideosInfo { get; set; }
    }
}