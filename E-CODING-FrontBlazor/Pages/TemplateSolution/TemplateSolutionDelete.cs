using E_CODING_DAL.Models;
using E_CODING_FrontBlazor.DTOs;
using E_CODING_FrontBlazor.Infrastructure.Solution;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace E_CODING_FrontBlazor.Pages.TemplateSolution
{
    public partial class TemplateSolutionDelete
    {
        [Inject]
        ITemplateSolutionApiClient? TemplateSolutionApiClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public TemplateSolutionVM templateSolutionVM = new TemplateSolutionVM();


        protected override async Task OnInitializedAsync()
        {
            templateSolutionVM = await TemplateSolutionApiClient.GetTemplateSolution("ClientApiSolution", "SolutionDetails/" + Id);
        }

        protected async Task Delete_Click()
        {
            await TemplateSolutionApiClient.DeleteTemplateSolution("ClientApiSolution", "Delete/" + Id);
            NavigationManager.NavigateTo("/");
        }

    }
}
