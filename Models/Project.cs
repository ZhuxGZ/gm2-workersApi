using System;
using System.Collections.Generic;
namespace workersApi.Models
{
    /*
     Aca tambien, lo mismo que en Employee.cs! Mantengamos la entidad que se refleja en la base de datos dentro de la carpeta
     Models, lo demas hay que identificar si son DTOs! 
    */
	public class DBProject
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public string Assigned { get; set; }
	}

	public class Project
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Assigned> Assigned { get; set; }
    }

    public class NewProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Assigned { get; set; }
    }

	public class Assigned
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

