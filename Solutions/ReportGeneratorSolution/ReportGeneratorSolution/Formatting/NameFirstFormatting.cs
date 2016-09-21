using ReportGenerator.Common;

namespace ReportGenerator.Formatting
{
    public class NameFirstFormatting : ReportFormatting
    {
        public NameFirstFormatting()
            : base("Name-first report")
        {
        }

        protected override string PrintEmployeeInfo(IEmployee employee)
        {
            var target = $"Name: {employee.Name}\n";
            target += $"Salary: {employee.Salary}\n";
            target += $"Age: {employee.Age}\n";
            return target;
        }
    }
}