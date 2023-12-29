using E_CODING_DAL;
using E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Result
{

    public class TemplateResultRepository 
        : RepositoryBase<TemplateResult>, ITemplateResultRepository
    {
        public TemplateResultRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateResult> GetAllTemplateResult()
        {
            return FindAll().ToList();
        }

        public TemplateResult FindByCondition(int id)
        {
            return FindByCondition(TemplateResult => TemplateResult.TemplateResultId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateResult(TemplateResult templateResult)
        {
            CreateTemplateResult(templateResult);
        }

        public void UpdateTemplateResult(TemplateResult templateResult)
        {
            UpdateTemplateResult(templateResult);
        }       

        public void DeleteTemplateResult(TemplateResult templateResult)
        {
            DeleteTemplateResult(templateResult);
        }        

    }

}
