using E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_Services.Project;
using E_CODING_Services.Result;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using E_CODING_Services.Technique;
using E_CODING_FrontBlazor.DTOs;

namespace TemplateProject_WebApi.Controllers
{
    [Route("api/TemplateProject")]
    public class TemplateProjectController : ControllerBase
    {
        private readonly IProjectRepositoryWrapper _projectRepositoryWrapper;
        private readonly IMapper _mapper;

        public TemplateProjectController(
            IProjectRepositoryWrapper projectRepositoryWrapper,
            IMapper mapper)
        {
            _projectRepositoryWrapper = projectRepositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<TemplateProject> templateProjects = _projectRepositoryWrapper.ProjectRepository.GetAllTemplateProject();
                IEnumerable<TemplateProjectVM> templateProjectsVM = _mapper.Map<IEnumerable<TemplateProjectVM>>(templateProjects);
                return Ok(templateProjectsVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "TemplateProjectById")]
        [Route("ProjectDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult TemplateProjectDetails(int id)
        {
            try
            {
                TemplateProject templateProject = _projectRepositoryWrapper.ProjectRepository.FindByCondition(id);
                if (templateProject is null)
                {
                    return NotFound();
                }
                else
                {
                    TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                    return Ok(templateProjectVM);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /*
        [HttpGet(Name = "TemplateProjectById")]
        [Route("ProjectDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult TemplateProjectDetails(int id)
        {
            try
            {
                TemplateProject templateProject = _projectRepositoryWrapper.ProjectRepository.FindByCondition(id);
                if (templateProject is null)
                {
                    _logger.LogError($"Returned TemplateProjectDetails TemplateProject={id} from database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned TemplateProjectDetails TemplateProject: {id}");
                    List<ProjectTechniqueVM> resultProjectTechnique = new List<ProjectTechniqueVM>();
                    TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                    List<TemplateTechnique> templateTechniques = _projectRepositoryWrapper.TechniqueRepository.GetProjectAllTemplateTechnique(id).ToList();
                    List<TemplateTechnique> resultTechniques = new List<TemplateTechnique>();
                    List<TemplateTechniqueVM> resultTechniqueVMs = new List<TemplateTechniqueVM>();
                    if (templateTechniques != null && templateTechniques.Count > 0)
                    {
                        foreach (TemplateTechnique templateTechnique in templateTechniques)
                        {
                            TemplateTechniqueVM templateTechniqueVM = new TemplateTechniqueVM();
                            List<TemplateTechniqueItem> templateTechniqueItems = _projectRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(templateTechnique.TemplateTechniqueId).ToList();
                            List<TemplateTechniqueItem> resultTechniqueItems = new List<TemplateTechniqueItem>();
                            List<TemplateTechniqueItemVM> resultTechniqueItemVMs = new List<TemplateTechniqueItemVM>();
                            if (templateTechniqueItems != null && templateTechniqueItems.Count > 0)
                            {
                                foreach (TemplateTechniqueItem templateTechniqueItem in templateTechniqueItems)
                                {
                                    resultTechniqueItems.Add(templateTechniqueItem);
                                }
                                templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                                resultTechniqueItemVMs = _mapper.Map<List<TemplateTechniqueItemVM>>(resultTechniqueItems);
                                templateTechniqueVM.TemplateTechniqueItem = resultTechniqueItemVMs;
                                ProjectTechniqueVM projectTechnique = ConstructProjectTechnique(templateProjectVM, templateTechniqueVM);
                                resultProjectTechnique.Add(projectTechnique);
                            }
                            resultTechniqueVMs.Add(templateTechniqueVM);
                        }
                        if (resultProjectTechnique != null)
                            templateProjectVM.ProjectTechnique = resultProjectTechnique;
                    }
                    return Ok(templateProjectVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProjectDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private ProjectTechniqueVM ConstructProjectTechnique(TemplateProjectVM project,TemplateTechniqueVM technique)
        {
            return  new ProjectTechniqueVM(){ 
                TemplateProjectId=project.TemplateProjectId,
                TemplateProject=project,
                TemplateTechnique=technique,
                TemplateTechniqueId=technique.TemplateTechniqueId,
            };
        }
        */


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        //[ValidateAntiForgeryToken]
        public IActionResult TemplateProjectCreate([FromBody] TemplateProjectVM templateProjectVM)
        {
            try
            {
                if (templateProjectVM is null)
                {
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                TemplateProject TemplateProjectEntity = _mapper.Map<TemplateProject>(templateProjectVM);
                _projectRepositoryWrapper.ProjectRepository.CreateTemplateProject(TemplateProjectEntity);
                _projectRepositoryWrapper.Save();
                var templateProject = _mapper.Map<TemplateProjectVM>(TemplateProjectEntity);
                return CreatedAtRoute("TemplateProjectById", new { id = templateProject.TemplateProjectId }, templateProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        [Route("Edit")]
        public IActionResult TemplateProjectEdit(int id, [FromBody] TemplateProjectVM templateProjectVM)
        {
            try
            {
                if (templateProjectVM is null)
                {
                   return BadRequest("TemplateResult object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var templateProjectEntity=_mapper.Map<TemplateProject>(templateProjectVM);
                _projectRepositoryWrapper.ProjectRepository.UpdateTemplateProject(templateProjectEntity);
                _projectRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Delete/{id}")]
        [HttpPost("{id}")]
        public void DeleteTemplateProject(int id)
        {
            try
            {
                var templateProject = _projectRepositoryWrapper.ProjectRepository.FindByCondition(id);
                if (templateProject == null)
                {
                }
                _projectRepositoryWrapper.ProjectRepository.DeleteTemplateProject(templateProject);
                _projectRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
            }
        }

    }
}
