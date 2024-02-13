using AutoMapper;
using E_CODING_DAL.Models;
using E_CODING_FrontBlazor.DTOs;
using E_CODING_Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace TemplateProject_WebApi.Controllers
{
    [Route("api/TemplateSummary")]
    public class TemplateSummaryController : ControllerBase
    {
        private readonly IProjectRepositoryWrapper _projectRepositoryWrapper;
        private readonly IMapper _mapper;

        public TemplateSummaryController(
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
                Root? projectRoot = null;
                IEnumerable<TemplateProject> templateProjects = _projectRepositoryWrapper.ProjectRepository.GetAllTemplateProject();
                foreach(TemplateProject project in templateProjects)
                {
                    IEnumerable<TemplateTechnique> templateTechniques = 
                        _projectRepositoryWrapper.TechniqueRepository.GetProjectAllTemplateTechnique(project.TemplateProjectId);

                    foreach (TemplateTechnique technique in templateTechniques)
                    {
                        IEnumerable<TemplateTechniqueItem> templateTechniqueItems =
                        _projectRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(technique.TemplateTechniqueId);

                        foreach (TemplateTechniqueItem techniqueItem in templateTechniqueItems)
                        {
                            projectRoot = new Root() { 
                                value = project.TemplateProjectId.ToString(), 
                                text = project.TemplateProjectTitle,
                                children = new List<Child>()
                                {
                                    new Child()
                                    {
                                        value = technique.TemplateTechniqueId.ToString(),
                                        text=technique.TemplateTechniqueTitle,
                                        @checked= true,
                                        collapsed=true,
                                        disabled=true,
                                        children=new List<Child>()
                                        {
                                            new Child()
                                            {
                                                value = techniqueItem.TemplateTechniqueItemId.ToString(),
                                                text=techniqueItem.TemplateTechniqueItemTitle,
                                                @checked= true,
                                                collapsed=true,
                                                disabled=true,
                                            }
                                        }
                                    }
                                }
                            };
                        }
                    }
                }
                return Ok(projectRoot);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
