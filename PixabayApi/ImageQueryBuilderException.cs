using System;

namespace PixabayApi
{
    public class QueryBuilderException : Exception
    {
        public QueryBuilderException(string _message) : base(_message)
        {
        }

        public QueryBuilderException(string _message, Exception _innerException) : base(_message, _innerException)
        {
        }
    }
}