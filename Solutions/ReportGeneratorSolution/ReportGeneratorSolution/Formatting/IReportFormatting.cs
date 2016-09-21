using System.Collections.Generic;
using ReportGenerator.Common;

namespace ReportGenerator.Formatting
{
    public interface IReportFormatting
    {
        string FormatReport(List<IEmployee> employeeList);
    }
}