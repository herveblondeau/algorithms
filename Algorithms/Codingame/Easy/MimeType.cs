// https://www.codingame.com/training/easy/mime-type

using System.Collections.Generic;

namespace Codingame.Easy.MimeType;

public class MimeType
{
    public List<string> GetMimeTypes(Dictionary<string, string> descriptions, List<string> filenames)
    {
        List<string> mimeTypes = new();

        int lastDotPosition;
        string extension;
        foreach (var filename in filenames)
        {
            lastDotPosition = filename.LastIndexOf('.'); // the filename may contain several dots, only the last one separates the extension
            if (lastDotPosition != -1)
            {
                extension = filename.Substring(lastDotPosition + 1).ToLower();
                if (descriptions.ContainsKey(extension))
                {
                    mimeTypes.Add(descriptions[extension]);
                    continue;
                }
            }

            mimeTypes.Add("UNKNOWN");
        }

        return mimeTypes;
    }
}
