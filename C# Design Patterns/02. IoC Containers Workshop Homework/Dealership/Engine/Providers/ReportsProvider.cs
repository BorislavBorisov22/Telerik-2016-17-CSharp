using System;
using Dealership.Engine.Providers.Contracts;
using System.Collections.Generic;
using Bytes2you.Validation;
using System.Text;

namespace Dealership.Engine.Providers
{
    public class ReportsProvider : IReportsProvider
    {
        private readonly IList<string> reports;

        public ReportsProvider()
        {
            this.reports = new List<string>();
        }

        public void AddReport(string report)
        {
            Guard.WhenArgument(report, "report").IsNullOrEmpty().Throw();

            this.reports.Add(report);
        }

        public void PrintReports(IInputOutputProvider inputOutputProvider)
        {
            var output = new StringBuilder();

            foreach (var report in this.reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            inputOutputProvider.Write(output.ToString());
        }
    }
}
