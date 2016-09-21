namespace ReportGenerator.Common
{
    public interface IEmployee
    {
        string Name { get; }
        uint Salary { get; }
        uint Age { get; } // Added for exercise 2
    }
}