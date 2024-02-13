using AutoMapper;
using E_CODING_DAL;
using E_CODING_FrontBlazor;
using E_CODING_FrontBlazor.Infrastructure.ApiClient;
using E_CODING_FrontBlazor.Infrastructure.Project;
using E_CODING_FrontBlazor.Infrastructure.Solution;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<TemplateProjectDbContext>(
item => item.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS; Database=ELearning; Integrated Security=true;"));

builder.Services.AddScoped<IApiClientService, ApiClientService>();
builder.Services.AddScoped<ITemplateSolutionApiClient, TemplateSolutionApiClient>();
builder.Services.AddScoped<ITemplateProjectApiClient, TemplateProjectApiClient>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddHttpClient("ClientApiSolution", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["api_template_solution"]);
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient("ClientApiProject", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["api_template_project"]);
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
