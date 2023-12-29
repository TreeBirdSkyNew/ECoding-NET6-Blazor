using E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Project
{
    public interface ITemplateProjectRepository
    {
        IEnumerable<TemplateProject> GetAllTemplateProject();
        TemplateProject FindByCondition(int id);
        void CreateTemplateProject(TemplateProject templateProject);
        void UpdateTemplateProject(TemplateProject templateProject);
        void DeleteTemplateProject(TemplateProject templateProject);
    }
}
