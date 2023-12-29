using E_CODING_DAL.Models;
using System;
using System.Collections.Generic;

namespace E_CODING_FrontBlazor.DTOs
{
    public class TemplateProjectVM
    {
        public TemplateProjectVM()
        {
            TemplateTechnique = new HashSet<TemplateTechniqueVM>();
            TemplateResult = new HashSet<TemplateResultVM>();
        }

        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
        public ICollection<TemplateTechniqueVM>? TemplateTechnique { get; set; }
        public ICollection<TemplateResultVM>? TemplateResult { get; set; }
        public int? TemplateSolutionId { get; set; }
        public TemplateSolutionVM? TemplateSolution { get; set; }
    }
}
