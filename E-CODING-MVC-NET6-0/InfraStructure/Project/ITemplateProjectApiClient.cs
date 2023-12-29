using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0.InfraStructure.Project
{
    public interface ITemplateProjectApiClient
    {
        Task<TemplateProjectVM?> GetTemplateProject(string clientName , string api);
        Task<List<TemplateProjectVM?>> GetAllTemplateProject(string clientName, string api);
        Task PostTemplateProject(string clientName, string api, StringContent client);
        Task DeleteTemplateProject(string clientName, string api);
    }
}
