using System;
using ReportGenerator.Compilation;
using ReportGenerator.Formatting;
using ReportGenerator.Rendition;

namespace ReportGenerator.Common
{
    public class ReportGeneration
    {
        private readonly IEmployeeListCompilation _employeeListCompilation;
        private IRendition _rendition;
        private IReportFormatting _reportFormatting;

        public ReportGeneration(IReportFormatting reportFormatting, IEmployeeListCompilation employeeListCompilation,
                                IRendition rendition)
        {
            _reportFormatting = reportFormatting;
            _employeeListCompilation = employeeListCompilation;
            _rendition = rendition;
        }

        public void CompileReport()
        {
            var employeeList = _employeeListCompilation.CompileEmployeeList();
            var report = _reportFormatting.FormatReport(employeeList);
            _rendition.Render(report);
        }

        public void SetOutputFormat(IReportFormatting reportFormatting)
        {
            if (reportFormatting == null) throw new ArgumentNullException("reportFormatting");
            _reportFormatting = reportFormatting;
        }

        public void SetRenderer(IRendition rendition)
        {
            if (rendition == null) throw new ArgumentNullException("rendition");
            _rendition = rendition;
        }
    }
}