using E_CODING_DAL;
using E_CODING_DAL.Models;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Result
{
    public class ResultRepositoryWrapper : IResultRepositoryWrapper
    {
        private TemplateProjectDbContext _projectDbContext;
        private ITemplateResultRepository _resultRepository;
        private ITemplateResultItemRepository _resultItemRepository;

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

        public E_CODING_Service_Abstraction.Result.ITemplateResultItemRepository ResultItemRepository
        {
            get
            {
                if (_resultItemRepository == null)
                {
                    _resultItemRepository = new TemplateResultItemRepository(_projectDbContext);
                }
                return _resultItemRepository;
            }
        }

        public ResultRepositoryWrapper(TemplateProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public void Save()
        {
            _projectDbContext.SaveChanges();
        }



    }

}
