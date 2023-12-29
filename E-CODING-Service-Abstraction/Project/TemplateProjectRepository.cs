using E_CODING_DAL;
using E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Technique;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Project
{
    public class TemplateProjectRepository 
        : RepositoryBase<TemplateProject>, ITemplateProjectRepository
    {

        public TemplateProjectRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        {
        }

        public IEnumerable<TemplateProject> GetAllTemplateProject()
        {
            return FindAll().ToList();
        }

        public TemplateProject FindByCondition(int id)
        {
            return FindByCondition(TemplateProject => TemplateProject.TemplateProjectId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateProject(TemplateProject templateProject)
        {
            Create(templateProject);
        }

        public void UpdateTemplateProject(TemplateProject templateProject)
        {
            Update(templateProject);
        }

        public void DeleteTemplateProject(TemplateProject templateProject)
        {
            Delete(templateProject);
        }
    }
}
