using PixabayApi.Models;
using PixabayApi.ParameterConverters;

namespace PixabayApi.SearchParameters
{
    public class VideoSearchParameters
    {
        [SearchProperty("q", typeof(QueryToSearchConverter))]
        public string Query { get; set; }

        [SearchProperty("lang", typeof(EnumToSearchConverter))]
        public Language? Language { get; set; }

        [SearchProperty("id")]
        public string Id { get; set; }

        [SearchProperty("video_type", typeof(EnumToSearchConverter))]
        public VideoType? VideoType { get; set; }

        [SearchProperty("category", typeof(EnumToSearchConverter))]
        public Category? Category { get; set; }

        [SearchProperty("min_width")]
        public int? MinWidth { get; set; }

        [SearchProperty("min_height")]
        public int? MinHeight { get; set; }

        [SearchProperty("editors_choice")]
        public bool? EditorsChoice { get; set; }

        [SearchProperty("safesearch")]
        public bool? SafeSearch { get; set; }

        [SearchProperty("order", typeof(EnumToSearchConverter))]
        public OrderType? Order { get; set; }

        [SearchProperty("page")]
        public int? Page { get; set; }

        [SearchProperty("per_page")]
        public int? PerPage { get; set; }

        public VideoSearchParameters(string _query)
        {
            Query = _query;
        }

        public VideoSearchParameters()
        {

        }
    }
}