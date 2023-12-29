using E_CODING_DAL;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Solution;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Solution
{
    public class SolutionRepositoryWrapper : ISolutionRepositoryWrapper
    {
        private TemplateProjectDbContext _projectDbContext;
        private ITemplateProjectRepository _projectRepository;
        private ITemplateSolutionRepository _solutionRepository;

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

        public ITemplateSolutionRepository SolutionRepository
        {
            get
            {
                if (_solutionRepository == null)
                {
                    _solutionRepository = new TemplateSolutionRepository(_projectDbContext);
                }
                return _solutionRepository;
            }
        }

        public SolutionRepositoryWrapper(TemplateProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public void Save()
        {
            _projectDbContext.SaveChanges();
        }
    }
}
