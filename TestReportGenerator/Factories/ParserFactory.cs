namespace TestReportGenerator.Factories;

using TestReportGenerator.Interfaces;
using TestReportGenerator.Models;
public class ParserFactory : IParserFactory
{
    private readonly IDictionary<string, IParser> _parsers;

    public ParserFactory(IEnumerable<IParser> parsers)
    {
        _parsers = parsers.ToDictionary(
            p => p.GetType().Name.Replace("Parser", "").ToLower(), // e.g., "csv", "json", "xml"
            p => p);
    }

    public IParser GetParser(string fileExtension)
    {
        var key = fileExtension.TrimStart('.').ToLower();
        if (_parsers.TryGetValue(key, out var parser))
            return parser;
        throw new NotSupportedException($"Unsupported file format: {fileExtension}");
    }
}


