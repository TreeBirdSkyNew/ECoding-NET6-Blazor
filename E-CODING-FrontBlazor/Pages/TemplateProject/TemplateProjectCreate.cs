using E_CODING_FrontBlazor.DTOs;
using E_CODING_FrontBlazor.Infrastructure.Project;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace E_CODING_FrontBlazor.Pages.TemplateProject
{
    public partial class TemplateProjectCreate
    {
        [Inject]
        ITemplateProjectApiClient? TemplateProjectApiClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public TemplateProjectVM templateProjectVM = new TemplateProjectVM();


        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int templateProjectId);

            if (templateProjectId != 0)
            {
                templateProjectVM = await TemplateProjectApiClient.GetTemplateProject("ClientApiProject", "ProjectDetails/" + Id);
            }
            else
            {
                templateProjectVM = new TemplateProjectVM();
            }
        }

        private async Task HandleValidSubmit()
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            if (templateProjectVM.TemplateProjectId != 0)
            {

                await TemplateProjectApiClient.PutTemplateProject("ClientApiProject", "Edit/" + Id, content);
            }
            else
            {
                await TemplateProjectApiClient.PostTemplateProject("ClientApiProject", "Create", content);
            }
            NavigationManager.NavigateTo("/templateprojectlist");
        }
    }
}
