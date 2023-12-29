using System;
using System.Collections.Generic;

namespace E_CODING_DAL.Models
{
    public class TemplateProject
    {
        public TemplateProject()
        {
            TemplateTechnique = new HashSet<TemplateTechnique>();
            TemplateResult = new HashSet<TemplateResult>();
        }

        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
        public ICollection<TemplateTechnique>? TemplateTechnique { get; set; }
        public ICollection<TemplateResult>? TemplateResult { get; set; }
        public TemplateSolution? TemplateSolution { get; set; }
        public int? TemplateSolutionId { get; set; }


    }
}
