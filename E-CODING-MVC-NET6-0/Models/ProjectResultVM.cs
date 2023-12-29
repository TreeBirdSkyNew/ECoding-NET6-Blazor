using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace E_CODING_MVC_NET6_0.Models
{
    public class ProjectResultVM
    {
        public int TemplateProjectId { get; set; }
        public TemplateProjectVM? TemplateProject { get; set; }

        public int TemplateResultId { get; set; }
        public TemplateResultVM TemplateResult { get; set; }

    }
}
