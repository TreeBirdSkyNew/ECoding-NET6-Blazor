using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateTechniqueItemVM
    {
      
        public int TemplateTechniqueItemId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueItemName { get; set; } = string.Empty;
        public string TemplateTechniqueItemTitle { get; set; } = string.Empty;
        public string TemplateTechniqueItemDescription { get; set; } = string.Empty;
        public string TemplateTechniqueItemVersion { get; set; } = string.Empty;
        public string TemplateTechniqueItemVersionNET { get; set; } = string.Empty;
        public string TemplateTechniqueInitialFile { get; set; } = string.Empty;
        public string TemplateTechniqueFinalContent { get; set; } = string.Empty;
        public TemplateTechniqueVM? TemplateTechnique { get; set; }
    }
}
