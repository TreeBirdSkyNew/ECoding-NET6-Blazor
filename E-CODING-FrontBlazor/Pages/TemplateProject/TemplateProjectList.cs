using E_CODING_FrontBlazor.DTOs;
using E_CODING_FrontBlazor.Infrastructure.Project;
using Microsoft.AspNetCore.Components;

namespace E_CODING_FrontBlazor.Pages.TemplateProject
{
    public partial class TemplateProjectList
    {
        [Inject]
        ITemplateProjectApiClient? TemplateProjectApiClient { get; set; }
        private List<TemplateProjectVM>? projects;

        protected override async Task OnInitializedAsync()
        {
            projects = await TemplateProjectApiClient.GetAllTemplateProject("ClientApiProject", "Index");
        }
    }
}
