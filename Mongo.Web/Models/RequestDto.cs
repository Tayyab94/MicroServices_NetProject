using static Mongo.Web.Utility.SD;

using System.Net.Mime;

namespace Mongo.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        public Utility.SD.ContentType contentType { get; set; } = Utility.SD.ContentType.Json;
    }
}
