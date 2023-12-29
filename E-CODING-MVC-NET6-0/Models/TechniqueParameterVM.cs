using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TechniqueParameterVM
    {
        public int TechniqueParameterId { get; set; }
        public string TechniqueParameterName { get; set; } = string.Empty;
        public string TechniqueParameterValue { get; set; } = string.Empty;
        public int TemplateTechniqueId { get; set; }
        public TemplateTechniqueVM? TemplateTechnique { get; set; }
    }
}
