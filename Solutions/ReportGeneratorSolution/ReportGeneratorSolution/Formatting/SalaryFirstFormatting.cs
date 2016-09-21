using ReportGenerator.Common;

namespace ReportGenerator.Formatting
{
    public class SalaryFirstFormatting : ReportFormatting
    {
        public SalaryFirstFormatting()
            : base("Salary-first report")
        {
        }


        protected override string PrintEmployeeInfo(IEmployee employee)
        {
            var target = $"Salary: {employee.Salary}\n";
            target += $"Name: {employee.Name}\n";
            target += $"Age: {employee.Age}\n";
            return target;
        }
    }
}