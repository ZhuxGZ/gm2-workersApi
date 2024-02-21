using System;
namespace workersApi.Models
{
	public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public List<Employee> members { get; set; }
		public int memberCount { get; set; }
	}
}

