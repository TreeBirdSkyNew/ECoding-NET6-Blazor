using E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_FrontBlazor.DTOs;
using E_CODING_Service_Abstraction;
using E_CODING_Services.Solution;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace TemplateSolution_WebApi.Controllers
{
    [Route("api/TemplateSolution")]
    public class TemplateSolutionController : ControllerBase
    {
        private readonly ISolutionRepositoryWrapper _solutionRepositoryWrapper;
        private readonly IMapper _mapper;

        public TemplateSolutionController(
            ISolutionRepositoryWrapper solutionRepositoryWrapper,
            IMapper mapper)
        {
            _solutionRepositoryWrapper = solutionRepositoryWrapper;
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
                IEnumerable<TemplateSolution> templateProjects = _solutionRepositoryWrapper.SolutionRepository.GetAllTemplateSolution();
                IEnumerable<TemplateSolutionVM> templateProjectsVM = _mapper.Map<IEnumerable<TemplateSolutionVM>>(templateProjects);
                return Ok(templateProjectsVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "TemplateSolutionById")]
        [Route("SolutionDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateSolution))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult TemplateSolutionDetails(int id)
        {
            try
            {
                
                TemplateSolution templateSolution = _solutionRepositoryWrapper.SolutionRepository.FindByCondition(id);
                if (templateSolution is null)
                {
                    return NotFound();
                }
                else
                {
                    List<TemplateProject> templateProjects = _solutionRepositoryWrapper.ProjectRepository.GetAllTemplateProject().Where(x => x.TemplateSolutionId == id).ToList();
                    List<TemplateProjectVM> templateProjectsVM = _mapper.Map<List<TemplateProjectVM>>(templateProjects);
                    TemplateSolutionVM templateSolutionVM = _mapper.Map<TemplateSolutionVM>(templateSolution);
                    templateSolutionVM.TemplateProject= templateProjectsVM;
                    return Ok(templateSolutionVM);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        public IActionResult TemplateSolutionCreate([FromBody] TemplateSolutionVM templateSolutionVM)
        {
            try
            {
                if (templateSolutionVM is null)
                {
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                TemplateSolution TemplateSolutionEntity = _mapper.Map<TemplateSolution>(templateSolutionVM);
                _solutionRepositoryWrapper.SolutionRepository.CreateTemplateSolution(TemplateSolutionEntity);
                _solutionRepositoryWrapper.Save();
                var templateSolution = _mapper.Map<TemplateSolutionVM>(TemplateSolutionEntity);
                return CreatedAtRoute("TemplateSolutionById", new { id = templateSolution.TemplateSolutionId }, templateSolution);
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
        [Route("Edit/{id}")]
        public IActionResult TemplateSolutionEdit(int id, [FromBody] TemplateSolutionVM templateSolutionVM)
        {
            try
            {
                if (templateSolutionVM is null)
                {
                    return BadRequest("TemplateResult object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var templateSolutionEntity = _mapper.Map<TemplateSolution>(templateSolutionVM);
                _solutionRepositoryWrapper.SolutionRepository.UpdateTemplateSolution(templateSolutionEntity);
                _solutionRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete("{id}")]
        public void DeleteTemplateSolution(int id)
        {
            try
            {
                var templateSolution = _solutionRepositoryWrapper.SolutionRepository.FindByCondition(id);
                _solutionRepositoryWrapper.SolutionRepository.DeleteTemplateSolution(templateSolution);
                _solutionRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
            }
        }
    }
}