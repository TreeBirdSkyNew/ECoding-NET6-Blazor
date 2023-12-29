using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateFonctionnelVM
    {
        public TemplateFonctionnelVM()
        {
            TemplateFonctionnelEntity = new HashSet<TemplateFonctionnelEntityVM>();
        }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelName { get; set; } = string.Empty;
        public string TemplateFonctionnelTitle { get; set; } = string.Empty;
        public string TemplateFonctionnelDescription { get; set; } = string.Empty;
        public string TemplateFonctionnelContent { get; set; } = string.Empty;
        public string TemplateFonctionnelEFVersion { get; set; } = string.Empty;
        public int TemplateProjectId { get; set; }
        public TemplateProjectVM TemplateProject { get; set; }
        public ICollection<TemplateFonctionnelEntityVM> TemplateFonctionnelEntity { get; set; }
    }
}
