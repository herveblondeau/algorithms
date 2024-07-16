using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Easy.MimeType;

[TestClass]
public class MimeTypeTests
{

    [TestMethod]
    [DynamicData(nameof(GetClosestPermutation_Miscellaneous_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void GetClosestPermutation_Miscellaneous_PerformsCorrectly(Dictionary<string, string> descriptions, List<string> filenames, List<string> expected)
    {
        // Arrange
        MimeType MimeType = new();

        // Act
        var actual = MimeType.GetMimeTypes(descriptions, filenames);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> GetClosestPermutation_Miscellaneous_PerformsCorrectly_Data()
    {
        // Codingame's Simple example
        yield return new object[]
        {
            new Dictionary<string, string>()
            {
                { "html", "text/html" },
                { "png", "image/png" },
                { "gif", "image/gif" },
            },
            new List<string>()
            {
                "animated.gif",
                "portrait.png",
                "index.html",
            },
            new List<string>()
            {
                "image/gif",
                "image/png",
                "text/html",
            }
        };

        // Codingame's Unknown MIME types
        yield return new object[]
        {
            new Dictionary<string, string>()
            {
                { "txt", "text/plain" },
                { "xml", "text/xml" },
                { "flv", "video/x-flv" },
            },
            new List<string>()
            {
                "image.png",
                "animated.gif",
                "script.js",
            },
            new List<string>()
            {
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
            }
        };

        // Codingame's Correct division of the extension
        yield return new object[]
        {
            new Dictionary<string, string>()
            {
                { "wav", "audio/x-wav" },
                { "mp3", "audio/mpeg" },
                { "pdf", "application/pdf" },
            },
            new List<string>()
            {
                "a",
                "a.wav",
                "b.wav.tmp",
                "test.vmp3",
                "pdf",
                ".pdf",
                "mp3",
                "report..pdf",
                "defaultwav",
                ".mp3.",
                "final.",
            },
            new List<string>()
            {
                "UNKNOWN",
                "audio/x-wav",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "application/pdf",
                "UNKNOWN",
                "application/pdf",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
            }
        };

        // Codingame's Consideration of the case (upper or lower)
        yield return new object[]
        {
            new Dictionary<string, string>()
            {
                { "png", "image/png" },
                { "tiff", "image/tiff" },
                { "css", "text/css" },
                { "txt", "text/plain" },
            },
            new List<string>()
            {
                "example.TXT",
                "referecnce.txt",
                "strangename.tiff",
                "resolv.CSS",
                "matrix.TiFF",
                "lanDsCape.Png",
                "extract.cSs",
            },
            new List<string>()
            {
                "text/plain",
                "text/plain",
                "image/tiff",
                "text/css",
                "image/tiff",
                "image/png",
                "text/css",
            }
        };
    }
}
