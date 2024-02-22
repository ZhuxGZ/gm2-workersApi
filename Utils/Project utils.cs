using System;
using Newtonsoft.Json;
using workersApi.Models;

namespace workersApi.Utils
{
	public class ProjectUtils
	{
		public ProjectUtils()
		{
		}

		public static List<Project> ParseProject(List<DBProject> projects)
		{
            List<Project> projectsList = new();

            foreach (DBProject project in projects)
            {
                List<Assigned> assigned = JsonConvert.DeserializeObject<List<Assigned>>(project.Assigned);

                Project parseProject = new()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Assigned = assigned
                };

                projectsList.Add(parseProject);
            }

            return projectsList;
        }

        public static Project ParseProject(DBProject project)
        {

            List<Assigned> assigned = JsonConvert.DeserializeObject<List<Assigned>>(project.Assigned);

            Project parseProject = new()
            {
                Id = project.Id,
                Name = project.Name,
                Assigned = assigned
            };

            return parseProject;
        }

    }
}

