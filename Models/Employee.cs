using System;
namespace workersApi.Models
{
	public class Employee
	{
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Area { get; set; } = String.Empty;
        public string Seniority { get; set; } = String.Empty;
        public int Wage { get; set; }
        public string Address { get; set; } = String.Empty;
        public int ZipCode { get; set; }
        public string? Project { get; set; } = String.Empty;
        public DateTime Joined { get; set; }
    }

    public class AddEmployee
    {
        public string Name { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Area { get; set; } = String.Empty;
        public string Seniority { get; set; } = String.Empty;
        public int Wage { get; set; }
        public string Address { get; set; } = String.Empty;
        public int ZipCode { get; set; }
        public string? Project { get; set; } = String.Empty;
    }
}
