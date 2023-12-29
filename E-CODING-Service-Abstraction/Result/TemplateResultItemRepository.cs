using E_CODING_DAL.Models;
using E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_CODING_Service_Abstraction.Result
{
    public class TemplateResultItemRepository
        : RepositoryBase<TemplateResultItem>, ITemplateResultItemRepository
    {
        public TemplateResultItemRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        { }

        public IEnumerable<TemplateResultItem> GetAllTemplateResultItem(int id)
        {
            return _repositoryContext.Set<TemplateResultItem>()
                .Where(TemplateResultItem => TemplateResultItem.TemplateResultId.Equals(id))
                .AsNoTracking()
                .ToList();
        }

        public TemplateResultItem FindByCondition(int id)
        {
            return FindByCondition(TemplateResultItem => TemplateResultItem.TemplateResultItemId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateResultItem(TemplateResultItem TemplateResultItem)
        {
            CreateTemplateResultItem(TemplateResultItem);
        }

        public void UpdateTemplateResultItem(TemplateResultItem TemplateResultItem)
        {
            UpdateTemplateResultItem(TemplateResultItem);
        }

        public void DeleteTemplateResultItem(TemplateResultItem TemplateResultItem)
        {
            DeleteTemplateResultItem(TemplateResultItem);
        }

    }
}
