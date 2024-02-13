using E_CODING_FrontBlazor.DTOs;

namespace E_CODING_FrontBlazor.Infrastructure.Project
{
    public interface ITemplateProjectApiClient
    {
        Task<TemplateProjectVM?> GetTemplateProject(string clientName, string api);
        Task<List<TemplateProjectVM?>> GetAllTemplateProject(string clientName, string api);
        Task PostTemplateProject(string clientName, string api, StringContent client);
        Task PutTemplateProject(string clientName, string api, StringContent client);
        Task DeleteTemplateProject(string clientName, string api);
    }
}
