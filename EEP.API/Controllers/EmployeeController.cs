using AutoMapper;
using EEP.API.Models;
using EEP.BL.Classes;
using EEP.Entities;
using System.Threading.Tasks;
using System.Web.Http;

namespace EEP.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Json(await _employeeService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetById")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var project = await _employeeService.GetByIdAsync(id);
            if (project != null)
            {
                return Json(project);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateProject(EmloyeeBindingModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = new Employee();
            Mapper.Map(employeeModel, employee);

            var result = await _employeeService.CreateAsync(employee);

            if (result == null)
            {
                return BadRequest();
            }

            return Json(employee);
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IHttpActionResult> Update(EmloyeeBindingModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = new Employee();
            Mapper.Map(employeeModel, employee);

            var result = await _employeeService.UpdateAsync(employee);

            if (result == null)
            {
                return BadRequest();
            }

            return Json(employee);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            await _employeeService.DeleteAsync(id);

            return Ok();
        }

    }
}
