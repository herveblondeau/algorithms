// https://www.codingame.com/training/hard/simple-safecracking

using System.Linq;

namespace Codingame.SimpleSafecracking
{
    public class SimpleSafecracking
    {
        public long Decode(string encoded)
        {
            // The message is encoded with a Cesar code that uses a different shift for each message
            // However, the sentence before the colon is always "The safe combination is".
            // So, by reading the first character, we can deduce the shift
            encoded = encoded.ToLower();
            char first = encoded[0];
            int shift = ('t' - first + 26) % 26;

            // Keep only the message part
            encoded = encoded.Substring(25);

            return _decode(encoded, shift);
        }

        private long _decode(string encoded, int shift)
        {
            var decoded = string.Join("", encoded
                .Select(d => d != '-' ? (d - 96 + shift) % 26 + 96 : d)
                .Select(d => (char)d)
                .ToArray()
            );

            var bla = decoded.Split('-').Select(d => _toDigit(d));
            var bli = string.Join("", bla);

            return long.Parse(string.Join("", decoded.Split('-').Select(d => _toDigit(d))));
        }

        private int _toDigit(string digitStr)
        {
            switch (digitStr)
            {
                case "one":
                    return 1;

                case "two":
                    return 2;

                case "three":
                    return 3;

                case "four":
                    return 4;

                case "five":
                    return 5;

                case "six":
                    return 6;

                case "seven":
                    return 7;

                case "eight":
                    return 8;

                case "nine":
                    return 9;

                case "zero":
                default:
                    return 0;

            }

        }
    }
}
