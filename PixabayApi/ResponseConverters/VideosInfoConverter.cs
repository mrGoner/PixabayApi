using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using PixabayApi.Models;

namespace PixabayApi.ResponseConverters
{
    internal class VideosInfoConverter : JsonConverter<PixabayVideoInfo[]>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert == typeof(PixabayVideoInfo[]))
                return true;

            return false;
        }

        public override PixabayVideoInfo[] Read(ref Utf8JsonReader _reader, Type _typeToConvert, JsonSerializerOptions _options)
        {
            var videos = new List<PixabayVideoInfo>(4);

            _reader.Read();

            while (_reader.TokenType != JsonTokenType.EndObject)
            {
                var videoSizeTypeRaw = _reader.GetString();

                var videoInfo = JsonSerializer.Deserialize<PixabayVideoInfo>(ref _reader);

                videoInfo.SizeType = videoSizeTypeRaw switch
                {
                    "large" => VideoSizeType.Large,
                    "small" => VideoSizeType.Small,
                    "tiny" => VideoSizeType.Tiny,
                    "medium" => VideoSizeType.Medium,
                    _ => throw new ArgumentOutOfRangeException($"Unexpected video size type {videoSizeTypeRaw}")
                };

                videos.Add(videoInfo);

                if (_reader.TokenType == JsonTokenType.EndObject)
                    _reader.Read();
            }

            return videos.ToArray();
        }

        public override void Write(Utf8JsonWriter _writer, PixabayVideoInfo[] _value, JsonSerializerOptions _options)
        {
            throw new NotImplementedException();
        }
    }
}
