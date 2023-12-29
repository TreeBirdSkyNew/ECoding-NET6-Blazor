﻿using E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_FrontBlazor.DTOs;
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

            CreateMap<TemplateSolution, TemplateSolutionVM>();
            CreateMap<TemplateSolutionVM, TemplateSolution>();
            
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
