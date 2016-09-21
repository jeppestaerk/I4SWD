using System.Collections.Generic;
using ReportGenerator.Common;

namespace ReportGenerator.Database
{
    public class EmployeeDB : IEmployeeDB
    {
        private readonly List<IEmployee> _employees;
        private int _currentEmployeeIndex;

        public EmployeeDB()
        {
            _employees = new List<IEmployee>();
            Reset();
        }

        public void Reset()
        {
            _currentEmployeeIndex = 0;
        }

        public IEmployee GetNextEmployee()
        {
            return _currentEmployeeIndex == _employees.Count ? null : _employees[_currentEmployeeIndex++];
        }

        public void AddEmployee(IEmployee employee)
        {
            _employees.Add(employee);
        }
    }
}