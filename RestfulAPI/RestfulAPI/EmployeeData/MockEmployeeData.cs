using RestfulAPI.Models;

namespace RestfulAPI.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> _employees = new List<Employee> {
            new Employee
            { 
            Id = Guid.NewGuid(),
            Name = "First Man"
            },
              new Employee
            {
            Id = Guid.NewGuid(),
            Name = "Second Man"
            },
            new Employee
            {
            Id = Guid.NewGuid(),
            Name = "Third Man"
            }
        };
       public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            _employees.Add(employee);
            return employee;
        }
        public void DeleteEmployee(Employee employee)
        {
            
            _employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            Employee exemployee = GetEmployee(employee.Id);
            exemployee.Name = employee.Name;
           
            return exemployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
