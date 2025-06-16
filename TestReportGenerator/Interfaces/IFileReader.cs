namespace TestReportGenerator.Interfaces
{
    /// <summary>
    /// Represents a section in a test report.
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Reads the content of a file and returns it as a string.
        /// </summary>
        /// <param name="filePath">The path to the file to read.</param>
        /// <returns>A string containing the content of the file.</returns>
        string ReadFile(string filePath);
    }
}
