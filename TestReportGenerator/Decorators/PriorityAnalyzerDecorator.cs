namespace TestReportGenerator.Decorators;

using TestReportGenerator.Interfaces;
using TestReportGenerator.Models;

public class PriorityReportDecorator : IReportGenerator
{
    private readonly IReportGenerator _inner;
    private readonly IPriorityAnalyzer _priorityAnalyzer;

    public PriorityReportDecorator(IReportGenerator inner, IPriorityAnalyzer priorityAnalyzer)
    {
        _inner = inner;
        _priorityAnalyzer = priorityAnalyzer;
    }

    public void GenerateReport(List<TestResult> results, string sourceType)
    {
        _inner.GenerateReport(results, sourceType);

        var priorityResults = _priorityAnalyzer.AnalyzeByPriority(results);
        Console.WriteLine("\nBy Priority:");
        foreach (var pri in priorityResults)
        {
            Console.WriteLine($"- {pri.Priority}: {pri.Passed}/{pri.Total} tests passed");
        }
    }

}