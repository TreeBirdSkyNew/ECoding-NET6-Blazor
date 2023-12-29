

using E_CODING_Service_Abstraction.ApiClient;

namespace E_CODING_MVC_NET6_0.InfraStructure.ApiClient
{
    public class ApiClientService : IApiClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetList<TReturn>(string clientName, string urlApi)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(urlApi);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage;
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }

        public async Task<HttpResponseMessage> GetObject<TReturn>(string clientName, string urlApi)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(urlApi);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage;
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }

        public async Task<HttpResponseMessage> PostObject<TReturn>(string clientName, string urlApi, StringContent client)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(urlApi, client);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage;
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }

        public async Task<HttpResponseMessage> DeleteObject<TReturn>(string clientName, string urlApi)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync(urlApi);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage;
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }

        
    }
}
