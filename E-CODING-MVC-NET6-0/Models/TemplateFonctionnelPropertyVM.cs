using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateFonctionnelPropertyVM
    {
        public int TemplateFonctionnelPropertyId { get; set; }
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelPropertyName { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyTitle { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyDescription { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyVersionEF { get; set; } = string.Empty;
        public string TemplateFonctionnelPropertyVersionNET { get; set; } = string.Empty;
        //public TemplateSharpToSQLType PropertyType { get; set; }
        public TemplateFonctionnelEntityVM TemplateFonctionnelEntity { get; set; }
    }
}
