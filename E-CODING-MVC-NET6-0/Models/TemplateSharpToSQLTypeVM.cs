using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateSharpToSQLTypeVM
    {
        public int TemplateSharpToSQLTypeId;
        public string SQLType { get; set; } = string.Empty;
        public string CSharpType { get; set; } = string.Empty;
    }
}
