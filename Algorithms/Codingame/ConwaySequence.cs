// https://www.codingame.com/training/medium/conway-sequence

using System.Collections.Generic;

public class ConwaySequence
{

    public List<int> GetNthLine(int number, int n)
    {
        List<int> previousLine = new List<int> { number };
        List<int> currentLine = new List<int>() { number };

        int lastValue;
        int lastQuantity;
        while (n-->1)
        {
            currentLine = new List<int>();

            lastValue = previousLine[0];
            lastQuantity = 0;
            foreach (var value in previousLine)
            {
                if (value == lastValue) lastQuantity++;
                else
                {
                    currentLine.Add(lastQuantity);
                    currentLine.Add(lastValue);
                    lastValue = value;
                    lastQuantity = 1;
                }
            }
            currentLine.Add(lastQuantity);
            currentLine.Add(lastValue);

            previousLine = currentLine;
        }

        return currentLine;
    }

}
