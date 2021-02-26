using System.Web;

namespace PixabayApi.ParameterConverters
{
    internal class QueryToSearchConverter : SearchFieldConverter<string, string>
    {
        public override string Convert(string _data)
        {
            return HttpUtility.UrlEncode(_data);
        }
    }
}