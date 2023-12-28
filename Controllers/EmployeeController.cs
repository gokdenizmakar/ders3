using ders3.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ders3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController()
        {
            _context = new EmployeeDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employee = _context.Employees.ToList();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null) return NotFound();
            else return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.AddDate = DateTime.Now;
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, employee);
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            var eu = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (employee == null)
            {
                return BadRequest();
            }
            else
            {
                eu.FirstName = employee.FirstName;
                eu.LastName = employee.LastName;
                eu.Address = employee.Address;
                eu.BirthDate = employee.BirthDate;
                eu.City = employee.City;
                _context.Employees.Update(eu);
                _context.SaveChanges();
                return Ok();
            }                                    
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);

        }
    }
}
