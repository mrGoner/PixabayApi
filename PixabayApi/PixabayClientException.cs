using System;

namespace PixabayApi
{
    public class PixabayClientException : Exception
    {
        public PixabayClientException(string _message) : base(_message)
        {
        }

        public PixabayClientException(string _message, Exception _innerException) : base(_message, _innerException)
        {
        }
    }
}