using System.Collections.Generic;
using ReportGenerator.Common;

namespace ReportGenerator.Compilation
{
    public interface IEmployeeStorage
    {
        List<IEmployee> GetEmployees();
    }
}