using E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi.Controllers
{
    [Route("api/TemplateProject")]
    public class TemplateProjectController : Controller
    {
        private readonly ITemplateProjectService _templateProjectService;
        private IMapper _mapper;

        public TemplateProjectController(IMapper mapper, ITemplateProjectService templateProjectService)
        {
            _mapper = mapper;
            _templateProjectService = templateProjectService;

        }
        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TemplateProject> templateFonctionnels = await _templateProjectService.GetAllTemplateProject();
                List<TemplateProjectVM> templateFonctionnelsVM = _mapper.Map<List<TemplateProjectVM>>(templateFonctionnels);
                return Ok(templateFonctionnelsVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateProject Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateProjectlDetail(int id)
        {
            try
            {
                TemplateProject templateProject = await _templateProjectService.DetailTemplateProject(id);
                TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                return Ok(templateProjectVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetail error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("DetailsTechnique")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DetailsTechnique(int id)
        {
            try
            {
                List<TemplateTechnique> templateProject = await _templateProjectService.DetailsTechnique(id);
                List<TemplateTechnique> templateProjectVM = _mapper.Map<List<TemplateTechnique>>(templateProject);
                return Ok(templateProjectVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetail error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("DetailsEntity")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DetailsEntity(int id)
        {
            try
            {
                TemplateFonctionnel templateProject = await _templateProjectService.DetailsFonctionnel(id);
                TemplateFonctionnelVM templateProjectVM = _mapper.Map<TemplateFonctionnelVM>(templateProject);
                return Ok(templateProjectVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetail error: " + ex.Message);
            }
        }
        


        [HttpGet]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateProjectCreate()
        {
            try
            {                
                    TemplateProject templateProject = await _templateProjectService.CreateTemplateProject();
                    TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                    return Ok(templateProjectVM);
                
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateProjectCreate error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateProjectCreate([FromBody] TemplateProject templateProject)
        {
            try
            {   
                    TemplateProject _templateProject = await _templateProjectService.CreateTemplateProject(templateProject);
                    TemplateProjectVM _templateProjectVM = _mapper.Map<TemplateProjectVM>(_templateProject);
                    return Ok(_templateProjectVM);
                
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateProjectCreate error: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditTemplateProject(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateProject templateProject = await this._templateProjectService.EditTemplateProject(id);
                    TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                    return Ok(templateProjectVM);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateFonctionnelEntity error: " + ex.Message);
            }
            return BadRequest("EditTemplateFonctionnelEntity error: ");
        }

        [HttpPost]
        [Route("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditTemplateProject([FromBody] TemplateProject templateProject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateProject _templateFonctionnel = await this._templateProjectService.EditTemplateProject(templateProject);
                    TemplateProjectVM templateFonctionnelVM = _mapper.Map<TemplateProjectVM>(_templateFonctionnel);
                    return Ok(templateFonctionnelVM);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateFonctionnelEntity error: " + ex.Message);
            }
            return BadRequest("EditTemplateFonctionnelEntity error: ");
        }

        [Route("Delete")]
        public void TemplateProjectDelete(int id)
        {
            this._templateProjectService.DeleteTemplateProject(id);
        }

    }
}
