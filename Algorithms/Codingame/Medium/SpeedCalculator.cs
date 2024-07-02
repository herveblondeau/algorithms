// This was a sponsored puzzle, it is not available anymore
// Original description:
// You enter a section of road and you plan to rest entirely on your cruise control to cross the area without having to stop or slow down.
// The goal is to find the maximum speed (off speeding) that will allow you to cross all the traffic lights to green.
// Warning: You can not cross a traffic light the second it turns red !
// Your vehicle enters the zone directly at the speed programmed on the cruise control which ensures that it does not change anymore.
// Input
// Line 1: An integer speed for the maximum speed allowed on the portion of the road (in km / h).
// Line 2: An integer lightCount for the number of traffic lights on the road.

// lightCount next lines:
// - An integer distance representing the distance of the traffic light from the starting point (in meters).
// - An integer duration representing the duration of the traffic light on each color.

// A traffic light alternates a period of duration seconds in green and then duration seconds in red.
// All traffic lights turn green at the same time as you enter the area.
// Output
// Line 1: The integer speed (km / h) as high as possible that cross all the green lights without committing speeding.
// Constraints
// 1 ≤ speed ≤ 200
// 1 ≤ lightCount ≤ 9999
// 1 ≤ distance ≤ 99999
// 1 ≤ duration ≤ 9999

using System;

namespace Codingame.Medium.SpeedCalculator;

public class SpeedCalculator
{
    public int FindMaxPossibleSpeed(int speedLimit, TrafficLight[] trafficLights)
    {
        int maxSpeed = 0;
        for (int currentSpeed = speedLimit; currentSpeed >= 0; currentSpeed--)
        {
            bool crossesAllLights = true;
            for (int j = 0; j < trafficLights.Length; j++)
            {
                if (!_canCross(currentSpeed, trafficLights[j]))
                {
                    crossesAllLights = false;
                    break;
                }
            }

            if (crossesAllLights)
            {
                maxSpeed = currentSpeed;
                break;
            }
        }

        return maxSpeed;
    }

    private bool _canCross(int speed, TrafficLight trafficLight)
    {
        double timeToTrafficLight = trafficLight.Distance * 3.6 / speed; // 3.6 for km/h to m/s conversion
        double phase = timeToTrafficLight / trafficLight.Duration;
        return Math.Floor(phase) % 2 == 0;
    }
}

public class TrafficLight
{
    public int Distance { get; set; }
    public int Duration { get; set; }
}