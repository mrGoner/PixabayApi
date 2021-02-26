using PixabayApi.Models;
using PixabayApi.ParameterConverters;

namespace PixabayApi.SearchParameters
{
    public class ImagesSearchParameters
    {
        [SearchProperty("q", typeof(QueryToSearchConverter))]
        public string Query { get; set; }

        [SearchProperty("lang", typeof(EnumToSearchConverter))]
        public Language? Language { get; set; }

        [SearchProperty("id")]
        public string Id { get; set; }

        [SearchProperty("image_type", typeof(EnumToSearchConverter))]
        public ImageType? ImageType { get; set; }

        [SearchProperty("orientation", typeof(EnumToSearchConverter))]
        public Orientation? Orientation { get; set; }

        [SearchProperty("category", typeof(EnumToSearchConverter))]
        public Category? Category { get; set; }

        [SearchProperty("min_width")]
        public int? MinWidth { get; set; }

        [SearchProperty("min_height")]
        public int? MinHeight { get; set; }

        [SearchProperty("colors", typeof(EnumToSearchConverter))]
        public Color? Colors { get; set; }

        [SearchProperty("editors_choice")]
        public bool? IsEditorsChoice { get; set; }

        [SearchProperty("safesearch")]
        public bool? SafeSearch { get; set; }

        [SearchProperty("order", typeof(EnumToSearchConverter))]
        public OrderType? Order { get; set; }

        [SearchProperty("page")]
        public int? Page { get; set; }

        [SearchProperty("per_page")]
        public int? PerPage { get; set; }

        public ImagesSearchParameters(string _query)
        {
            Query = _query;
        }

        public ImagesSearchParameters()
        {

        }
    }
}