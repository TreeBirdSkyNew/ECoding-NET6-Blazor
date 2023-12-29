using _4___E_CODING_DAL;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using Newtonsoft.Json;

namespace E_CODING_MVC_NET6_0
{
    public class TemplateTechniqueApiClient : ApiClientService, ITemplateTechniqueApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<TemplateTechniqueApiClient> _logger;
        private IConfiguration _configuration;

        public TemplateTechniqueApiClient(
            ILogger<TemplateTechniqueApiClient> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<TemplateTechniqueVM?> GetTemplateTechnique(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateTechniqueVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateTechniqueVM = JsonConvert.DeserializeObject<TemplateTechniqueVM>(contentStream);
                    if (templateTechniqueVM != null)
                        return templateTechniqueVM;
                }
            }
            return null;
        }

        public async Task<List<TemplateTechniqueVM?>> GetAllTemplateTechnique(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateTechniqueVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateTechniqueVM = JsonConvert.DeserializeObject<List<TemplateTechniqueVM>>(contentStream);
                    if (templateTechniqueVM != null)
                        return templateTechniqueVM;
                }
            }
            return null;
        }

        public async Task PostTemplateTechnique(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateTechniqueVM>(clientName, api, content);
        }

        public async Task DeleteTemplateTechnique(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateTechniqueVM>(clientName, api);
        }

        public async Task<TemplateTechniqueItemVM?> GetTemplateTechniqueItem(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateTechniqueItemVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateTechniqueItemVM = JsonConvert.DeserializeObject<TemplateTechniqueItemVM>(contentStream);
                    if (templateTechniqueItemVM != null)
                        return templateTechniqueItemVM;
                }
            }
            return null;
        }

        public async Task<List<TemplateTechniqueItemVM?>> GetAllTemplateTechniqueItem(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateTechniqueItemVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateTechniqueItemVM = JsonConvert.DeserializeObject<List<TemplateTechniqueItemVM>>(contentStream);
                    if (templateTechniqueItemVM != null)
                        return templateTechniqueItemVM;
                }
            }
            return null;
        }

        public async Task PostTemplateTechniqueItem(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateTechniqueItemVM>(clientName, api, content);
        }

        public async Task DeleteTemplateTechniqueItem(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateTechniqueItemVM>(clientName, api);
        }
    }
}
