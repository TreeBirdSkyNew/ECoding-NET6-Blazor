using E_CODING_FrontBlazor.DTOs;
using E_CODING_FrontBlazor.Infrastructure.Solution;
using Microsoft.AspNetCore.Components;

namespace E_CODING_FrontBlazor.Pages.TemplateSolution
{
    public partial class TemplateSolutionList
    {
        
        [Inject]
        ITemplateSolutionApiClient? TemplateSolutionApiClient { get; set; }
        private List<TemplateSolutionVM>? solutions;

        protected override async Task OnInitializedAsync() 
        {
            solutions = await TemplateSolutionApiClient.GetAllTemplateSolution("ClientApiSolution", "Index");
        } 

    }
}
