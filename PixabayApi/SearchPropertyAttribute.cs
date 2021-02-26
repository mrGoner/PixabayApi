using System;

namespace PixabayApi
{
    internal class SearchPropertyAttribute : Attribute
    {
        public string Name { get; }
        public Type ConverterType { get; }

        public SearchPropertyAttribute(string _name)
        {
            Name = _name;
        }

        public SearchPropertyAttribute(string _name, Type _converterType)
        {
            Name = _name;
            ConverterType = _converterType ?? throw new ArgumentNullException(nameof(_converterType));
        }
    }
}