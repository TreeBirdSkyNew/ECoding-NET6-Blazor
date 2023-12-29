using _4___E_CODING_DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_MVC_NET6_0.InfraStructure.Solution;
using E_CODING_MVC_NET6_0.InfraStructure.Project;

namespace E_CODING_MVC_NET6_0.Controllers
{
    [Route("TemplateSolution")]
    public class TemplateSolutionController : Controller
    {
        private ITemplateProjectApiClient _projectApiClient;
        private ITemplateSolutionApiClient _solutionApiClient;
        
        private const string _clientProjectName = "ClientApiProject";
        private const string _clientSolutionName = "ClientApiSolution";

        public TemplateSolutionController(
                        ITemplateProjectApiClient projectApiClient,
                        ITemplateSolutionApiClient solutionApiClient)
        {
            _projectApiClient = projectApiClient;
            _solutionApiClient = solutionApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateSolutionVM?> templateSolutionVMs = await _solutionApiClient.GetAllTemplateSolution(_clientSolutionName, "api/TemplateSolution/Index");
            return View(templateSolutionVMs);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateSolutionVM? templateSolutionVM = await _solutionApiClient.GetTemplateSolution(_clientSolutionName, "api/TemplateSolution/SolutionDetails/" + id);
            return View(templateSolutionVM);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateSolutionVM? templateSolutionVM = await _solutionApiClient.GetTemplateSolution(_clientSolutionName, "api/TemplateSolution/SolutionDetails/" + id);
            return View(templateSolutionVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName, "api/TemplateProject/Edit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject()
        {
            TemplateProjectVM templateProjectVM = new TemplateProjectVM();
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName, "api/TemplateProject/Create", content);
            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateProject(int id)
        {
            await this._projectApiClient.DeleteTemplateProject(_clientProjectName, $"api/TemplateProject/Delete/{id}");
            return RedirectToAction("Index");
        }
    }
}
