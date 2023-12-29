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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace __WEB_API__TemplateResult_WebApi
{
    [Route("api/TemplateResult")]
    public class TemplateResultController : Controller
    {
        private readonly ITemplateResultService _itemplateResultService;
        private IMapper _mapper;
        public TemplateResultController(IMapper mapper , ITemplateResultService itemplateResultService)
        {
            _mapper = mapper;
            _itemplateResultService = itemplateResultService;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Index()
        {            
            try
            {
                List<TemplateResult> templateResults = await _itemplateResultService.GetAllTemplateResult();
                List<TemplateResultVM> templateResultsVM = _mapper.Map<List<TemplateResultVM>>(templateResults);
                return Ok(templateResultsVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResult Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateResultItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateResultItems(int id)
        {            
            try
            {
                List<TemplateResultItem> templateResultItems = await _itemplateResultService.DetailTemplateResultItems(id);
                List<TemplateResulItemVM> templateResultItemsVM = _mapper.Map<List<TemplateResulItemVM>>(templateResultItems);
                return Ok(templateResultItemsVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResult TemplateResultItems error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateResultItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateResultItem(int id)
        {            
            try
            {
                TemplateResultItem templateTechniqueItem = await _itemplateResultService.DetailTemplateResultItem(id);
                TemplateResulItemVM templateResultItemVM = _mapper.Map<TemplateResulItemVM>(templateTechniqueItem);
                return Ok(templateResultItemVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResult TemplateResultItem error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateResultDetail(int id)
        {            
            try
            {
                TemplateResult templateResult = await _itemplateResultService.DetailTemplateResult(id);
                TemplateResultVM templateResultVM = _mapper.Map<TemplateResultVM>(templateResult);
                return Ok(templateResultVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResult Details error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("DetailsItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateResultItemDetail(int id)
        {
            try
            {
                TemplateResultItem templateResult = await _itemplateResultService.DetailTemplateResultItem(id);
                TemplateResulItemVM templateResultVM = _mapper.Map<TemplateResulItemVM>(templateResult);
                return Ok(templateResultVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResult Details error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateResultCreate()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateResult templateResult = await _itemplateResultService.CreateTemplateResult();
                    TemplateResultVM templateResultVM = _mapper.Map<TemplateResultVM>(templateResult);
                    return Ok(templateResultVM);
                }
                else return BadRequest("TemplateResultCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResultCreate error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateResultCreate([FromBody] TemplateResult templateResult)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateResult _templateResult = await _itemplateResultService.CreateTemplateResult(templateResult);
                    TemplateResultVM templateResultVM = _mapper.Map<TemplateResultVM>(templateResult);
                    return Ok(templateResultVM);
                }
                else return BadRequest("TemplateResultCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResultCreate error: " + ex.Message);
            }
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateItem")]
        public async Task<IActionResult> TemplateResultItemCreate([FromBody]  TemplateResultItem templateResultItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateResultItem _templateResultItem = await _itemplateResultService.CreateTemplateResultItem(templateResultItem);
                    TemplateResulItemVM _templateResultItemVM = _mapper.Map<TemplateResulItemVM>(_templateResultItem);
                    return Ok(_templateResultItemVM);
                }
                else return BadRequest("TemplateResultItemCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateResultItemCreate error: " + ex.Message);
            }

        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Edit")]
        public async Task<IActionResult> TemplateResultEdit([FromBody] TemplateResult templateResult)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateResult _templateResult = await _itemplateResultService.EditTemplateResult(templateResult);
                    TemplateResultVM _templateResultVM = _mapper.Map<TemplateResultVM>(_templateResult);
                    return Ok(_templateResultVM);
                }
                else
                    return BadRequest("EditTemplateResultItem error: ");
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateResultItem error: " + ex.Message);
            }
        }        
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("EditItem")]
        public async Task<IActionResult> EditTemplateResultItem([FromBody] TemplateResultItem templateResultItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateResultItem _templateResultItem = await _itemplateResultService.EditTemplateResultItem(templateResultItem);
                    TemplateResulItemVM _templateResultItemVM = _mapper.Map<TemplateResulItemVM>(_templateResultItem);
                    return Ok(_templateResultItemVM);
                }
                else
                    return BadRequest("EditTemplateResultItem error: " );
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateResultItem error: " + ex.Message);
            }
        }

        


        

       
        [Route("Delete")]
        public ActionResult DeleteTemplateResult(int id)
        {
            this._itemplateResultService.DeleteTemplateResult(id);
            return RedirectToAction("Index");
        }
    }
}
