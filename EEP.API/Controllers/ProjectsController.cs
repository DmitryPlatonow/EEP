using AutoMapper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.Entities;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EEP.API.Controllers
{
    // [Authorize]
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
            return Json(await _projectService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProjectById")]
        public async Task<IHttpActionResult> GetProjectById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var project = await _projectService.GetByIdAsync(id);
            if (project != null)
            {
                return Json(project);
            }
            return NotFound();
        }

         [HttpPost]
       // [EnableCors(origins: "http://www.example.com", headers: "*", methods: "get,post")]
      //  [Route("create")]
        public async Task<IHttpActionResult> CreateProject(ProjectBindingModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = new Project();
            Mapper.Map(projectModel, project);

            var result = await _projectService.CreateAsync(project);

            if (result == null)
            {
                return BadRequest();
            }

            return Json(project);
        }

        [HttpPatch]
        [Route("update")]
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

            return Json(project);
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
