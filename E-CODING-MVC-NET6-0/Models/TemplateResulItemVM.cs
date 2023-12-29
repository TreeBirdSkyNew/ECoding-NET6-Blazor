using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateResultItemVM
    {
        public int TemplateResultItemId { get; set; }
        public int TemplateResultId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public int TemplateProjectId { get; set; }
        public string TemplateResultItemName { get; set; } = string.Empty;
        public string TemplateResultItemVersion { get; set; } = string.Empty;
        public string TemplateResultItemVersionNET { get; set; } = string.Empty;
        public string TemplateResultItemTitle { get; set; } = string.Empty;
        public string TemplateResultItemDescription { get; set; } = string.Empty;
        public virtual TemplateResultVM? TemplateResultVM { get; set; }
    }
}
