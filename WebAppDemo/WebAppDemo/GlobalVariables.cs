using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApimvc
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient;

        static GlobalVariables()
        {
            WebApiClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:1042/api/")
            };
        }
    }
}