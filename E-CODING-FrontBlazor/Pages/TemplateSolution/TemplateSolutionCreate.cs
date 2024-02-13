using AutoMapper;
using E_CODING_DAL.Models;
using E_CODING_FrontBlazor.DTOs;
using E_CODING_FrontBlazor.Infrastructure.Project;
using E_CODING_FrontBlazor.Infrastructure.Solution;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;


namespace E_CODING_FrontBlazor.Pages.TemplateSolution
{
    public partial class TemplateSolutionCreate
    {        

        [Inject]
        ITemplateSolutionApiClient? TemplateSolutionApiClient { get; set; }

        [Inject]
        ITemplateProjectApiClient? TemplateProjectApiClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        
        public List<TemplateProjectVM>? TemplateProjectVMs { get; set; } = new List<TemplateProjectVM?>();

        public TemplateSolutionVM templateSolutionVM = new TemplateSolutionVM();


        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int templateSolutionId);
            if (templateSolutionId != 0)
            {
                templateSolutionVM = await TemplateSolutionApiClient.GetTemplateSolution("ClientApiSolution", "SolutionDetails/" + Id);
            }
            else
            {
                templateSolutionVM = new TemplateSolutionVM();
            }
            TemplateProjectVMs = await TemplateProjectApiClient.GetAllTemplateProject("ClientApiProject", "Index");
        }

        private async Task HandleValidSubmit()
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateSolutionVM), Encoding.UTF8, "application/json");
            if (templateSolutionVM.TemplateSolutionId != 0)
            {
                await TemplateSolutionApiClient.PutTemplateSolution("ClientApiSolution", "Edit/" + Id, content);
            }
            else
            {
                await TemplateSolutionApiClient.PostTemplateSolution("ClientApiSolution", "Create", content);
            }
            NavigationManager.NavigateTo("/templatesolutionlist");
        }
    }
}
