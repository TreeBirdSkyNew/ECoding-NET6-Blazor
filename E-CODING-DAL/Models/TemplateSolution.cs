using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_DAL.Models
{
    public class TemplateSolution
    {
        public TemplateSolution()
        {
            TemplateProject = new HashSet<TemplateProject>();
        }
        public int TemplateSolutionId { get; set; }
        public int TemplateProjectId { get; set; }
        public string TemplateSolutionName { get; set; } = string.Empty;
        public string TemplateSolutionTitle { get; set; } = string.Empty;
        public string TemplateSolutionDescription { get; set; } = string.Empty;
        public string TemplateSolutionVersion { get; set; } = string.Empty;
        public string TemplateSolutionVersionNet { get; set; } = string.Empty;
        public ICollection<TemplateProject>? TemplateProject { get; set; }
    }
}
