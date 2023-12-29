using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction.ApiClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0.InfraStructure.Project
{
    public class TemplateProjectApiClient : ApiClientService, ITemplateProjectApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<TemplateProjectApiClient> _logger;
        private IConfiguration _configuration;

        public TemplateProjectApiClient(
            ILogger<TemplateProjectApiClient> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<TemplateProjectVM?> GetTemplateProject(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateProjectVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateProject = JsonConvert.DeserializeObject<TemplateProjectVM>(contentStream);
                    if (templateProject!=null)
                        return templateProject;
                }
            }
            return null;
        }

        public async Task<List<TemplateProjectVM?>> GetAllTemplateProject(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateProjectVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateProject = JsonConvert.DeserializeObject<List<TemplateProjectVM>>(contentStream);
                    if (templateProject!=null)
                        return templateProject;
                }
            }
            return null;
        }

        public async Task PostTemplateProject(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateProjectVM>(clientName, api, content);
        }

        public async Task DeleteTemplateProject(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateProjectVM>(clientName, api);
        }
    }
}
