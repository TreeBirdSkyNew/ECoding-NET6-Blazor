using E_CODING_DAL.Models;
using E_CODING_DAL;
using E_CODING_Service_Abstraction.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Solution
{
    public class TemplateSolutionRepository : RepositoryBase<TemplateSolution>, ITemplateSolutionRepository
    {

        public TemplateSolutionRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        {
        }

        public IEnumerable<TemplateSolution> GetAllTemplateSolution()
        {
            return FindAll().ToList();
        }

        public TemplateSolution FindByCondition(int id)
        {
            return FindByCondition(TemplateSolution => TemplateSolution.TemplateSolutionId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateSolution(TemplateSolution templateSolution)
        {
            Create(templateSolution);
        }

        public void UpdateTemplateSolution(TemplateSolution templateSolution)
        {
            Update(templateSolution);
        }

        public void DeleteTemplateSolution(TemplateSolution templateSolution)
        {
            Delete(templateSolution);
        }
    }
}
