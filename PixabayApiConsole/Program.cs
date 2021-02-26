using System;
using System.Threading.Tasks;
using PixabayApi;
using PixabayApi.SearchParameters;

namespace PixabayApiConsole
{
    class Program
    {
        static void Main(string[] _args)
        {
            _ = Examples();
            Console.ReadKey();
        }

        private static async Task Examples()
        {
            var client = new PixabayClient("YourToken");

            var responseImages = await client.SearchImagesAsync(new ImagesSearchParameters("Dogs"));
            
            Console.WriteLine($"Found {responseImages.Images.Length} images. Total {responseImages.Total}");
           
            var responseVideos = await client.SearchVideosAsync(new VideoSearchParameters("Dogs"));
            
            Console.WriteLine($"Found {responseVideos.Videos.Length} videos. Total {responseVideos.Total}");
        }
    }
}
