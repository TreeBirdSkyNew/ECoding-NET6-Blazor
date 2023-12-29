using E_CODING_DAL;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Technique
{
    public class TechniqueRepositoryWrapper : ITechniqueRepositoryWrapper
    {
        private TemplateProjectDbContext _projectDbContext;
        private ITemplateTechniqueRepository _techniqueRepository;
        private ITemplateTechniqueItemRepository _techniqueItemRepository;

        public ITemplateTechniqueRepository TechniqueRepository
        {
            get
            {
                if (_techniqueRepository == null)
                {
                    _techniqueRepository = new TemplateTechniqueRepository(_projectDbContext);
                }
                return _techniqueRepository;
            }
        }

        public ITemplateTechniqueItemRepository TechniqueItemRepository
        {
            get
            {
                if (_techniqueItemRepository == null)
                {
                    _techniqueItemRepository = new TemplateTechniqueItemRepository(_projectDbContext);
                }
                return _techniqueItemRepository;
            }
        }

        public TechniqueRepositoryWrapper(TemplateProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public void Save()
        {
            _projectDbContext.SaveChanges();
        }

    }
}
