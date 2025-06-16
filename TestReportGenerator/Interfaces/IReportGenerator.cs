using System.Collections.Generic;
using TestReportGenerator.Models;

namespace TestReportGenerator.Interfaces;
public interface IReportGenerator
{
    void GenerateReport(List<TestResult> results, string sourceType);
}