using ReportGenerator.Common;

namespace ReportGenerator.Formatting
{
    public class AgeFirstFormatting : ReportFormatting
    {
        public AgeFirstFormatting()
            : base("Age-first report")
        {
        }


        protected override string PrintEmployeeInfo(IEmployee employee)
        {
            string target = $"Age: {employee.Age}\n";
            target += $"Name: {employee.Name}\n";
            target += $"Salary: {employee.Salary}\n";
            return target;
        }
    }
}