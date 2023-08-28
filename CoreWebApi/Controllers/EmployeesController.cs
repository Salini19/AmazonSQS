using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreWebApi;
using CoreWebApi.Models;
using CoreWebApi.Services;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IMethods imethods;

        public EmployeesController(IMethods methods)
        {
            imethods = methods;
        }

        // GET: Employees
        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = imethods.GetAllEmployees();
            
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Employee employee = imethods.GetEmployeeByID(id);
            if (employee == null)
            {
                return NotFound();
            }


            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            imethods.AddEmp(employee);
            return Ok(employee);
        }


        [HttpPut]
        public IActionResult Edit( Employee employee)
        {
            imethods.UpdateEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            imethods.DeleteEmp(id);
            return Ok();
        }

       

        
    }
}
