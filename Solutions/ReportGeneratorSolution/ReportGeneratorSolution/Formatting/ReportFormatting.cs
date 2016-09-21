using System.Collections.Generic;
using ReportGenerator.Common;

namespace ReportGenerator.Formatting
{
    public abstract class ReportFormatting : IReportFormatting
    {
        private readonly string _reportHeader;

        protected ReportFormatting(string reportHeader)
        {
            _reportHeader = reportHeader;
        }

        public string FormatReport(List<IEmployee> employeeList)
        {
            var retVal = _reportHeader + "\n";
            var employeeIndex = 0;

            foreach (var e in employeeList)
            {
                retVal += "*********************\n";
                retVal += $"EMPLOYEE {employeeIndex++}\n";
                retVal += "---------------------\n";
                retVal += PrintEmployeeInfo(e);
                retVal += "*********************\n";
                retVal += "\n\n";
            }

            return retVal;
        }

        protected abstract string PrintEmployeeInfo(IEmployee employee);
    }
}