using E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_Services.Result;
using E_CODING_Services.Technique;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using TemplateResult = E_CODING_DAL.Models.TemplateResult;

namespace __WEB_API__TemplateResult_WebApi
{
    [Route("api/TemplateResult")]
    public class TemplateResultController : ControllerBase
    {
        private readonly IResultRepositoryWrapper _resultRepositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public TemplateResultController(
            IResultRepositoryWrapper resultRepositoryWrapper,
            IMapper mapper,
            ILoggerManager logger)
        {
            _resultRepositoryWrapper = resultRepositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<TemplateResult> templateResults = _resultRepositoryWrapper.ResultRepository.GetAllTemplateResult();
                _logger.LogInfo($"Returned all templateResults from database.");
                IEnumerable<TemplateResultVM> templateResultsVM = _mapper.Map<List<TemplateResultVM>>(templateResults);
                return Ok(templateResultsVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResult/Index action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("TemplateResultItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult TemplateResultItems(int id)
        {            
            try
            {
                IEnumerable<TemplateResultItem> templateResultItems = _resultRepositoryWrapper.ResultItemRepository.GetAllTemplateResultItem(id);
                IEnumerable<TemplateResultItemVM> templateResultItemsVM = _mapper.Map<IEnumerable<TemplateResultItemVM>>(templateResultItems);
                return Ok(templateResultItemsVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResult/Index action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("TemplateResultItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult TemplateResultItem(int id)
        {            
            try
            {
                TemplateResultItem templateTechniqueItem = _resultRepositoryWrapper.ResultItemRepository.FindByCondition(id);
                TemplateResultItemVM templateResultItemVM = _mapper.Map<TemplateResultItemVM>(templateTechniqueItem);
                return Ok(templateResultItemVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResult/TemplateResultItem action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateResultCreate()
        {
            try
            {
                TemplateResultVM templateResult = new ();
                TemplateResultVM templateResultVM = _mapper.Map<TemplateResultVM>(templateResult);
                return CreatedAtAction("templateResult", new { id = templateResult.TemplateResultId }, templateResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResult/Create action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateResultCreate([FromBody] TemplateResultVM templateResultVM)
        {
            try
            {
                if (templateResultVM is null)
                {
                    _logger.LogError("templateTechnique object sent from client is null.");
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechnique object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateResult templateResultEntity = _mapper.Map<TemplateResult>(templateResultVM);
                _resultRepositoryWrapper.ResultRepository.CreateTemplateResult(templateResultEntity);
                _resultRepositoryWrapper.Save();
                var templateResult = _mapper.Map<TemplateResultVM>(templateResultEntity);

                return CreatedAtAction("templateResultVM", new { id = templateResult.TemplateResultId }, templateResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResultDetails for TemplateResultId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateItem")]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateResultItemCreate()
        {
            try
            {
                TemplateResultItem templateResultItem = new ();
                var templateResult = _mapper.Map<TemplateResultVM>(templateResultItem);
                return CreatedAtAction("templateResultVM", new { id = templateResult.TemplateResultId }, templateResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResultItemCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateItem")]
        [ValidateAntiForgeryToken]
        public IActionResult TemplateResultItemCreate([FromBody] TemplateResultItemVM templateResultItemVM)
        {
            try
            {
                if (templateResultItemVM is null)
                {
                    _logger.LogError("TemplateResulItem object sent from client is null.");
                    return BadRequest("TemplateResulItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid TemplateResulItem object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateResultItem templateResultItemEntity = _mapper.Map<TemplateResultItem>(templateResultItemVM);
                _resultRepositoryWrapper.ResultItemRepository.CreateTemplateResultItem(templateResultItemEntity);
                _resultRepositoryWrapper.Save();
                var templateResultItem = _mapper.Map<TemplateResultItemVM>(templateResultItemEntity);
                return CreatedAtAction("templateResultItemVM", new { id = templateResultItem.TemplateResultItemId }, templateResultItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResulItem action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public IActionResult TemplateResultEdit(int id, [FromBody] TemplateResultVM templateResultVM)
        {
            try
            {
                if (templateResultVM is null)
                {
                    _logger.LogError("TemplateResult object sent from client is null.");
                    return BadRequest("TemplateResult object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid TemplateResult object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateResultEntity = _resultRepositoryWrapper.ResultRepository.FindByCondition(id);
                if (templateResultEntity is null)
                {
                    _logger.LogError($"TemplateResult with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(templateResultVM, templateResultEntity);
                _resultRepositoryWrapper.ResultRepository.UpdateTemplateResult(templateResultEntity);
                _resultRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResult action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateAntiForgeryToken]
        [Route("EditItem")]
        public IActionResult TemplateResultItemEdit(int id, [FromBody] TemplateResultItemVM templateResulItemVM)
        {
            try
            {
                if (templateResulItemVM is null)
                {
                    _logger.LogError("TemplateResulItemVM object sent from client is null.");
                    return BadRequest("TemplateResulItemVM object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid TemplateResulItemVM object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateResulItemEntity = _resultRepositoryWrapper.ResultItemRepository.FindByCondition(id);
                if (templateResulItemEntity is null)
                {
                    _logger.LogError($"TemplateResulItemVM with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(templateResulItemVM, templateResulItemEntity);
                _resultRepositoryWrapper.ResultItemRepository.UpdateTemplateResultItem(templateResulItemEntity);
                _resultRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateResulItemVM action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Delete")]
        [HttpDelete("{id}")]
        public void DeleteTemplateResult(int id)
        {
            try
            {
                var templateResult = _resultRepositoryWrapper.ResultRepository.FindByCondition(id);
                if (templateResult == null)
                {
                    _logger.LogError($"TemplateResult with id: {id}, hasn't been found in db.");
                }
                if (_resultRepositoryWrapper.ResultItemRepository.GetAllTemplateResultItem(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                }
                _resultRepositoryWrapper.ResultRepository.DeleteTemplateResult(templateResult);
                _resultRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTemplateResult action: {ex.Message}");
            }
        }

        [Route("Delete")]
        [HttpDelete("{id}")]
        public void DeleteTemplateResultItem(int id)
        {
            try
            {
                var templateResultItem = _resultRepositoryWrapper.ResultItemRepository.FindByCondition(id);
                if (templateResultItem == null)
                {
                    _logger.LogError($"TemplateResultItem with id: {id}, hasn't been found in db.");
                }
                if (_resultRepositoryWrapper.ResultItemRepository.GetAllTemplateResultItem(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                }
                _resultRepositoryWrapper.ResultItemRepository.DeleteTemplateResultItem(templateResultItem);
                _resultRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTemplateResultItem action: {ex.Message}");
            }
        }
    }
}
