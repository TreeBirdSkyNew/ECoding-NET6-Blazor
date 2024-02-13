using E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_Services.Technique;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using E_CODING_FrontBlazor.DTOs;

namespace TemplateTechnique_WebApi.Controllers
{
    [Route("api/TemplateTechnique")]
    public class TemplateTechniqueController : ControllerBase
    {
        private readonly ITechniqueRepositoryWrapper _techniqueRepositoryWrapper;
        private readonly IMapper _mapper;
        public TemplateTechniqueController(
            IMapper mapper ,
            ITechniqueRepositoryWrapper techniqueRepositoryWrapper)
        {
            _mapper = mapper;
            _techniqueRepositoryWrapper = techniqueRepositoryWrapper;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {   
            try
            {
                IEnumerable<TemplateTechnique> templateTechniques = _techniqueRepositoryWrapper.TechniqueRepository.GetAllTemplateTechnique();
                List<TemplateTechniqueVM> templateTechniquesVM = _mapper.Map<List<TemplateTechniqueVM>>(templateTechniques.ToList());
                return Ok(templateTechniquesVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("ProjectAllTechniques/{id}")]
        public IActionResult ProjectAllTechniques(int id)
        {
            try
            {
                IEnumerable<TemplateTechnique> ProjectTemplateTechniques = _techniqueRepositoryWrapper.TechniqueRepository.GetProjectAllTemplateTechnique(id);
                if (ProjectTemplateTechniques.ToList().Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    IEnumerable<TemplateTechniqueVM> ProjectTemplateTechniqueVMs = _mapper.Map<List<TemplateTechniqueVM>>(ProjectTemplateTechniques);
                    return Ok(ProjectTemplateTechniqueVMs);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("TechniqueAllItems/{id}")]
        public IActionResult TemplateTechniqueAllItems(int id)
        {
            try
            {
                IEnumerable<TemplateTechniqueItem> TemplateTechniqueAllItems = _techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id);
                if (TemplateTechniqueAllItems.ToList().Count==0)
                {
                    return NotFound();
                }
                else
                { 
                    IEnumerable<TemplateTechniqueItemVM> TemplateTechniqueAllItemsVM = _mapper.Map<List<TemplateTechniqueItemVM>>(TemplateTechniqueAllItems);
                    return Ok(TemplateTechniqueAllItemsVM);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "TemplateTechniqueById")]
        [Route("TechniqueDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateTechnique))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult TemplateTechniqueDetails(int id)
        {
            try
            {
                TemplateTechnique templateTechnique = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechnique is null)
                {
                    return NotFound();
                }
                else
                {
                    TemplateTechniqueVM templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                    List<TemplateTechniqueItem> templateTechniqueItems = _techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id).ToList();
                    if (templateTechniqueItems.Any())
                    {
                        List<TemplateTechniqueItemVM> templateTechniqueItemsVM = _mapper.Map<List<TemplateTechniqueItemVM>>(templateTechniqueItems);
                        templateTechniqueVM.TemplateTechniqueItem = templateTechniqueItemsVM;
                    }
                    return Ok(templateTechniqueVM);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateTechnique")]
        public IActionResult TemplateTechniqueCreate([FromBody] TemplateTechniqueVM templateTechniqueVM)
        {
            try
            {
                if (templateTechniqueVM is null)
                {
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                TemplateTechnique templateTechniqueEntity = _mapper.Map<TemplateTechnique>(templateTechniqueVM);
                _techniqueRepositoryWrapper.TechniqueRepository.CreateTemplateTechnique(templateTechniqueEntity);
                _techniqueRepositoryWrapper.Save();
                var templateTechnique = _mapper.Map<TemplateTechniqueVM>(templateTechniqueEntity);
                return CreatedAtRoute("TemplateTechniqueById", new { id = templateTechnique.TemplateTechniqueId }, templateTechnique);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        [Route("EditTechnique/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult TemplateTechniqueEdit(int id, [FromBody] TemplateTechniqueVM templateTechniqueVM)
        {
            try
            {
                if (templateTechniqueVM is null)
                {

                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var templateTechniqueEntity = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechniqueEntity is null)
                {
                    return NotFound();
                }
                _mapper.Map(templateTechniqueVM, templateTechniqueEntity);
                _techniqueRepositoryWrapper.TechniqueRepository.UpdateTemplateTechnique(templateTechniqueEntity);
                _techniqueRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("DeleteTechnique/{id}")]
        [HttpDelete]
        public void DeleteTemplateTechnique(int id)
        {
            try
            {
                var templateTechnique = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechnique == null)
                {
                }
                if (_techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id).Any())
                {
                }
                _techniqueRepositoryWrapper.TechniqueRepository.DeleteTemplateTechnique(templateTechnique);
                _techniqueRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
            }
        }

        [HttpGet("{id}", Name = "TemplateTechniqueItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("TechniqueItemDetails/{id}")]
        public IActionResult TemplateTechniqueItemDetails(int id)
        {
            try
            {
                TemplateTechniqueItem templateTechniqueItem = _techniqueRepositoryWrapper.TechniqueItemRepository.FindByCondition(id);
                if (templateTechniqueItem is null)
                {
                    return NotFound();
                }
                else 
                {
                    TemplateTechniqueItemVM templateTechniqueVM = _mapper.Map<TemplateTechniqueItemVM>(templateTechniqueItem);
                    return Ok(templateTechniqueVM);
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
        [Route("CreateTechniqueItem")]
        public IActionResult TemplateTechniqueItemCreate([FromBody] TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            try
            {
                if (templateTechniqueItemVM is null)
                {
                    return BadRequest("templateTechniqueItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                TemplateTechniqueItem templateTechniqueItemEntity = _mapper.Map<TemplateTechniqueItem>(templateTechniqueItemVM);
                _techniqueRepositoryWrapper.TechniqueItemRepository.CreateTemplateTechniqueItem(templateTechniqueItemEntity);
                _techniqueRepositoryWrapper.Save();
                TemplateTechniqueItemVM templateTechniqueItem = _mapper.Map<TemplateTechniqueItemVM>(templateTechniqueItemEntity);
                return CreatedAtRoute("TemplateTechniqueItemById", new { id = templateTechniqueItem.TemplateTechniqueItemId }, templateTechniqueItem);
            }
            catch (Exception ex)
            {
                    return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("EditTechniqueItem/{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult EditTemplateTechniqueItem(int id, [FromBody] TemplateTechniqueItemVM templateTechniqueItemVM)
        {            
            try
            {
                if (templateTechniqueItemVM is null)
                {
                    return BadRequest("templateTechniqueItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var templateTechniqueItem = _mapper.Map<TemplateTechniqueItem>(templateTechniqueItemVM);
                _techniqueRepositoryWrapper.TechniqueItemRepository.UpdateTemplateTechniqueItem(templateTechniqueItem);
                _techniqueRepositoryWrapper.Save();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateTechniqueItem error: " + ex.Message);
            }
        }

        [Route("DeleteTechniqueItem/{id}")]
        [HttpDelete]
        public void DeleteTemplateTechniqueItem(int id)
        {
            try
            {
                var templateTechnique = _techniqueRepositoryWrapper.TechniqueRepository.FindByCondition(id);
                if (templateTechnique == null)
                {
                }
                if (_techniqueRepositoryWrapper.TechniqueItemRepository.GetAllTemplateTechniqueItem(id).Any())
                {
                }
                _techniqueRepositoryWrapper.TechniqueRepository.DeleteTemplateTechnique(templateTechnique);
                _techniqueRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
