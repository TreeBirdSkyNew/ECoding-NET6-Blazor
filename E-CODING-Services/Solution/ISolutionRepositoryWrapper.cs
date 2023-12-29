using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Solution;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Solution
{
    public interface ISolutionRepositoryWrapper
    {
        ITemplateProjectRepository ProjectRepository { get; }
        ITemplateSolutionRepository SolutionRepository { get; }
        void Save();
    }
}
