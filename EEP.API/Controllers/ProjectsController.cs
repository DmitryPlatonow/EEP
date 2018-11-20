using AutoMapper;
using EEP.API.Helper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EEP.API.Controllers
{
    // [Authorize]
    [CustomJson]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            return Ok(await _projectService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProjectById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var project = await _projectService.GetByIdAsync(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IHttpActionResult> CreateProject(ProjectBindingModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = new Project();
            Mapper.Map(projectModel, project);

            var result = await _projectService.CreateAsync(project);

            return Ok(project);
        }

        [HttpPatch]
        public async Task<IHttpActionResult> UpdateProject(ProjectBindingModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = new Project();
            Mapper.Map(projectModel, project);

            var result = await _projectService.UpdateAsync(project);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(project);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteProject(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            await _projectService.DeleteAsync(id);

            return Ok();
        }
    }
}
