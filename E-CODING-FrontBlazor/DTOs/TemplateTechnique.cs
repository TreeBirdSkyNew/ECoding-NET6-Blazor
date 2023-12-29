using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_FrontBlazor.DTOs
{
    public class TemplateTechniqueVM
    {
        public TemplateTechniqueVM()
        {
            TemplateTechniqueItem = new HashSet<TemplateTechniqueItemVM>();
            TechniqueParameter = new HashSet<TechniqueParameterVM>();
        }
        
        public int? TemplateTechniqueId { get; set; }
        public string TemplateTechniqueName { get; set; } = string.Empty;
        public string TemplateTechniqueVersion { get; set; } = string.Empty;
        public string TemplateTechniqueTitle { get; set; } = string.Empty;
        public string TemplateTechniqueDescription { get; set; } = string.Empty;
        public string TemplateTechniqueVersionNET { get; set; } = string.Empty;
        public int TemplateProjectId { get; set; }
        public ICollection<TemplateTechniqueItemVM>? TemplateTechniqueItem { get; set; }
        public ICollection<TechniqueParameterVM>? TechniqueParameter { get; set; }
        public TemplateProjectVM? TemplateProject { get; set; }
    }
}
