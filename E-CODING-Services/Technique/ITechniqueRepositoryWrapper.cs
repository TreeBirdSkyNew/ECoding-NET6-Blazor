using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Technique
{
    public interface ITechniqueRepositoryWrapper
    {
        ITemplateTechniqueRepository TechniqueRepository { get; }
        ITemplateTechniqueItemRepository TechniqueItemRepository { get; }
        void Save();
    }
}
