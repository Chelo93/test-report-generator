namespace TestReportGenerator.Interfaces
{
    /// <summary>
    /// Represents a section in a test report.
    /// </summary>
    public interface IReportSection
    {
        /// <summary>
        /// Gets the title of the report section.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the content of the report section.
        /// </summary>
        string Content { get; }
    }
}