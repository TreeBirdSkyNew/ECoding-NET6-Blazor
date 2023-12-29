using E_CODING_DAL;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Services.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace TemplateProject_WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
      
        public static void ConfigureSqlServerContext(this IServiceCollection services)
        {
            services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS; Database=ELearning; Integrated Security=SSPI; "));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<ITemplateProjectRepository, TemplateProjectRepository>();
            services.AddScoped<IProjectRepositoryWrapper, ProjectRepositoryWrapper>();
        }
    }
}
