using E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Technique
{
    public interface ITemplateTechniqueItemRepository
    {
        IEnumerable<TemplateTechniqueItem> GetAllTemplateTechniqueItem(int id);
        TemplateTechniqueItem FindByCondition(int id);
        void CreateTemplateTechniqueItem(TemplateTechniqueItem TemplateTechniqueItem);
        void UpdateTemplateTechniqueItem(TemplateTechniqueItem TemplateTechniqueItem);
        void DeleteTemplateTechniqueItem(TemplateTechniqueItem TemplateTechniqueItem);
    }
}
