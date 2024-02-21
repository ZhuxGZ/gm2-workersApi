using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workersApi.Context;
using workersApi.Models;
using System.Linq;

namespace workersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {

        private readonly DataContext _context;
        public Employees(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees(DateTime fromDate, DateTime toDate, string filter = null)
        {

            List<Employee> employees = _context.Employees.ToList();

            if (fromDate != new DateTime(0001, 01, 01) || fromDate != new DateTime(0001, 01, 01))
            {
                dynamic filteredList = employees.Where(obj => obj.Joined >= fromDate && obj.Joined <= toDate).ToList();
                employees = filteredList;
            }

            switch (filter)
            {
                case "newer":
                    dynamic orderList = employees.OrderByDescending(obj => obj.Joined).ToList();
                    employees = orderList;
                    break;

                case "older":
                    orderList = employees.OrderBy(obj => obj.Joined).ToList();
                    employees = orderList;
                    break;
            }

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {

            Employee employee = _context.Employees.Find(id);
            return Ok(employee);

        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {

            employee.Joined = DateTime.Now;
            _context.Employees.Add(employee);
            _context.SaveChanges();


            List<Employee> employees = _context.Employees.ToList();

            return Ok(employees);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            Employee employee = _context.Employees.Find(id);

            foreach (PropertyInfo prop in request.GetType().GetProperties())
            {
                dynamic employeeProp = employee.GetType().GetProperty(prop.Name);
                dynamic newValue = prop.GetValue(request, null);

                if (newValue.GetType() == typeof(string))
                {
                    if (newValue != "string")
                    {
                        if (newValue != null && newValue != "string" && newValue != String.Empty)
                        {
                            employeeProp.SetValue(employee, newValue);
                        }
                    }

                }else if (newValue.GetType() == typeof(int))
                {
                
                    
                    if (newValue != null && newValue != 0)
                    {
                        employeeProp.SetValue(employee, newValue);
                    }
               
                }

            }

            _context.SaveChanges();


            List<Employee> employees = _context.Employees.ToList();

            return Ok(employees);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);

            if (employee == null) return null;

            _context.Employees.Remove(employee);
            _context.SaveChanges();


            List<Employee> employees = _context.Employees.ToList();

            return Ok(employees);

        }
    }


}
