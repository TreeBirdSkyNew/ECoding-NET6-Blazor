using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_DAL.Models
{
    public class TemplateResultItem
    {
        public int TemplateResultItemId { get; set; }
        public int? TemplateResultId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateResultItemName { get; set; } = string.Empty;
        public string TemplateResultItemTitle { get; set; } = string.Empty;
        public string TemplateResultItemDescription { get; set; } = string.Empty;
        public string TemplateResultItemVersion { get; set; } = string.Empty;
        public string TemplateResultItemVersionNET { get; set; } = string.Empty;
        public string TemplateResultInitialContent { get; set; } = string.Empty;
        public string TemplateResultFinalContent { get; set; } = string.Empty;
        public TemplateResult TemplateResult { get; set; }
    }
}
