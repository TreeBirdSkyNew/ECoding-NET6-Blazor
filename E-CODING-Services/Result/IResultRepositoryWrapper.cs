using E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services.Result
{
    public interface IResultRepositoryWrapper
    {
        ITemplateResultRepository ResultRepository { get; }
        ITemplateResultItemRepository ResultItemRepository { get; }
        void Save();
    }
}
