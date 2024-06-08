namespace EmployeeManagementSystem.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }

        public DateTime DateofBirth { get; set; }
        public string Departament { get; set; }
    }
}
