using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_DAL.Models
{
    public class TemplateTechniqueItem
    {
        public int TemplateTechniqueItemId { get; set; }
        public int? TemplateTechniqueId { get; set; }
        public string TemplateTechniqueItemName { get; set; } = string.Empty;
        public string TemplateTechniqueItemTitle { get; set; } = string.Empty;
        public string TemplateTechniqueItemDescription { get; set; } = string.Empty;
        public string TemplateTechniqueItemVersion { get; set; } = string.Empty;
        public string TemplateTechniqueItemVersionNET { get; set; } = string.Empty;
        public string TemplateTechniqueInitialFile { get; set; } = string.Empty;
        public string TemplateTechniqueFinalContent { get; set; } = string.Empty;
        public TemplateTechnique? TemplateTechnique { get; set; }
    }
}
