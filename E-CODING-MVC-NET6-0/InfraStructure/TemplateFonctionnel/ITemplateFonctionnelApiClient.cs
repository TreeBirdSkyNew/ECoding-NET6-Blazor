using E_CODING_MVC_NET6_0.Models;

namespace E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel
{
    public interface ITemplateFonctionnelApiClient
    {
        Task<TemplateFonctionnelVM> GetTemplateFonctionnel(string clientName, string api);
        Task<List<TemplateFonctionnelVM>> GetAllTemplateFonctionnel(string clientName, string api);
        Task PostTemplateFonctionnel(string clientName, string api, StringContent client);
        Task DeleteTemplateFonctionnel(string clientName, string api);

        Task<TemplateFonctionnelEntityVM> GetTemplateFonctionnelEntity(string clientName, string api);
        Task<List<TemplateFonctionnelEntityVM>> GetAllTemplateFonctionnelEntity(string clientName, string api);
        Task PostTemplateFonctionnelEntity(string clientName, string api, StringContent client);
        Task DeleteTemplateFonctionnelEntity(string clientName, string api);

        Task<TemplateFonctionnelPropertyVM> GetTemplateFonctionnelProperty(string clientName, string api);
        Task<List<TemplateFonctionnelPropertyVM>> GetAllTemplateFonctionnelProperty(string clientName, string api);
        Task PostTemplateFonctionnelProperty(string clientName, string api, StringContent client);
        Task DeleteTemplateFonctionnelProperty(string clientName, string api);
    }
}
