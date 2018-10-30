using AutoMapper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EEP.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Json(await _projectService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProjectById")]
        public async Task<IHttpActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsunc(id);
            if (project != null)
            {
                return Json(project);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateProject(ProjectBindingModel projectModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = new Project();
            Mapper.Map(projectModel, project);

            var result = await _projectService.CreateProjectAsunc(project);

            if (result == null)
            {
                return BadRequest();
            }

            return Json(project);
        }



    }
}
