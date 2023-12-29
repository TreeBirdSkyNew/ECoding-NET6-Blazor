using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.Models;
using Newtonsoft.Json;

namespace E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel
{
    public class TemplateFonctionnelApiClient : ApiClientService, ITemplateFonctionnelApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<TemplateFonctionnelApiClient> _logger;
        private IConfiguration _configuration;

        public TemplateFonctionnelApiClient(
            ILogger<TemplateFonctionnelApiClient> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        /************************ TemplateFonctionnel ***************************************************/
        public async Task<TemplateFonctionnelVM?> GetTemplateFonctionnel(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateFonctionnelVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateFonctionnel = JsonConvert.DeserializeObject<TemplateFonctionnelVM>(contentStream);
                    if (templateFonctionnel != null)
                        return templateFonctionnel;
                }
            }
            return null;
        }

        public async Task<List<TemplateFonctionnelVM?>> GetAllTemplateFonctionnel(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateFonctionnelVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateFonctionnel = JsonConvert.DeserializeObject<List<TemplateFonctionnelVM>>(contentStream);
                    if (templateFonctionnel != null)
                        return templateFonctionnel;
                }
            }
            return null;
        }

        public async Task PostTemplateFonctionnel(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateFonctionnelVM>(clientName, api, content);
        }

        public async Task DeleteTemplateFonctionnel(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateFonctionnelVM>(clientName, api);
        }

        /************************ TemplateFonctionnelEntity ***************************************************/
        public async Task<TemplateFonctionnelEntityVM?> GetTemplateFonctionnelEntity(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateFonctionnelEntityVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateFonctionnelEntity = JsonConvert.DeserializeObject<TemplateFonctionnelEntityVM>(contentStream);
                    if (templateFonctionnelEntity != null)
                        return templateFonctionnelEntity;
                }
            }
            return null;
        }

        public async Task<List<TemplateFonctionnelEntityVM?>> GetAllTemplateFonctionnelEntity(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateFonctionnelEntityVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateFonctionnelEntity = JsonConvert.DeserializeObject<List<TemplateFonctionnelEntityVM>>(contentStream);
                    if (templateFonctionnelEntity != null)
                        return templateFonctionnelEntity;
                }
            }
            return null;
        }

        public async Task PostTemplateFonctionnelEntity(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateFonctionnelEntityVM>(clientName, api, content);
        }

        public async Task DeleteTemplateFonctionnelEntity(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateFonctionnelEntityVM>(clientName, api);
        }

        /************************ TemplateFonctionnelProperty ***************************************************/
        public async Task<TemplateFonctionnelPropertyVM?> GetTemplateFonctionnelProperty(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateFonctionnelPropertyVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateFonctionnelProperty = JsonConvert.DeserializeObject<TemplateFonctionnelPropertyVM>(contentStream);
                    if (templateFonctionnelProperty != null)
                        return templateFonctionnelProperty;
                }
            }
            return null;
        }

        public async Task<List<TemplateFonctionnelPropertyVM?>> GetAllTemplateFonctionnelProperty(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateFonctionnelPropertyVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateFonctionnelProperty = JsonConvert.DeserializeObject<List<TemplateFonctionnelPropertyVM>>(contentStream);
                    if (templateFonctionnelProperty != null)
                        return templateFonctionnelProperty;
                }
            }
            return null;
        }

        public async Task PostTemplateFonctionnelProperty(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateFonctionnelPropertyVM>(clientName, api, content);
        }

        public async Task DeleteTemplateFonctionnelProperty(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateFonctionnelPropertyVM>(clientName, api);
        }
    }
}
