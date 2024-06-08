using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManagementSystemDbContext _dbContext;
        public EmployeesController(EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult>EmployeeList()
        {
            List<Employee> employees = await _dbContext.Employees.OrderBy(e => e.Name).ToListAsync();
            return View(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel employeeViewModel)
        {
            Employee newEmployee = new Employee()
            { Id = Guid.NewGuid(),
                Name = employeeViewModel.Name,
                Email=employeeViewModel.Email,
                Salary=employeeViewModel.Salary,
                DateofBirth = employeeViewModel.DateofBirth,
                Departament =employeeViewModel.Departament,
              

            };
            await _dbContext.Employees.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();    
            return RedirectToAction("EmployeeList");

        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(Guid Id)
        {
            Employee employee= await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == Id); 
            if (employee == null)
            {
                return RedirectToAction("EmployeeList");

            }
            UpdateEmployeeViewModel employeeViewModel = new UpdateEmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                DateofBirth = employee.DateofBirth,
                Departament = employee.Departament,


            };
            return View(employeeViewModel);


        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeViewModel employeeViewModel)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeViewModel.Id);

            if (employee != null)
            {
                employee.Name = employeeViewModel.Name;
                employee.Email = employeeViewModel.Email;
                employee.Salary = employeeViewModel.Salary;
                employee.Departament = employeeViewModel.Departament;
                employee.DateofBirth = employeeViewModel.DateofBirth;

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("EmployeeList");
            };
            return RedirectToAction("EmployeeList");

        }

    }
}
