using System;
using System.Reflection;
using PixabayApi.ParameterConverters;
using PixabayApi.SearchParameters;

namespace PixabayApi
{
    internal class QueryBuilder
    {
        public string BuildImageQuery(string _key, ImagesSearchParameters _parameters)
        {
            if (string.IsNullOrWhiteSpace(_key))
                throw new ArgumentException("message", nameof(_key));

            if (_parameters == null)
                throw new ArgumentNullException(nameof(_parameters));

            try
            {
                ValidateImageParameters(_parameters);

                return InternalBuild(_key, _parameters);
            }
            catch (Exception ex)
            {
                throw new QueryBuilderException("Failed to build image query", ex);
            }
        }

        public string BuildVideoQuery(string _key, VideoSearchParameters _parameters)
        {
            if (string.IsNullOrWhiteSpace(_key))
                throw new ArgumentException("message", nameof(_key));

            if (_parameters == null)
                throw new ArgumentNullException(nameof(_parameters));

            try
            {
                ValidateVideoParameters(_parameters);

                return InternalBuild(_key, _parameters);
            }
            catch(Exception ex)
            {
                throw new QueryBuilderException("Failed to build video query", ex);
            }
        }

        private string InternalBuild(string _key, object _parameters)
        {
            var query = $"?key={_key}";

            var type = _parameters.GetType();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var searchAttr = property.GetCustomAttribute<SearchPropertyAttribute>();

                if (searchAttr == null)
                    continue;

                var queryValue = string.Empty;

                if (searchAttr.ConverterType == null)
                {
                    queryValue = property.GetValue(_parameters)?.ToString();

                    if (queryValue == null)
                        continue;
                }
                else
                {
                    var converter = (SearchFieldConverter) Activator.CreateInstance(searchAttr.ConverterType);

                    var propValue = property.GetValue(_parameters);

                    if (propValue == null)
                        continue;

                    queryValue = converter.Convert(propValue).ToString();
                }

                query += $"&{searchAttr.Name}={queryValue}";
            }

            return query;
        }


        private void ValidateVideoParameters(VideoSearchParameters _parameters)
        {
            if (string.IsNullOrWhiteSpace(_parameters.Query) && string.IsNullOrWhiteSpace(_parameters.Id))
                throw new ArgumentException($"{_parameters.Query} or {_parameters.Id} must be specified!");

            if (_parameters.MinWidth < 0)
                throw new ArgumentException($"{nameof(_parameters.MinWidth)} can not be lower than 0");


            if (_parameters.MinHeight < 0)
                throw new ArgumentException($"{nameof(_parameters.MinHeight)} can not be lower than 0");

            if (_parameters.Page < 1)
                throw new ArgumentException($"{nameof(_parameters.Page)} can not be lower than 1");

            if (_parameters.PerPage < 3 && _parameters.PerPage > 200)
                throw new ArgumentException($"{nameof(_parameters.PerPage)} must be in range 3-200");
        }

        private void ValidateImageParameters(ImagesSearchParameters _parameters)
        {
            if (string.IsNullOrWhiteSpace(_parameters.Query) && string.IsNullOrWhiteSpace(_parameters.Id))
                throw new ArgumentException($"{_parameters.Query} or {_parameters.Id} must be specified!");

            if (_parameters.MinWidth < 0)
                throw new ArgumentException($"{nameof(_parameters.MinWidth)} can not be lower than 0");


            if (_parameters.MinHeight < 0)
                throw new ArgumentException($"{nameof(_parameters.MinHeight)} can not be lower than 0");

            if (_parameters.Page < 1)
                throw new ArgumentException($"{nameof(_parameters.Page)} can not be lower than 1");

            if (_parameters.PerPage < 3 && _parameters.PerPage > 200)
                throw new ArgumentException($"{nameof(_parameters.PerPage)} must be in range 3-200");
        }
    }
}