namespace TestReportGenerator.Interfaces;

using TestReportGenerator.Models;

public interface ITestAnalyzer
{
    TestAnalysisResult Analyze(IEnumerable<TestResult> results);
}

public class TestAnalysisResult
{
    public int TotalTests { get; set; }
    public int PassedTests { get; set; }
    public int FailedTests { get; set; }
    public double TotalDuration { get; set; }
    public double PassRate { get; set; }
}