namespace TestReportGenerator.Services;

using TestReportGenerator.Interfaces;
using TestReportGenerator.Models;

public class PriorityAnalyzer : IPriorityAnalyzer
{
    public IEnumerable<PriorityAnalysisResult> AnalyzeByPriority(IEnumerable<TestResult> results)
    {
        return results
            .GroupBy(r => r.Priority)
            .Select(g => new PriorityAnalysisResult
            {
                Priority = g.Key,
                Total = g.Count(),
                Passed = g.Count(r => r.Status == "PASSED")
            });
    }
}