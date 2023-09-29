using ESSAngular.Data;
using ESSAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESSAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ESSAngularDbContext _angularDbContext;
        public EmployeeController(ESSAngularDbContext angularDbContext) {
        
            _angularDbContext = angularDbContext;   
        }

       
        [HttpGet]
        public  async  Task<ActionResult> GetAllEmployees() {


          var response =  await  _angularDbContext.Employees.ToListAsync();

            return Ok(response);
        
        }


        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee  employeeRequest)
        {

            await _angularDbContext.Employees.AddAsync(employeeRequest);
            _angularDbContext.SaveChanges();
            return Ok(employeeRequest);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public  async Task<ActionResult> GetEmployee([FromRoute] Guid id)
        {
           // var emp = new Employee();
          var  emp = await _angularDbContext.Employees.FirstOrDefaultAsync(x=> x.Id == id);

            if(emp is not null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }

            
        }


    }
}
