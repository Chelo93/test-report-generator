namespace TestReportGenerator.Decorators;

using System;
using TestReportGenerator.Interfaces;
using TestReportGenerator.Models;
public class FailedTestsReportDecorator : IReportGenerator
{
    private readonly IReportGenerator _inner;

    public FailedTestsReportDecorator(IReportGenerator inner)
    {
        _inner = inner;
    }

    public void GenerateReport(List<TestResult> results, string sourceType)
    {
        _inner.GenerateReport(results, sourceType);

        var failedTests = results.FindAll(r => r.Status == "FAILED");
        if (failedTests.Count > 0)
        {
            Console.WriteLine("\nFailed Tests:");
            foreach (var test in failedTests)
            {
                Console.WriteLine($"- {test.TestName} ({test.Duration}s) - {test.Category}");
            }
        }
    }
}