using Codingame.Medium.SpeedCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.Medium.SpeedCalculator
{
    [TestClass]
    public class SpeedCalculatorTests
    {

        [TestMethod]
        [DataRow(50, 200, 15, 50)]
        [DataRow(50, 200, 10, 36)]
        public void FindMaxPossibleSpeed_OneTrafficLight_PerformsCorrectly(int speedLimit, int trafficLightDistance, int trafficLightDuration, int expected)
        {
            // Arrange
            SpeedCalculator speedCalculator = new();

            // Act
            var actual = speedCalculator.FindMaxPossibleSpeed(speedLimit, new TrafficLight[]
            {
                new() {
                    Distance = trafficLightDistance,
                    Duration = trafficLightDuration,
                },
            });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxPossibleSpeed_RainOfTrafficLights_PerformsCorrectly()
        {
            // Arrange
            SpeedCalculator speedCalculator = new();

            // Act
            var actual = speedCalculator.FindMaxPossibleSpeed(130, new TrafficLight[]
            {
                new() { Distance = 500, Duration = 15 },
                new() { Distance = 1000, Duration = 15 },
                new() { Distance = 1500, Duration = 15 },
                new() { Distance = 2000, Duration = 15 },
                new() { Distance = 2500, Duration = 15 },
                new() { Distance = 3000, Duration = 15 },
                new() { Distance = 3500, Duration = 15 },
                new() { Distance = 4000, Duration = 15 },
                new() { Distance = 4500, Duration = 15 },
                new() { Distance = 5000, Duration = 15 },
                new() { Distance = 5500, Duration = 15 },
                new() { Distance = 6000, Duration = 15 },
                new() { Distance = 6500, Duration = 15 },
                new() { Distance = 7000, Duration = 15 },
                new() { Distance = 7500, Duration = 15 },
                new() { Distance = 8000, Duration = 15 },
                new() { Distance = 8500, Duration = 15 },
                new() { Distance = 9000, Duration = 15 },
                new() { Distance = 9500, Duration = 15 },
                new() { Distance = 10000, Duration = 15 },
                new() { Distance = 10500, Duration = 15 },
                new() { Distance = 11000, Duration = 15 },
                new() { Distance = 11500, Duration = 15 },
                new() { Distance = 12000, Duration = 15 },
                new() { Distance = 12500, Duration = 15 },
                new() { Distance = 13000, Duration = 15 },
                new() { Distance = 13500, Duration = 15 },
                new() { Distance = 14000, Duration = 15 },
                new() { Distance = 14500, Duration = 15 },
                new() { Distance = 15000, Duration = 15 },
                new() { Distance = 15500, Duration = 15 },
                new() { Distance = 16000, Duration = 15 },
                new() { Distance = 16500, Duration = 15 },
                new() { Distance = 17000, Duration = 15 },
                new() { Distance = 17500, Duration = 15 },
                new() { Distance = 18000, Duration = 15 },
                new() { Distance = 18500, Duration = 15 },
                new() { Distance = 19000, Duration = 15 },
                new() { Distance = 19500, Duration = 15 },
                new() { Distance = 20000, Duration = 15 },
                new() { Distance = 20500, Duration = 15 },
                new() { Distance = 21000, Duration = 15 },
                new() { Distance = 21500, Duration = 15 },
                new() { Distance = 22000, Duration = 15 },
                new() { Distance = 22500, Duration = 15 },
                new() { Distance = 23000, Duration = 15 },
                new() { Distance = 23500, Duration = 15 },
                new() { Distance = 24000, Duration = 15 },
                new() { Distance = 24500, Duration = 15 },
                new() { Distance = 25000, Duration = 15 },
                new() { Distance = 25500, Duration = 15 },
                new() { Distance = 26000, Duration = 15 },
                new() { Distance = 26500, Duration = 15 },
                new() { Distance = 27000, Duration = 15 },
                new() { Distance = 27500, Duration = 15 },
                new() { Distance = 28000, Duration = 15 },
                new() { Distance = 28500, Duration = 15 },
                new() { Distance = 29000, Duration = 15 },
                new() { Distance = 29500, Duration = 15 },
                new() { Distance = 30000, Duration = 15 },
                new() { Distance = 30500, Duration = 15 },
                new() { Distance = 31000, Duration = 15 },
                new() { Distance = 31500, Duration = 15 },
                new() { Distance = 32000, Duration = 15 },
                new() { Distance = 32500, Duration = 15 },
                new() { Distance = 33000, Duration = 15 },
                new() { Distance = 33500, Duration = 15 },
                new() { Distance = 34000, Duration = 15 },
                new() { Distance = 34500, Duration = 15 },
                new() { Distance = 35000, Duration = 15 },
                new() { Distance = 35500, Duration = 15 },
                new() { Distance = 36000, Duration = 15 },
                new() { Distance = 36500, Duration = 15 },
                new() { Distance = 37000, Duration = 15 },
                new() { Distance = 37500, Duration = 15 },
                new() { Distance = 38000, Duration = 15 },
                new() { Distance = 38500, Duration = 15 },
                new() { Distance = 39000, Duration = 15 },
                new() { Distance = 39500, Duration = 15 },
                new() { Distance = 40000, Duration = 15 },
                new() { Distance = 40500, Duration = 15 },
                new() { Distance = 41000, Duration = 15 },
                new() { Distance = 41500, Duration = 15 },
                new() { Distance = 42000, Duration = 15 },
                new() { Distance = 42500, Duration = 15 },
                new() { Distance = 43000, Duration = 15 },
                new() { Distance = 43500, Duration = 15 },
                new() { Distance = 44000, Duration = 15 },
                new() { Distance = 44500, Duration = 15 },
                new() { Distance = 45000, Duration = 15 },
                new() { Distance = 45500, Duration = 15 },
                new() { Distance = 46000, Duration = 15 },
                new() { Distance = 46500, Duration = 15 },
                new() { Distance = 47000, Duration = 15 },
                new() { Distance = 47500, Duration = 15 },
                new() { Distance = 48000, Duration = 15 },
                new() { Distance = 48500, Duration = 15 },
                new() { Distance = 49000, Duration = 15 },
                new() { Distance = 49500, Duration = 15 },
                new() { Distance = 50000, Duration = 15 },
            });

            // Assert
            Assert.AreEqual(60, actual);
        }
    }
}
