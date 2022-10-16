using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI_RestSharp.Resources
{
    public class Endpoints
    {
        public static RestClient restClient;

        public static readonly string BaseURL = "https://petstore.swagger.io/v2/";

        public static readonly string PetsEndPoint = "pet";

        public static string GetURL(string endpoint) => $"{BaseURL}{endpoint}";

        public static Uri GetURI(string endpoint) => new Uri(GetURL(endpoint));

    }
}
