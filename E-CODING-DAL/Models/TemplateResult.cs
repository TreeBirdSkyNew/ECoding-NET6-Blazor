using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_DAL.Models
{
    public class TemplateResult
    {
        public TemplateResult()
        {
            TemplateResultItem = new HashSet<TemplateResultItem>();
        }
        public int TemplateResultId { get; set; }
        public string TemplateResultName { get; set; } = string.Empty;
        public string TemplateResultVersion { get; set; } = string.Empty;
        public string TemplateResultVersionNET { get; set; } = string.Empty;
        public string TemplateResultTitle { get; set; } = string.Empty;
        public string TemplateResultDescription { get; set; } = string.Empty;
        public int? TemplateProjectId { get; set; }
        public ICollection<TemplateResultItem>? TemplateResultItem { get; set; }
    }
}
