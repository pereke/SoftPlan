using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SoftPlan.CalcRate.Application.HttpService
{
    public static class GenerateHttpClient
    {
        public static HttpClient GenareteHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            var client = new HttpClient(clientHandler);

            return client;
        }
    }
}
