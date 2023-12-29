using E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateTechnique_WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TemplateProject, TemplateProjectVM>();
            CreateMap<TemplateProjectVM, TemplateProject>();
            CreateMap<TemplateProjectVMForCreation, TemplateProject>();
            CreateMap<TemplateProjectVMForUpdate, TemplateProject>();

            CreateMap<TemplateFonctionnel, TemplateFonctionnelVM>();
            CreateMap<TemplateFonctionnelVM, TemplateFonctionnel>();

            CreateMap<TemplateFonctionnelEntity, TemplateFonctionnelEntityVM>();
            CreateMap<TemplateFonctionnelEntityVM, TemplateFonctionnelEntity>();

            CreateMap<TemplateFonctionnelProperty, TemplateFonctionnelPropertyVM>();
            CreateMap<TemplateFonctionnelPropertyVM, TemplateFonctionnelProperty>();

            CreateMap<TemplateTechnique, TemplateTechniqueVM>();
            CreateMap<TemplateTechniqueVM, TemplateTechnique>();
            CreateMap<TemplateTechniqueVMForCreation, TemplateTechnique>();
            CreateMap<TemplateTechniqueVMForUpdate, TemplateTechnique>();

            CreateMap<TemplateTechniqueItem, TemplateTechniqueItemVM>();
            CreateMap<TemplateTechniqueItemVM, TemplateTechniqueItem>();
            CreateMap<TemplateTechniqueItemVMForCreation, TemplateTechniqueItem>();
            CreateMap<TemplateTechniqueItemVMForUpdate, TemplateTechniqueItem>();

            CreateMap<TemplateResult, TemplateResultVM>();
            CreateMap<TemplateResultVM, TemplateResult>();

            CreateMap<TemplateResultItem, TemplateResultItemVM>();
            CreateMap<TemplateResultItemVM, TemplateResultItem>();

        }
    }
}
