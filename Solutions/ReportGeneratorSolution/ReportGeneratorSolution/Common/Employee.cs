namespace ReportGenerator.Common
{
    public class Employee : IEmployee
    {
        public Employee() : this("", 0, 0)
        {
        }

        public Employee(string name, uint salary, uint age)
        {
            Name = name;
            Salary = salary;
            Age = age; // Added for exercise 2
        }

        public string Name { get; }
        public uint Salary { get; }
        public uint Age { get; } // Added for exercise 2
    }
}