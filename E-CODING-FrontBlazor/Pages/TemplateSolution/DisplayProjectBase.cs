using E_CODING_FrontBlazor.DTOs;
using Microsoft.AspNetCore.Components;

namespace E_CODING_FrontBlazor.Pages.TemplateSolution
{
    public partial class DisplayProjectBase
    {
        [Parameter]
        public TemplateProjectVM TemplateProject { get; set; }
    }
}
