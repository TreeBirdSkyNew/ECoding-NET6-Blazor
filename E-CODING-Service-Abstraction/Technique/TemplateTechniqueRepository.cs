using E_CODING_DAL;
using E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Technique
{
    public class TemplateTechniqueRepository
        : RepositoryBase<TemplateTechnique>, ITemplateTechniqueRepository
    {
        public TemplateTechniqueRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateTechnique> GetAllTemplateTechnique()
        {
            return FindAll().ToList();
        }

        public IEnumerable<TemplateTechnique> GetProjectAllTemplateTechnique(int projectId)
        {
            return FindByCondition(TemplateTechnique => TemplateTechnique.TemplateProjectId.Equals(projectId))
                    .ToList();
        }

        public TemplateTechnique FindByCondition(int id)
        {
            return FindByCondition(TemplateTechnique => TemplateTechnique.TemplateTechniqueId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateTechnique(TemplateTechnique templateTechnique)
        {
            Create(templateTechnique);
        }
        
        public void UpdateTemplateTechnique(TemplateTechnique templateTechnique)
        {
            Update(templateTechnique);
        }

        public void DeleteTemplateTechnique(TemplateTechnique templateTechnique)
        {
            Delete(templateTechnique);
        }
    }
}
