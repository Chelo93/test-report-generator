namespace TestReportGenerator.Interfaces;

using System.Collections.Generic;
using TestReportGenerator.Models;

public interface ICategoryAnalyzer
{
    IEnumerable<CategoryAnalysisResult> AnalyzeByCategory(IEnumerable<TestResult> results);
}

public class CategoryAnalysisResult
{
    public string? Category { get; set; }
    public int Total { get; set; }
    public int Passed { get; set; }
    public double PassRate { get; set; }
}