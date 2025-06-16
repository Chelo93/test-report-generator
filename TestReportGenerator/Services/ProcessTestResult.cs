namespace TestReportGenerator.Services;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using TestReportGenerator.Models;
using TestReportGenerator.Interfaces;
public class ProcessTestResultService
{
    private readonly IParserFactory _parserFactory;

    public ProcessTestResultService(IParserFactory parserFactory)
    {
        _parserFactory = parserFactory;
    }

    // TODO: This method is too complex and violates KISS (Keep It Simple, Stupid)
    // It also violates SRP by doing parsing, analysis, and report generation
    // HINT: Inject IParserFactory and use Strategy pattern for different formats
    private void ProcessTestResults(string fileName, string fileType)
    {
        List<TestResult> results = [];

        // TODO: This switch statement violates Open/Closed Principle
        // Adding new file formats requires modifying this method
        // HINT: Use Factory pattern or Abstract Factory pattern with DI
        var parser = _parserFactory.GetParser(fileType);
        // TODO: Direct method call - should use injected service
        // HINT: Inject IReportGenerator
        // If you didn't finished and you reached here it's ok just create a service with the exisiting GenerateReport and use it with DI.
        GenerateReport(results, fileType);
    }
}