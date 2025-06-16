namespace TestReportGenerator.Services;

using TestReportGenerator.Models;
using TestReportGenerator.Interfaces;
using TestReportGenerator.Decorators;

using System;
using System.Collections.Generic;
using System.Linq;

public class ReportGenerator : IReportGenerator
{
  public void GenerateReport(List<TestResult> results, string sourceType)
  {
    Console.WriteLine($"""

    ==========================================
             TEST EXECUTION REPORT
             Source: {sourceType}
    ==========================================

    """);

    ITestAnalyzer analyzer = new BasicTestAnalyzer();
    var analysis = analyzer.Analyze(results);
    
    Console.WriteLine($"""
    Total Tests: {analysis.TotalTests}
    ✅Passed: {analysis.PassedTests} ({analysis.PassRate:F2}%)
    ❌Failed: {analysis.FailedTests} ({100 - analysis.PassRate:F2}%)
    Total Duration: {analysis.TotalDuration:F2} seconds
    """);

    Console.WriteLine("\nBy Category:");
    ICategoryAnalyzer categoryAnalyzer = new CategoryAnalyzer();
    var categoryResults = categoryAnalyzer.AnalyzeByCategory(results);
    foreach (var cat in categoryResults)
    {
        Console.WriteLine($"- {cat.Category}: {cat.Passed}/{cat.Total} passed ({cat.PassRate:F2}%)");
    }

    IReportGenerator reportGenerator = new ReportGenerator();
    reportGenerator = new PriorityReportDecorator(reportGenerator, new PriorityAnalyzer());

    reportGenerator.GenerateReport(results, sourceType);

    Console.WriteLine("==========================================\n");
  }
}

