﻿using E_CODING_DAL.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_CODING_FrontBlazor.DTOs;

namespace __WEB_API__TemplateResult_WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TemplateProject, TemplateProjectVM>();
            CreateMap<TemplateProjectVM, TemplateProject>();

            CreateMap<TemplateTechnique, TemplateTechniqueVM>();
            CreateMap<TemplateTechniqueVM, TemplateTechnique>();

            CreateMap<TemplateTechniqueItem, TemplateTechniqueItemVM>();
            CreateMap<TemplateTechniqueItemVM, TemplateTechniqueItem>();

            CreateMap<TemplateResult, TemplateResultVM>();
            CreateMap<TemplateResultVM, TemplateResult>();

            CreateMap<TemplateResultItem, TemplateResultItemVM>();
            CreateMap<TemplateResultItemVM, TemplateResultItem>();






            
        }
    }
}
