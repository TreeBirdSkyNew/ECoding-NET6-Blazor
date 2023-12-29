using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    [Route("TemplateResult")]
    public class TemplateResultController : Controller
    {

        private ITemplateResultApiClient _resultApiClient;
        private const string _clientName = "ClientApiResult";

        public TemplateResultController(ITemplateResultApiClient resultApiClient)
        {
            _resultApiClient = resultApiClient;
        }

        [HttpGet]
        [Route("TemplateResult/Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateResultVM> templateResults = await _resultApiClient.GetAllTemplateResult(_clientName,"api/TemplateResult/Index");
            return View(templateResults);
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateResultVM templateResultVM = await _resultApiClient.GetTemplateResult(_clientName,"api/TemplateResult/Details/" + id);
            return View(templateResultVM);
        }

        [HttpGet]
        [Route("TemplateResultItems")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateResultItems(int id)
        {
            List<TemplateResultItemVM> TemplateResultItemVMs = await _resultApiClient.GetAllTemplateResultItem(_clientName,"api/TemplateResult/TemplateResultItems/" + id);
            return Json(TemplateResultItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("TemplateResultItem")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateResultItem(int id)
        {
            TemplateResultItemVM TemplateResultItemVM = await _resultApiClient.GetTemplateResultItem(_clientName,"api/TemplateResult/ResultItemDetails/" + id);
            return View(TemplateResultItemVM);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateTemplateResult()
        {
            TemplateResultVM templateResultVM = new TemplateResultVM();
            return View(templateResultVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateResult(TemplateResultVM templateResultVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResultVM), Encoding.UTF8, "application/json");
            await this._resultApiClient.PostTemplateResult(_clientName,"api/TemplateResult/Create", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateResultVM templateResultVM = await _resultApiClient.GetTemplateResult(_clientName,"api/TemplateResult/ResultDetails/" + id);
            return View(templateResultVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateResultVM templateResultVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResultVM), Encoding.UTF8, "application/json");
            await this._resultApiClient.PostTemplateResult(_clientName,"api/TemplateResult/EditItem?id=" + templateResultVM.TemplateResultId, content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("CreateTemplateResultItem")]
        public TemplateResultItemVM CreateTemplateResultItem()
        {
            TemplateResultItemVM templateResultItemVM = new TemplateResultItemVM();
            return templateResultItemVM;
        }

        [HttpPost]
        [Route("CreateTemplateResultItem")]
        public async Task<IActionResult> CreateTemplateResultItem(TemplateResultItemVM templateResulItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResulItemVM), Encoding.UTF8, "application/json");
            await this._resultApiClient.PostTemplateResultItem(_clientName,"api/TemplateResult/CreateTemplateResultItem", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditTemplateResultItem")]
        public IActionResult EditTemplateResultItem(int id)
        {
            TemplateResultItemVM templateResulItemVM = _resultApiClient.GetTemplateResultItem(_clientName,"api/TemplateResult/TemplateResultItem/" + id).Result;
            return View(templateResulItemVM);
        }

        [HttpPost]
        [Route("EditTemplateResultItem")]
        public async Task<IActionResult> EditTemplateResultItem(TemplateResultItemVM templateResultItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResultItemVM), Encoding.UTF8, "application/json");
            await this._resultApiClient.PostTemplateResultItem(_clientName,"api/TemplateResult/EditTemplateResultItem", content);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateResult(int id)
        {
            await this._resultApiClient.DeleteTemplateResult(_clientName,"api/TemplateResult/Delete/" + id);
            return RedirectToAction("Index");
        }


    }
}
