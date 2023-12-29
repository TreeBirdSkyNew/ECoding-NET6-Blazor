using E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Technique
{
    public interface ITemplateTechniqueRepository
    {
        IEnumerable<TemplateTechnique> GetAllTemplateTechnique();
        IEnumerable<TemplateTechnique> GetProjectAllTemplateTechnique(int projectId);
        TemplateTechnique FindByCondition(int id);
        void CreateTemplateTechnique(TemplateTechnique TemplateTechnique);
        void UpdateTemplateTechnique(TemplateTechnique TemplateTechnique);
        void DeleteTemplateTechnique(TemplateTechnique TemplateTechnique);
    }
}


