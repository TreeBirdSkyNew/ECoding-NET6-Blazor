using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{   
    [Route("TemplateFonctionnel")]
    public class TemplateFonctionnelController : Controller
    {
        private ITemplateFonctionnelApiClient _fonctionnelApiClient;
        private const string _clientName = "ClientApiFonctionnel";

        public TemplateFonctionnelController(ITemplateFonctionnelApiClient fonctionnelApiClient)
        {
            _fonctionnelApiClient = fonctionnelApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateFonctionnelVM> templateFonctionnelVMs = await _fonctionnelApiClient.GetAllTemplateFonctionnel(_clientName,"api/TemplateFonctionnel/Index");
            return View(templateFonctionnelVMs);
        }

        [HttpGet]
        [Route("FonctionnelDetails/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateFonctionnelVM templateFonctionnelVM = await _fonctionnelApiClient.GetTemplateFonctionnel(_clientName, "api/TemplateFonctionnel/FonctionnelDetails?id=" + id);
            return View(templateFonctionnelVM);
        }

        [HttpGet]
        [Route("CreateFonctionnel")]
        public IActionResult CreateTemplateFonctionnel()
        {
            TemplateFonctionnelVM templateFonctionnelVM = new TemplateFonctionnelVM();
            return View(templateFonctionnelVM);
        }

        [HttpPost]
        [Route("CreateFonctionnel")]
        public async Task<IActionResult> CreateTemplateFonctionnel(TemplateFonctionnelVM templateFonctionnelVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelVM), Encoding.UTF8, "application/json");
            await this._fonctionnelApiClient.PostTemplateFonctionnel(_clientName, "api/TemplateFonctionnel/CreateFonctionnel", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditFonctionnel/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
             TemplateFonctionnelVM templateFonctionnelVM = await _fonctionnelApiClient.GetTemplateFonctionnel(_clientName, "api/TemplateFonctionnel/FonctionnelDetails?id=" + id);
            return View(templateFonctionnelVM);
        }

        [HttpPost]
        [Route("EditFonctionnel")]
        public async Task<IActionResult> Edit(TemplateFonctionnelVM templateFonctionnelVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelVM), Encoding.UTF8, "application/json");
            await this._fonctionnelApiClient.PostTemplateFonctionnel(_clientName, "api/TemplateFonctionnel/EditFonctionnel?id=" + templateFonctionnelVM.TemplateFonctionnelId, content);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("DeleteFonctionnel/{id}")]
        public async Task<IActionResult> DeleteTemplateFonctionnel(int id)
        {
            await this._fonctionnelApiClient.DeleteTemplateFonctionnel(_clientName, "api/TemplateFonctionnel/DeleteFonctionnel?id=" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("FonctionnelAllEntities/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult TemplateFonctionnelEntities(int id)
        {
            List<TemplateFonctionnelEntityVM> templateTechniqueItemVMs = _fonctionnelApiClient.GetAllTemplateFonctionnelEntity(_clientName, "api/TemplateFonctionnel/FonctionnelAllEntities?id=" + id).Result;
            return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("FonctionnelEntityDetails/{id}")]
        public IActionResult TemplateFonctionnelEntity(int id)
        {
            TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _fonctionnelApiClient.GetTemplateFonctionnelEntity(_clientName, "api/TemplateFonctionnel/FonctionnelEntityDetails?id=" + id).Result;
            return View(templateFonctionnelEntityVM);
        }

        [HttpGet]
        [Route("CreateFonctionnelEntity")]
        public async Task<IActionResult> CreateTemplateFonctionnelEntity()
        {
            await Task.Delay(1);
            TemplateFonctionnelEntityVM templateFonctionnelEntityVM = new TemplateFonctionnelEntityVM();
            return View(templateFonctionnelEntityVM);
        }

        [HttpPost]
        [Route("CreateFonctionnelEntity")]
        public async Task<IActionResult> CreateTemplateFonctionnelEntity(TemplateFonctionnelEntityVM templateFonctionnelEntityVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelEntityVM), Encoding.UTF8, "application/json");
            await this._fonctionnelApiClient.PostTemplateFonctionnelEntity(_clientName, "api/TemplateFonctionnel/CreateFonctionnelEntity", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TemplateFonctionnel/EditFonctionnelEntity/{id}")]
        public async Task<IActionResult> EditTemplateFonctionnelEntity(int id)
        {
            TemplateFonctionnelEntityVM templateFonctionnelEntityVM = await _fonctionnelApiClient.GetTemplateFonctionnelEntity(_clientName, "api/TemplateFonctionnel/FonctionnelEntityDetails?id=" + id);
            return View(templateFonctionnelEntityVM);
        }

        [HttpPost]
        [Route("TemplateFonctionnel/EditFonctionnelEntity")]
        public async Task<IActionResult> EditTemplateFonctionnelEntity(TemplateFonctionnelEntityVM templateFonctionnelEntityVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelEntityVM), Encoding.UTF8, "application/json");
            await this._fonctionnelApiClient.PostTemplateFonctionnelEntity(_clientName,"api/TemplateFonctionnel/EditTemplateFonctionnelEntity", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TemplateFonctionnel/FonctionnelAllProperties/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateFonctionnelProperties(int id)
        {
            List<TemplateFonctionnelPropertyVM> templateTechniqueItemVMs = await _fonctionnelApiClient.GetAllTemplateFonctionnelProperty(_clientName, "api/TemplateFonctionnel/FonctionnelAllProperties?id=" + id);
            return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("TemplateFonctionnel/FonctionnelPropertyDetails/{id}")]
        public async Task<IActionResult> FonctionnelPropertyDetails(int id)
        {
            TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM = await _fonctionnelApiClient.GetTemplateFonctionnelProperty(_clientName, "api/TemplateFonctionnel/FonctionnelPropertyDetails?id=" + id);
            return View(templateFonctionnelPropertyVM);
        }

        [HttpGet]
        [Route("TemplateFonctionnel/CreateFonctionnelProperty")]
        public async Task<IActionResult> CreateTemplateFonctionnelProperty()
        {
            await Task.Delay(1);
            TemplateFonctionnelPropertyVM TemplateFonctionnelPropertyVM = new TemplateFonctionnelPropertyVM();
            return View(TemplateFonctionnelPropertyVM);
        }

        [HttpPost]
        [Route("TemplateFonctionnel/CreateFonctionnelProperty")]
        public async Task<IActionResult> CreateTemplateFonctionnelProperty(TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelPropertyVM), Encoding.UTF8, "application/json");
            await this._fonctionnelApiClient.PostTemplateFonctionnelEntity(_clientName, "api/TemplateFonctionnel/CreateFonctionnelProperty", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TemplateFonctionnel/EditFonctionnelProperty/{id}")]
        public async Task<IActionResult> EditFonctionnelProperty(int id)
        {
            TemplateFonctionnelPropertyVM TemplateFonctionnelPropertyVM = await _fonctionnelApiClient.GetTemplateFonctionnelProperty(_clientName, "api/TemplateFonctionnel/FonctionnelPropertyDetails?id=" + id);
            return View(TemplateFonctionnelPropertyVM);
        }

        [HttpPost]
        [Route("TemplateFonctionnel/EditFonctionnelProperty")]
        public async Task<IActionResult> EditFonctionnelProperty(TemplateFonctionnelEntityVM templateFonctionnelEntityVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelEntityVM), Encoding.UTF8, "application/json");
            await this._fonctionnelApiClient.PostTemplateFonctionnelEntity(_clientName, "api/TemplateFonctionnel/EditTemplateFonctionnelEntity", content);
            return RedirectToAction("Index");
        }

    }
}
