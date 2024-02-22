using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workersApi.Context;
using workersApi.Models;
using Newtonsoft.Json;
using workersApi.Utils;

namespace workersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Projects : ControllerBase
    {

        private readonly DataContext _context;
        public Projects(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            List<DBProject> projects = _context.Projects.ToList();

            List<Project> resultList = ProjectUtils.ParseProject(projects);
            return Ok(resultList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            DBProject project = _context.Projects.Find(id);
            if (project == null) return NotFound("This project doesn't exist");

            dynamic projectParsed = ProjectUtils.ParseProject(project);
            
            return Ok(projectParsed);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(NewProject project)
        {
            List<Assigned> assigneds = new();

            foreach (int assigned in project.Assigned)
            {
                Employee employee = _context.Employees.Find(assigned);
                assigneds.Add(new()
                {
                    Id = employee.Id,
                    Name = employee.Name 
                }
                );
            }

            DBProject result = new()
            {
                Id = project.Id,
                Name = project.Name,
                Assigned = JsonConvert.SerializeObject(assigneds)
            };


            _context.Projects.Add(result);
            _context.SaveChanges();

            List<DBProject> projects =_context.Projects.ToList();
            List<Project> projectsList = ProjectUtils.ParseProject(projects);

            return Ok(projectsList);
        }

    }
}
