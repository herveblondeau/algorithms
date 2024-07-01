// https://www.codingame.com/training/easy/asteroids

using System;
using System.Collections.Generic;

namespace Codingame.Easy.Asteroids
{
    public class Asteroids
    {
        public char[][] GetState3(int t1, char[][] state1, int t2, char[][] state2, int t3)
        {
            Dictionary<char, Coordinates> asteroidCoordinates = new();
            int height = state1.Length;
            int width = state1[0].Length;

            // List the asteroids and their initial position
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var location = state1[y][x];

                    if (location == '.')
                    {
                        continue;
                    }

                    asteroidCoordinates[location] = new(x, y);
                }
            }

            // Determine the state 2 position and speed of each asteroid
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var location = state2[y][x];

                    if (location == '.')
                    {
                        continue;
                    }

                    var xSpeed = (double)(x - asteroidCoordinates[location].X) / (t2 - t1);
                    var ySpeed = (double)(y - asteroidCoordinates[location].Y) / (t2 - t1);

                    asteroidCoordinates[location].X = (int)Math.Floor(x + xSpeed * (t3 - t2));
                    asteroidCoordinates[location].Y = (int)Math.Floor(y + ySpeed * (t3 - t2));
                }
            }

            //
            char[][] state3 = new char[height][];
            for (var y = 0; y < height; y++)
            {
                state3[y] = new char[width];
                for (var x = 0; x < width; x++)
                {
                    state3[y][x] = '.';
                }
            }

            //
            foreach (var asteroid in asteroidCoordinates.Keys)
            {
                var x = asteroidCoordinates[asteroid].X;
                var y = asteroidCoordinates[asteroid].Y;
                if (x >= 0 && x < width
                    && y >= 0 && y < height
                    && (state3[y][x] == '.' || asteroid < state3[y][x]))
                {
                    state3[y][x] = asteroid;
                }
            }

            return state3;
        }

        private class Coordinates(int x, int y)
        {
            public int X = x;
            public int Y = y;
        }
    }
}
