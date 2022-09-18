using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.EmployeeData;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
  
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _EmployeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _EmployeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok (_EmployeeData.GetEmployees());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid Id)
        {
            Employee employee = _EmployeeData.GetEmployee(Id);

            if (employee == null)
                return NotFound($"Employee with this {Id} was not found");

            return Ok(employee);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _EmployeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + ":/?" + HttpContext.Request.Host + HttpContext.Request.Path + employee.Id,employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid  id)
        {

            Employee employee = _EmployeeData.GetEmployee(id);

            if (employee != null)
            {
                _EmployeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with this {id} was not found");
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee (Guid id,Employee employee)
        {
            Employee exemployee = _EmployeeData.GetEmployee(id);
            if (exemployee!=null)
            {
                employee.Id = exemployee.Id;
                _EmployeeData.EditEmployee(employee);
                return Ok(exemployee);
            }
            return NotFound($"Employee with this {id} was not found");

        }
    }
}
