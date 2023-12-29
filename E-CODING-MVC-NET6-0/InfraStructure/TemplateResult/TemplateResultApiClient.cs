using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_MVC_NET6_0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public class TemplateResultApiClient : ApiClientService, ITemplateResultApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<TemplateResultApiClient> _logger;
        private IConfiguration _configuration;

        public TemplateResultApiClient(
            ILogger<TemplateResultApiClient> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        /************************** TemplateResult *********************************************/
        public async Task<TemplateResultVM?> GetTemplateResult(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateResultVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateResultVM = JsonConvert.DeserializeObject<TemplateResultVM>(contentStream);
                    if (templateResultVM != null)
                        return templateResultVM;
                }
            }
            return null;
        }

        public async Task<List<TemplateResultVM?>> GetAllTemplateResult(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateResultVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateResultVM = JsonConvert.DeserializeObject<List<TemplateResultVM>>(contentStream);
                    if (templateResultVM != null)
                        return templateResultVM;
                }
            }
            return null;
        }

        public async Task PostTemplateResult(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateResultVM>(clientName, api, content);
        }

        public async Task DeleteTemplateResult(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateResultVM>(clientName, api);
        }

        /************************** TemplateResult *********************************************/
        public async Task<TemplateResultItemVM?> GetTemplateResultItem(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateResultItemVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateResultItemVM = JsonConvert.DeserializeObject<TemplateResultItemVM>(contentStream);
                    if (templateResultItemVM != null)
                        return templateResultItemVM;
                }
            }
            return null;
        }

        public async Task<List<TemplateResultItemVM?>> GetAllTemplateResultItem(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateResultItemVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateResultItemVM = JsonConvert.DeserializeObject<List<TemplateResultItemVM>>(contentStream);
                    if (templateResultItemVM != null)
                        return templateResultItemVM;
                }
            }
            return null;
        }

        public async Task PostTemplateResultItem(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateResultItemVM>(clientName, api, content);
        }

        public async Task DeleteTemplateResultItem(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateResultItemVM>(clientName, api);
        }
    }
}
