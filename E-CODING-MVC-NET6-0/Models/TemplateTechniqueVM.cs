using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateTechniqueVM
    {
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueName { get; set; } = string.Empty;
        public string TemplateTechniqueVersion { get; set; } = string.Empty;
        public string TemplateTechniqueTitle { get; set; } = string.Empty;
        public string TemplateTechniqueDescription { get; set; } = string.Empty;
        public string TemplateTechniqueVersionNET { get; set; } = string.Empty;
        public int TemplateProjectId { get; set; }
        public ICollection<ProjectTechniqueVM>? ProjectTechnique { get; set; }
        public ICollection<TemplateTechniqueItemVM>? TemplateTechniqueItem { get; set; }
        public ICollection<TechniqueParameterVM>? TechniqueParameter { get; set; }
    }
}
