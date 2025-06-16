namespace TestReportGenerator.Services;

using TestReportGenerator.Interfaces;
using TestReportGenerator.Models;

public class BasicTestAnalyzer : ITestAnalyzer
{
    public virtual TestAnalysisResult Analyze(IEnumerable<TestResult> results)
    {
        var resultList = results.ToList();
        int totalTests = resultList.Count;
        int passedTests = resultList.Count(r => r.Status == "PASSED");
        int failedTests = resultList.Count(r => r.Status == "FAILED");
        double totalDuration = resultList.Sum(r => r.Duration);
        double passRate = totalTests > 0 ? (double)passedTests / totalTests * 100 : 0;

        return new TestAnalysisResult
        {
            TotalTests = totalTests,
            PassedTests = passedTests,
            FailedTests = failedTests,
            TotalDuration = totalDuration,
            PassRate = passRate
        };
    }
}