using E_CODING_DAL.Models;
using E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace E_CODING_Service_Abstraction.Technique
{
    public class TemplateTechniqueItemRepository
        : RepositoryBase<TemplateTechniqueItem>, ITemplateTechniqueItemRepository
    {
        public TemplateTechniqueItemRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateTechniqueItem> GetAllTemplateTechniqueItem(int id)
        {
            return _repositoryContext.Set<TemplateTechniqueItem>()
                .Where(TemplateTechniqueItem => TemplateTechniqueItem.TemplateTechniqueId==id)
                .AsNoTracking()
                .ToList();
        }
        
        public TemplateTechniqueItem FindByCondition(int id)
        {
            return FindByCondition(TemplateTechniqueItem => TemplateTechniqueItem.TemplateTechniqueItemId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            Create(templateTechniqueItem);
        }

        public void UpdateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            Update(templateTechniqueItem);
        }

        public void DeleteTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            Delete(templateTechniqueItem);
        }
    }
}
