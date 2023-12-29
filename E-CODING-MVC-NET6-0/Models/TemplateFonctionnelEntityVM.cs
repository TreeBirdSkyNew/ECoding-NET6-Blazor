using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateFonctionnelEntityVM
    {
        public TemplateFonctionnelEntityVM()
        {
            TemplateFonctionnelProperty = new HashSet<TemplateFonctionnelPropertyVM>();
        }
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelEntityName { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityTitle { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityDescription { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityContent { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityTypeNet { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityTypeSQL { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityVersionEF { get; set; } = string.Empty;
        public string TemplateFonctionnelEntityVersionNET { get; set; } = string.Empty;
        public TemplateFonctionnelVM TemplateFonctionnel { get; set; }
        public ICollection<TemplateFonctionnelPropertyVM> TemplateFonctionnelProperty { get; set; }
    }

}
