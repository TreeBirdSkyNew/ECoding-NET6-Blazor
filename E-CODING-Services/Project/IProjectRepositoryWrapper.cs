using E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Project
{
    public interface IProjectRepositoryWrapper
    {
        ITemplateProjectRepository ProjectRepository { get; }
        ITemplateTechniqueRepository TechniqueRepository { get; }
        ITemplateTechniqueItemRepository TechniqueItemRepository { get; }
        ITemplateResultRepository ResultRepository { get; }
        void Save();
    }
}

