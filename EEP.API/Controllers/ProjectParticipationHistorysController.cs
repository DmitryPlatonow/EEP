using AutoMapper;
using EEP.API.Helper;
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
using System.Web.Http.Cors;

namespace EEP.API.Controllers
{
    [CustomJson]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectParticipationHistorysController : ApiController
    {
        private IProjectParticipationHistoryService _projectParticipationHistoryService;

        public ProjectParticipationHistorysController(IProjectParticipationHistoryService projectParticipationHistoryService)
        {
            _projectParticipationHistoryService = projectParticipationHistoryService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _projectParticipationHistoryService.GetAllAsync());
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> GetProjectById(int id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    var project = await _projectParticipationHistory.GetByIdAsync(id);
        //    if (project != null)
        //    {
        //        return Ok(project);
        //    }
        //    return NotFound();
        //}


        [HttpPost]
        public async Task<IHttpActionResult> Create(ProjectParticipationHistoryBindingModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProjectParticipationHistory projectHistory = new ProjectParticipationHistory();
            Mapper.Map(projectModel, projectHistory);

            var result = await _projectParticipationHistoryService.CreateAsync(projectHistory);

            return Ok(result);
        }

        //[HttpPatch]
        //public async Task<IHttpActionResult> UpdateProject(ProjectParticipationHistoryBindingModel projectModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Project project = new Project();
        //    Mapper.Map(projectModel, project);

        //    var result = await _projectService.UpdateAsync(project);

        //    if (result == null)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(project);
        //}

        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteProject(int id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        await _projectService.DeleteAsync(id);
        //        return Ok(id);
        //    }
        //    catch (System.Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
