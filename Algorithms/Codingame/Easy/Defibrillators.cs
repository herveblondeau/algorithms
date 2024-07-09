// https://www.codingame.com/training/easy/defibrillators

using System;

namespace Codingame.Easy.Defibrillators;

public class Defibrillators
{
    public string GetClosestDefibrillator(double longitude, double latitude, string[] defibrillatorDescriptions)
    {
        string closestDefibrillator = string.Empty;
        double minimumDistance = Double.MaxValue;
        foreach (var defibrillatorDescription in defibrillatorDescriptions)
        {
            // It would be cleaner to create and use a Defibrillator class but considering the limited scope of this exercise, an array will do just fine
            string[] details = defibrillatorDescription.Split(';');

            double x = (_toDouble(details[4]) - longitude) * Math.Cos((_toDouble(details[5]) + latitude) / 2);
            double y = _toDouble(details[5]) - latitude;
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                closestDefibrillator = details[1];
            }
        }

        return closestDefibrillator;
    }

    private double _toDouble(string input)
    {
        return double.Parse(input.Replace(',', '.'));
    }
}
