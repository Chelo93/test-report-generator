namespace TestReportGenerator.Interfaces;

using System.Collections.Generic;
using TestReportGenerator.Models;

public interface IPriorityAnalyzer
{
    IEnumerable<PriorityAnalysisResult> AnalyzeByPriority(IEnumerable<TestResult> results);
}

public class PriorityAnalysisResult
{
    public string? Priority { get; set; }
    public int Total { get; set; }
    public int Passed { get; set; }
}