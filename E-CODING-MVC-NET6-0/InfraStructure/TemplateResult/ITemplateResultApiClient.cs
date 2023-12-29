using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public interface ITemplateResultApiClient
    {
        Task<TemplateResultVM> GetTemplateResult(string clientName, string api);
        Task<List<TemplateResultVM>> GetAllTemplateResult(string clientName, string api);
        Task PostTemplateResult(string clientName, string api, StringContent client);
        Task DeleteTemplateResult(string clientName, string api);

        Task<TemplateResultItemVM> GetTemplateResultItem(string clientName, string api);
        Task<List<TemplateResultItemVM>> GetAllTemplateResultItem(string clientName, string api);
        Task PostTemplateResultItem(string clientName, string api, StringContent client);
        Task DeleteTemplateResultItem(string clientName, string api);
    }
}
