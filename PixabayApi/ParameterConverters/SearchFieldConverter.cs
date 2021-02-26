namespace PixabayApi.ParameterConverters
{
    internal abstract class SearchFieldConverter<T, U> : SearchFieldConverter
    {
        public abstract T Convert(U _data);

        public override object Convert(object _data)
        {
            return Convert((U)_data);
        }
    }

    internal abstract class SearchFieldConverter
    {
        public abstract object Convert(object _data);
    }
}