using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_DAL.Models
{
    public class TechniqueParameter
    {
        public int TechniqueParameterId { get; set; }
        public string TechniqueParameterName { get; set; } = string.Empty;
        public string TechniqueParameterValue { get; set; } = string.Empty;
        public int? TemplateTechniqueId { get; set; }
        public TemplateTechnique? TemplateTechnique { get; set; }
    }
}
