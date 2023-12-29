using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateResultVM
    {
        public TemplateResultVM()
        {
            TemplateResultItem = new HashSet<TemplateResultItemVM>();
        }
        public int TemplateResultId { get; set; }
        public string TemplateResultName { get; set; } = string.Empty;
        public string TemplateResultVersion { get; set; } = string.Empty;
        public string TemplateResultVersionNET { get; set; } = string.Empty;
        public string TemplateResultTitle { get; set; } = string.Empty;
        public string TemplateResultDescription { get; set; } = string.Empty;
        public int TemplateProjectId { get; set; }
        public ICollection<ProjectResultVM>? ProjectResult { get; set; }
        public ICollection<TemplateResultItemVM>? TemplateResultItem { get; set; }
    }
}
