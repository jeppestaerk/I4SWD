using ReportGenerator.Common;

namespace ReportGenerator.Database
{
    public interface IEmployeeDB
    {
        void Reset();
        IEmployee GetNextEmployee();
    }
}