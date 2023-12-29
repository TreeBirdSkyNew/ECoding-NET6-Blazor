using E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace __WEB_API__TemplateTechnique_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=SQLEXPRESS; Database=ECODING; Integrated Security=SSPI; "));
     
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ITemplateTechniqueService, TemplateTechniqueService>();
            services.AddScoped<ITemplateTechniqueRepository, TemplateTechniqueRepository>();

            services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSwaggerDocument();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "DomainActivityIndex",
                   pattern: "{controller=TemplateTechnique}/{action=DomainActivityIndex}");

                endpoints.MapControllerRoute(
                    name: "TemplateProjectByActivity",
                    pattern: "{controller=TemplateTechnique}/{action=TemplateProjectByActivity}/{id}");

                endpoints.MapControllerRoute(
                    name: "TemplateTechniqueByActivity",
                    pattern: "{controller=TemplateTechnique}/{action=TemplateTechniqueByActivity}/{id}");

                endpoints.MapControllerRoute(
                    name: "TemplateTechniqueItems",
                    pattern: "{controller=TemplateTechnique}/{action=TemplateTechniqueItems}/{id}");

                endpoints.MapControllerRoute(
                    name: "TemplateTechniqueItem",
                    pattern: "{controller=TemplateTechnique}/{action=TemplateTechniqueItem}/{id}");

                endpoints.MapControllerRoute("TemplateTechnique", "{controller=TemplateTechnique}/{action=Index}/{id?}");
            });
        }
    }

   
}