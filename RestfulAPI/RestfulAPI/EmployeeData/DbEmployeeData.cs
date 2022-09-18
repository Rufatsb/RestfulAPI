using Microsoft.EntityFrameworkCore;
using RestfulAPI.DAL;
using RestfulAPI.Models;

namespace RestfulAPI.EmployeeData
{
    public class DbEmployeeData : IEmployeeData

    {
        private AppDbContext _context;
        public DbEmployeeData(AppDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
           _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
           
                _context.Employees.Remove(employee);
            _context.SaveChanges();
                

            

        }

        public  Employee EditEmployee(Employee employee)
        {
            Employee dbemployee = _context.Employees.Find(employee.Id);
            if (dbemployee != null)
            {
                dbemployee.Name = employee.Name;
                _context.Employees.Update(dbemployee);
                _context.SaveChanges();
               
            }
            return dbemployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return _context.Employees.Find(id);
        }

        public List<Employee> GetEmployees()
        {
         return  _context.Employees.ToList();
        }
    }
}
