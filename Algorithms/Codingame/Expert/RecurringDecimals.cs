// https://www.codingame.com/training/expert/recurring-decimals

using System.Collections.Generic;
using System.Text;

namespace Codingame.Expert.RecurringDecimals;

public class RecurringDecimals
{
    public string Invert(int input)
    {
        int quotient;
        int remainder = 1;

        List<int> decimals = new();
        Dictionary<int, int> visitedRemainders = new();
        visitedRemainders.Add(remainder, 0);

        int currentPosition = 1;
        int firstRepeatingDecimalIndex = -1;

        // Perform a long division process
        // We can detect a repetition if at some point we obtain the same remainder a second time
        while (true)
        {
            // Next step of the division
            remainder *= 10;
            quotient = remainder / input;
            decimals.Add(quotient);
            remainder = remainder % input;

            // Division complete
            if (remainder == 0)
            {
                break;
            }

            // Repetition detected
            if (visitedRemainders.ContainsKey(remainder))
            {
                firstRepeatingDecimalIndex = visitedRemainders[remainder];
                break;
            }

            visitedRemainders.Add(remainder, currentPosition);
            currentPosition++;
        }

        // Build the output
        StringBuilder result = new("0.");
        for (int i = 0; i < decimals.Count; i++)
        {
            if (i == firstRepeatingDecimalIndex)
            {
                result.Append("(");
            }
            result.Append(decimals[i]);
        }
        if (firstRepeatingDecimalIndex != -1)
        {
            result.Append(")");
        }

        return result.ToString();
    }
}
