using System;
using System.Net.Http;

namespace HoldetManager.Infrastructure.Queries
{
    public class HoldetBaseQuery
    {
        protected readonly IHttpClientFactory HttpClientFactory;

        public HoldetBaseQuery(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }
    }
}
