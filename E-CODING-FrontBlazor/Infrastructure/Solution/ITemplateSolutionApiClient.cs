using E_CODING_FrontBlazor.DTOs;

namespace E_CODING_FrontBlazor.Infrastructure.Solution
{
    public interface ITemplateSolutionApiClient
    {
        Task<TemplateSolutionVM?> GetTemplateSolution(string clientName, string api);
        Task<List<TemplateSolutionVM?>> GetAllTemplateSolution(string clientName, string api);
        Task PostTemplateSolution(string clientName, string api, StringContent client);
        Task PutTemplateSolution(string clientName, string api, StringContent client);
        Task DeleteTemplateSolution(string clientName, string api);
    }
}
