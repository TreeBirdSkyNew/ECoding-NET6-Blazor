using E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Solution
{
    public interface ITemplateSolutionRepository
    {
        IEnumerable<TemplateSolution> GetAllTemplateSolution();
        TemplateSolution FindByCondition(int id);
        void CreateTemplateSolution(TemplateSolution templateSolution);
        void UpdateTemplateSolution(TemplateSolution templateSolution);
        void DeleteTemplateSolution(TemplateSolution templateSolution);
    }
}
