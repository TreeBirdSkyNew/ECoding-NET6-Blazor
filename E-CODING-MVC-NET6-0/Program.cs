
using AutoMapper;
using E_CODING_DAL;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.InfraStructure.Solution;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_Service_Abstraction.ApiClient;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Services.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IApiClientService, ApiClientService>();
builder.Services.AddScoped<ITemplateSolutionApiClient, TemplateSolutionApiClient>();
builder.Services.AddScoped<ITemplateProjectApiClient, TemplateProjectApiClient>();
builder.Services.AddScoped<ITemplateTechniqueApiClient, TemplateTechniqueApiClient>();
builder.Services.AddScoped<ITemplateFonctionnelApiClient, TemplateFonctionnelApiClient>();
builder.Services.AddScoped<ITemplateResultApiClient, TemplateResultApiClient>();

builder.Services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS; Database=ELearning; Integrated Security=true;"));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddHttpClient("ClientApiFonctionnel", httpClient => 
{
    httpClient.BaseAddress = new Uri("https://localhost:7073");
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient("ClientApiResult", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7092");
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient("ClientApiTechnique", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7132");
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient("ClientApiProject", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7265");
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient("ClientApiSolution", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7043");
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "TemplateSolution",
    pattern: "{controller=TemplateSolution}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateProject",
    pattern: "{controller=TemplateProject}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateFonctionnel",
    pattern: "{controller=TemplateFonctionnel}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateResult",
    pattern: "{controller=TemplateResult}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "TemplateTechnique",
    pattern: "{controller=TemplateTechnique}/{action=Index}/{id?}").WithMetadata(new AllowAnonymousAttribute());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TemplateProject}/{action=Index}/{id?}");

app.MapControllers();
app.Run();

