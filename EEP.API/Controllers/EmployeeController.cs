//using AutoMapper;
//using EEP.API.Helper;
//using EEP.API.Models;
//using EEP.BL.Classes;
//using EEP.Entities;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Cors;

//namespace EEP.API.Controllers
//{
//    [CustomJson]
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    public class EmployeesController : ApiController
//    {
//        private IEmployeeService _employeeService;

//        public EmployeesController(IEmployeeService employeeService)
//        {
//            _employeeService = employeeService;
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> Get()
//        {
//            return Ok(await _employeeService.GetAllAsync());
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> GetById(int id)
//        {
//            if (id == null)
//            {
//                return BadRequest();
//            }
//            var project = await _employeeService.GetByIdAsync(id);
//            if (project != null)
//            {
//                return Json(project);
//            }
//            return NotFound();
//        }

//        [HttpPost]
//        public async Task<IHttpActionResult> CreateProject(EmloyeeBindingModel employeeModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            Employee employee = new Employee();
//            Mapper.Map(employeeModel, employee);

//            var result = await _employeeService.CreateAsync(employee);

//            if (result == null)
//            {
//                return BadRequest();
//            }

//            return Json(employee);
//        }

//        [HttpPatch]
//        public async Task<IHttpActionResult> Update(EmloyeeBindingModel employeeModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            Employee employee = new Employee();
//            Mapper.Map(employeeModel, employee);

//            var result = await _employeeService.UpdateAsync(employee);

//            if (result == null)
//            {
//                return BadRequest();
//            }

//            return Json(employee);
//        }

//        [HttpDelete]
//        public async Task<IHttpActionResult> Delete(int id)
//        {
//            if (id == null)
//            {
//                return BadRequest();
//            }

//            await _employeeService.DeleteAsync(id);

//            return Ok();
//        }

//    }
//}
