using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace PixabayApi.ResponseConverters
{
    internal class ResponseTagsConverter : JsonConverter<string[]>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert == typeof(string[]))
                return true;

            return false;
        }

        public override string[] Read(ref Utf8JsonReader _reader, Type _typeToConvert, JsonSerializerOptions _options)
        {
            var value = _reader.GetString();

            return value.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(_x => _x.Trim()).ToArray();
        }

        public override void Write(Utf8JsonWriter _writer, string[] _value, JsonSerializerOptions _options)
        {
            throw new NotImplementedException();
        }
    }
}