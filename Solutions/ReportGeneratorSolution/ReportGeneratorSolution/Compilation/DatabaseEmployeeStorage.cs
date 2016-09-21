using System.Collections.Generic;
using ReportGenerator.Common;
using ReportGenerator.Database;

namespace ReportGenerator.Compilation
{
    public class DatabaseEmployeeStorage : IEmployeeStorage
    {
        private readonly IEmployeeDB _employeeDb;

        public DatabaseEmployeeStorage(IEmployeeDB employeeDb)
        {
            _employeeDb = employeeDb;
        }

        public List<IEmployee> GetEmployees()
        {
            var employees = new List<IEmployee>();
            IEmployee employee;

            _employeeDb.Reset();

            // Get all employees
            while ((employee = _employeeDb.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }

            return employees;
        }
    }
}