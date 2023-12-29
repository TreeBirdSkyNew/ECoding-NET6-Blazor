using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public interface ITemplateTechniqueApiClient
    {
        Task<TemplateTechniqueVM> GetTemplateTechnique(string clientName, string api);
        Task<List<TemplateTechniqueVM>> GetAllTemplateTechnique(string clientName, string api);
        Task PostTemplateTechnique(string clientName, string api, StringContent client);
        Task DeleteTemplateTechnique(string clientName, string api);

        Task<TemplateTechniqueItemVM> GetTemplateTechniqueItem(string clientName, string api);
        Task<List<TemplateTechniqueItemVM>> GetAllTemplateTechniqueItem(string clientName, string api);
        Task PostTemplateTechniqueItem(string clientName, string api, StringContent client);
        Task DeleteTemplateTechniqueItem(string clientName, string api);
    }
}
