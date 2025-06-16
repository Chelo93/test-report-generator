namespace TestReportGenerator.Interfaces;
using TestReportGenerator.Models;

public interface IParserFactory
{
    IParser GetParser(string fileExtension);
}
public interface IParser
{
    string SupportedExtension { get; }
    IEnumerable<TestResult> Parse(string fileContent);
}