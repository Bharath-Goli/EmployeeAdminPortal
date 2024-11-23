using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees() {
            var allemployees = dbContext.Employees.ToList();
            return Ok(allemployees);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetEmployeeById(Guid id)
        {
         var b=   dbContext.Employees.Find(id);
            if (b is null) 
            {
                return NotFound();
            }

            return Ok(b);
        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDtocs addEmployeeDtocs) {

            var a = new Employee()
            {
                Name = addEmployeeDtocs.Name,
                Email = addEmployeeDtocs.Email,
                Phone = addEmployeeDtocs.Phone,
                Salary = addEmployeeDtocs.Salary,



            };

            dbContext.Employees.Add(a);
            dbContext.SaveChanges();

            return Ok(a);
        
        }


        [HttpPut]

        [Route("{id:guid}")]
        public IActionResult UpdtaeEmployee(Guid id,UpdateEmployeeDto updateEmployeeDto) 
        {

            var f = dbContext.Employees.Find(id);
            if (f is null)
            {
                return NotFound();
            }
            f.Name = updateEmployeeDto.Name;
            f.Email = updateEmployeeDto.Email;
            f.Phone = updateEmployeeDto.Phone;
            f.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();

            return Ok(f);

        }


        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id) 
        
        {
        
        var j=dbContext.Employees.Find(id);
            if(j is null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(j);
            return Ok(j);
        
        }
    }
}
