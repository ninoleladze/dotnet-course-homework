using DataReceiving;
using LogerExtensionDelegate;
using Microsoft.Extensions.Logging;

namespace TextFileReceiver;

/// <summary>
/// The data receiver from text file.
/// </summary>
public class TextStreamReceiver : IDataReceiver
{
    private readonly string path;
    private readonly ILogger<TextStreamReceiver>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextStreamReceiver"/> class.
    /// </summary>
    /// <param name="path">The path to text file.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
    public TextStreamReceiver(string? path, ILogger<TextStreamReceiver>? logger = default)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("The path must not be null or empty.", nameof(path));
        }

        this.path = path;
        this.logger = logger;
    }

    /// <summary>
    /// Receives lines from text reader.
    /// </summary>
    /// <returns>Strings.</returns>
    public IEnumerable<string> Receive()
    {
        LogerExtension.FastLoggerMessage(this.logger, $"Reading data from file: {this.path}", new LogerExtensionException($"Reading data from file: {this.path}"));

        using var reader = new StreamReader(this.path);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}
