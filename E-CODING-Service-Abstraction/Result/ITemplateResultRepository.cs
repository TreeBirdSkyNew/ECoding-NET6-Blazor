using E_CODING_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Result
{
    public interface ITemplateResultRepository
    {
        IEnumerable<TemplateResult> GetAllTemplateResult();
        TemplateResult FindByCondition(int id);
        void CreateTemplateResult(TemplateResult TemplateResult);
        void UpdateTemplateResult(TemplateResult TemplateResult);
        void DeleteTemplateResult(TemplateResult TemplateResult);
    }
}
