using AutoMapper;
using E_CODING_DAL.Models;
using E_CODING_FrontBlazor.DTOs;
using E_CODING_Services.Result;
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
using System.Threading.Tasks;


namespace __WEB_API__TemplateResult_WebApi
{
    [Route("api/TemplateResult")]
    public class TemplateResultController : ControllerBase
    {
        private readonly IResultRepositoryWrapper _resultRepositoryWrapper;
        private readonly IMapper _mapper;

        public TemplateResultController(
            IResultRepositoryWrapper resultRepositoryWrapper,
            IMapper mapper)
        {
            _resultRepositoryWrapper = resultRepositoryWrapper;
            _mapper = mapper;
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
                IEnumerable<TemplateResultVM> templateResultsVM = _mapper.Map<List<TemplateResultVM>>(templateResults);
                return Ok(templateResultsVM);
            }
            catch (Exception ex)
            {
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
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
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
                    return BadRequest("TemplateResulItem object is null");
                }
                if (!ModelState.IsValid)
                {
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
                    return BadRequest("TemplateResult object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var templateResultEntity = _resultRepositoryWrapper.ResultRepository.FindByCondition(id);
                if (templateResultEntity is null)
                {
                    return NotFound();
                }
                _mapper.Map(templateResultVM, templateResultEntity);
                _resultRepositoryWrapper.ResultRepository.UpdateTemplateResult(templateResultEntity);
                _resultRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
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
                    return BadRequest("TemplateResulItemVM object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var templateResulItemEntity = _resultRepositoryWrapper.ResultItemRepository.FindByCondition(id);
                if (templateResulItemEntity is null)
                {
                    return NotFound();
                }
                _mapper.Map(templateResulItemVM, templateResulItemEntity);
                _resultRepositoryWrapper.ResultItemRepository.UpdateTemplateResultItem(templateResulItemEntity);
                _resultRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
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
                }
                if (_resultRepositoryWrapper.ResultItemRepository.GetAllTemplateResultItem(id).Any())
                {
                }
                _resultRepositoryWrapper.ResultRepository.DeleteTemplateResult(templateResult);
                _resultRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
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
                }
                if (_resultRepositoryWrapper.ResultItemRepository.GetAllTemplateResultItem(id).Any())
                {
                }
                _resultRepositoryWrapper.ResultItemRepository.DeleteTemplateResultItem(templateResultItem);
                _resultRepositoryWrapper.Save();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
