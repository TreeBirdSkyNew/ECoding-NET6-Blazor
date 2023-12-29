namespace E_CODING_FrontBlazor.Infrastructure.ApiClient
{
    public interface IApiClientService
    {
        Task<HttpResponseMessage> GetList<TReturn>(string clientName, string api);
        Task<HttpResponseMessage> GetObject<TReturn>(string clientName, string api);
        Task<HttpResponseMessage> PostObject<TReturn>(string clientName, string api, StringContent client);
        Task<HttpResponseMessage> PutObject<TReturn>(string clientName, string api, StringContent client);
        Task<HttpResponseMessage> DeleteObject<TReturn>(string clientName, string api);
    }
}
