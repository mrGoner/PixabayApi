using System;

namespace PixabayApi.ParameterConverters
{
    internal class EnumToSearchConverter : SearchFieldConverter<string, Enum>
    {
        public override string Convert(Enum _data)
        {
            return _data.ToString().Replace(" ", "").ToLower();
        }
    }
}