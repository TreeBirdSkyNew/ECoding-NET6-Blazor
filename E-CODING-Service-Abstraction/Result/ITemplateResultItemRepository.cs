using E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Result
{
    public interface ITemplateResultItemRepository
    {
        IEnumerable<TemplateResultItem> GetAllTemplateResultItem(int id);
        TemplateResultItem FindByCondition(int id);
        void CreateTemplateResultItem(TemplateResultItem TemplateResultItem);
        void UpdateTemplateResultItem(TemplateResultItem TemplateResultItem);
        void DeleteTemplateResultItem(TemplateResultItem TemplateResultItem);
    }
}
