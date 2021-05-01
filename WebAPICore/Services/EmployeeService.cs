using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class EmployeeService : IEmployeeService
    {
        APICoreDBContext dbContext;
        public EmployeeService(APICoreDBContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            var employee = dbContext.Employees.ToList();
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return employee;
            }
            return null;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            dbContext.Entry(employee).State = EntityState.Modified;
            dbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(employee).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }
    }
}
