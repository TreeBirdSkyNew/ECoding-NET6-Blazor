using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.ApiClient
{
    public interface IApiClientService
    {
        Task<HttpResponseMessage> GetList<TReturn>(string clientName, string api);
        Task<HttpResponseMessage> GetObject<TReturn>(string clientName, string api);
        Task<HttpResponseMessage> PostObject<TReturn>(string clientName, string api, StringContent client);
        Task<HttpResponseMessage> DeleteObject<TReturn>(string clientName, string api);
    }
}
