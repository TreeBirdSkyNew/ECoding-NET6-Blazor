using E_CODING_MVC_NET6_0.Models;

namespace E_CODING_MVC_NET6_0.InfraStructure.Solution
{
    public interface ITemplateSolutionApiClient
    {
        Task<TemplateSolutionVM?> GetTemplateSolution(string clientName, string api);
        Task<List<TemplateSolutionVM?>> GetAllTemplateSolution(string clientName, string api);
        Task PostTemplateSolution(string clientName, string api, StringContent client);
        Task DeleteTemplateSolution(string clientName, string api);
    }
}
