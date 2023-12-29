using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.Models;
using Newtonsoft.Json;

namespace E_CODING_MVC_NET6_0.InfraStructure.Solution
{
    public class TemplateSolutionApiClient : ApiClientService, ITemplateSolutionApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<TemplateSolutionApiClient> _logger;
        private IConfiguration _configuration;

        public TemplateSolutionApiClient(
            ILogger<TemplateSolutionApiClient> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<TemplateSolutionVM?> GetTemplateSolution(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateSolutionVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateSolution = JsonConvert.DeserializeObject<TemplateSolutionVM>(contentStream);
                    if (templateSolution != null)
                        return templateSolution;
                }
            }
            return null;
        }

        public async Task<List<TemplateSolutionVM?>> GetAllTemplateSolution(string clientName, string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateSolutionVM>(clientName, api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateSolution = JsonConvert.DeserializeObject<List<TemplateSolutionVM>>(contentStream);
                    if (templateSolution != null)
                        return templateSolution;
                }
            }
            return null;
        }

        public async Task PostTemplateSolution(string clientName, string api, StringContent content)
        {
            var httpResponseMessage = await PostObject<TemplateSolutionVM>(clientName, api, content);
        }

        public async Task DeleteTemplateSolution(string clientName, string api)
        {
            var httpResponseMessage = await DeleteObject<TemplateSolutionVM>(clientName, api);
        }
    }
}
