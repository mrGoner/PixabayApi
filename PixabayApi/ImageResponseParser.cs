using System.Text.Json;
using PixabayApi.Models;

namespace PixabayApi
{
    internal class ResponseParser
    {
        public ImagesSearchResponse ParseImageResponse(string _data)
        {
            return JsonSerializer.Deserialize<ImagesSearchResponse>(_data);
        }

        public VideoSearchResponse ParseVideoResponse(string _data)
        {
            return JsonSerializer.Deserialize<VideoSearchResponse>(_data);
        }
    }
}
