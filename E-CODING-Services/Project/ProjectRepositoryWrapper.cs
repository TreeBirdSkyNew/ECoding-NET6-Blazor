using E_CODING_DAL;
using E_CODING_DAL.Models;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using E_CODING_Services.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_CODING_Services.Project
{
    public class ProjectRepositoryWrapper : IProjectRepositoryWrapper
    {
        private TemplateProjectDbContext _projectDbContext;
        private ITemplateProjectRepository _projectRepository;
        private ITemplateTechniqueRepository _techniqueRepository;
        private ITemplateTechniqueItemRepository _techniqueItemRepository;
        private ITemplateResultRepository _resultRepository;
        public ITemplateProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new TemplateProjectRepository(_projectDbContext);
                }
                return _projectRepository;
            }
        }

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

        public ITemplateResultRepository ResultRepository
        {
            get
            {
                if (_resultRepository == null)
                {
                    _resultRepository = new TemplateResultRepository(_projectDbContext);
                }
                return _resultRepository;
            }
        }

        public ProjectRepositoryWrapper(TemplateProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public void Save()
        {
            _projectDbContext.SaveChanges();
        }
    }
}
