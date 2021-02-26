using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PixabayApi.Models;

namespace PixabayApi.ResponseConverters
{
    internal class ImageTypeConverter : JsonConverter<ImageType>
    {
        public override bool CanConvert(Type _typeToConvert)
        {
            if (_typeToConvert == typeof(ImageType))
                return true;

            return false;
        }

        public override ImageType Read(ref Utf8JsonReader _reader, Type _typeToConvert, JsonSerializerOptions _options)
        {
            string value = _reader.GetString();

            return value switch
            {
                "all" => ImageType.All,
                "illustration" => ImageType.Illustration,
                "photo" => ImageType.Photo,
                "vector" => ImageType.Vector,
                "vector/svg" => ImageType.Vector,
                _ => throw new ArgumentOutOfRangeException($"value {value} not expected"),
            };
        }

        public override void Write(Utf8JsonWriter _writer, ImageType _value, JsonSerializerOptions _options)
        {
            throw new NotImplementedException();
        }
    }
}