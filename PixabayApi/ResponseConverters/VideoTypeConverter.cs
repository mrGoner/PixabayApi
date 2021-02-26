using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PixabayApi.Models;

namespace PixabayApi.ResponseConverters
{
    internal class VideoTypeConverter : JsonConverter<VideoType>
    {
        public override bool CanConvert(Type _typeToConvert)
        {
            if (_typeToConvert == typeof(VideoType))
                return true;

            return false;
        }

        public override VideoType Read(ref Utf8JsonReader _reader, Type _typeToConvert, JsonSerializerOptions _options)
        {
            string value = _reader.GetString();

            return value switch
            {
                "all" => VideoType.All,
                "film" => VideoType.Film,
                "animation" => VideoType.Animation,
                _ => throw new ArgumentOutOfRangeException($"value {value} not expected"),
            };
        }

        public override void Write(Utf8JsonWriter _writer, VideoType _value, JsonSerializerOptions _options)
        {
            throw new NotImplementedException();
        }
    }
}