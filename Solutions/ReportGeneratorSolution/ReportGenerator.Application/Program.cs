using System;
using static System.Console;
using ReportGenerator.Common;
using ReportGenerator.Compilation;
using ReportGenerator.Database;
using ReportGenerator.Formatting;
using ReportGenerator.Rendition;

namespace ReportGenerator.Application
{
    class Program
    {
        static void Main()
        {
            // Initialize the database
            var db = new EmployeeDB();
            db.AddEmployee(new Employee("Iceman", 1000, 25));
            db.AddEmployee(new Employee("Goose", 2000, 30));
            db.AddEmployee(new Employee("Maverick", 3000, 35));
            db.AddEmployee(new Employee("Charlie", 1500, 22));

            // Initialize report generation
            var generation = new ReportGeneration(
                new NameFirstFormatting(),
                new DatabaseEmployeeStorage(db),
                new ConsoleRendition());

            var exitProgram = false;

            while (!exitProgram)
            {
                WriteLine("Select report output format ('q' to quit):");
                WriteLine(" [N]ame-first");
                WriteLine(" [S]alary-first");
                WriteLine(" [A]ge-first");

                switch (char.ToUpper(ReadKey(true).KeyChar))
                {
                    case 'N':
                        generation.SetOutputFormat(new NameFirstFormatting());
                        generation.CompileReport();
                        break;

                    case 'S':
                        generation.SetOutputFormat(new SalaryFirstFormatting());
                        generation.CompileReport();
                        break;

                    case 'A':
                        generation.SetOutputFormat(new AgeFirstFormatting());
                        generation.CompileReport();
                        break;
                    case 'Q':
                        exitProgram = true;
                        break;
                }
                WriteLine();
                WriteLine();
                WriteLine();
            }
        }
    }
}