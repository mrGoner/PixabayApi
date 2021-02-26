using System;
using System.Net.Http;
using System.Threading.Tasks;
using PixabayApi.Models;
using PixabayApi.SearchParameters;

namespace PixabayApi
{
    public class PixabayClient
    {
        private readonly HttpClient m_httpClient;
        private readonly string m_apiKey;
        private readonly QueryBuilder m_queryBuilder;
        private readonly ResponseParser m_responseParser;

        public PixabayClient(string _apiKey)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new ArgumentException($"{nameof(_apiKey)} can not be null or white space", nameof(_apiKey));

            m_apiKey = _apiKey;

            m_httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://pixabay.com/api/")
            };

            m_queryBuilder = new QueryBuilder();
            m_responseParser = new ResponseParser();
        }

        public async Task<ImagesSearchResponse> SearchImagesAsync(ImagesSearchParameters _parameters)
        {
            if (_parameters is null)
                throw new ArgumentNullException(nameof(_parameters));

            try
            {
                var query = m_queryBuilder.BuildImageQuery(m_apiKey, _parameters);

                var response = await m_httpClient.GetAsync(query);

                response.EnsureSuccessStatusCode();

                var contentRaw = await response.Content.ReadAsStringAsync();

                var result = m_responseParser.ParseImageResponse(contentRaw);

                return result;
            }
            catch(Exception ex)
            {
                throw new PixabayClientException("Failed to search image", ex);
            }
        }

        public async Task<VideoSearchResponse> SearchVideosAsync(VideoSearchParameters _parameters)
        {
            if (_parameters is null)
                throw new ArgumentNullException(nameof(_parameters));

            try
            {
                var query = m_queryBuilder.BuildVideoQuery(m_apiKey, _parameters);

                var response = await m_httpClient.GetAsync($"videos/{query}");

                response.EnsureSuccessStatusCode();

                var contentRaw = await response.Content.ReadAsStringAsync();

                var result = m_responseParser.ParseVideoResponse(contentRaw);

                return result;
            }
            catch(Exception ex)
            {
                throw new PixabayClientException("Failed to search videos", ex);
            }
        }
    }
}