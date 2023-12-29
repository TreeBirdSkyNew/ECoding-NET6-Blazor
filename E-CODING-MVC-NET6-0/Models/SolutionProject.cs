using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0.Models
{
    public class SolutionProjectVM
    {
        public int TemplateProjectId { get; set; }
        public TemplateProjectVM TemplateProject { get; set; }

        public int TemplateSolutionId { get; set; }
        public TemplateSolutionVM TemplateSolution { get; set; }
    }
}
