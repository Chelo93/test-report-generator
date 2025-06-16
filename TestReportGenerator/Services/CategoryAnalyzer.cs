namespace TestReportGenerator.Services;
using TestReportGenerator.Interfaces;
using TestReportGenerator.Models;

public class CategoryAnalyzer : ICategoryAnalyzer
{
    public IEnumerable<CategoryAnalysisResult> AnalyzeByCategory(IEnumerable<TestResult> results)
    {
        return results
            .GroupBy(r => r.Category)
            .Select(g =>
            {
                int total = g.Count();
                int passed = g.Count(r => r.Status == "PASSED");
                double passRate = total > 0 ? (double)passed / total * 100 : 0;
                return new CategoryAnalysisResult
                {
                    Category = g.Key,
                    Total = total,
                    Passed = passed,
                    PassRate = passRate
                };
            });
    }
}