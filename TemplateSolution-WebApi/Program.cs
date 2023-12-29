using AutoMapper;
using E_CODING_Service_Abstraction.Solution;
using E_CODING_Service_Abstraction.Technique;
using E_CODING_Services.Solution;
using E_CODING_Services.Technique;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using TemplateSolution_WebApi.Extensions;
using TemplateTechnique_WebApi;

var builder = WebApplication.CreateBuilder(args);
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureSqlServerContext();

builder.Services.AddScoped<ITemplateSolutionRepository, TemplateSolutionRepository>();
builder.Services.AddScoped<ISolutionRepositoryWrapper, SolutionRepositoryWrapper>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

