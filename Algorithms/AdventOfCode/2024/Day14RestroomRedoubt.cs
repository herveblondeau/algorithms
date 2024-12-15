using System.Reflection.Metadata;
// https://adventofcode.com/2024/day/14

using System.Collections.Generic;

namespace Algorithms.AdventOfCode._2024;

public class Day14RestroomRedoubt
{

    #region Part 1

    public int CalculateSafetyFactor(List<(int PositionX, int PositionY, int VelocityX, int VelocityY)> robots, int gridWidth, int gridHeight, int nbSeconds)
    {
        int nbRobotsInTopLeftQuadrant = 0;
        int nbRobotsInTopRightQuadrant = 0;
        int nbRobotsInBottomLeftQuadrant = 0;
        int nbRobotsInBottomRightQuadrant = 0;

        foreach (var robot in robots)
        {
            int newPositionX = (robot.PositionX + robot.VelocityX * nbSeconds) % gridWidth;
            int newPositionY = (robot.PositionY + robot.VelocityY * nbSeconds) % gridHeight;
            if (newPositionX < 0)
            {
                newPositionX += gridWidth;
            }
            if (newPositionY < 0)
            {
                newPositionY += gridHeight;
            }

            var midWidth = gridWidth / 2;
            var midHeight = gridHeight / 2;
            if (newPositionX < gridWidth / 2)
            {
                if (newPositionY < gridHeight / 2)
                {
                    nbRobotsInTopLeftQuadrant++;
                }
                else if (newPositionY > gridHeight / 2)
                {
                    nbRobotsInBottomLeftQuadrant++;
                }
            }
            else if (newPositionX > gridWidth / 2)
            {
                if (newPositionY < gridHeight / 2)
                {
                    nbRobotsInTopRightQuadrant++;
                }
                else if (newPositionY > gridHeight / 2)
                {
                    nbRobotsInBottomRightQuadrant++;
                }
            }
        }

        return nbRobotsInTopLeftQuadrant * nbRobotsInTopRightQuadrant * nbRobotsInBottomLeftQuadrant * nbRobotsInBottomRightQuadrant;
    }

    #endregion

    #region Part 2

    public List<(int PositionX, int PositionY, int VelocityX, int VelocityY)> Move(List<(int PositionX, int PositionY, int VelocityX, int VelocityY)> robots, int gridWidth, int gridHeight, int nbSeconds)
    {
        List<(int PositionX, int PositionY, int VelocityX, int VelocityY)> result = new();
        for (int i = 0; i < robots.Count; i++)
        {
            var robot = robots[i];
            int newPositionX = (robot.PositionX + robot.VelocityX * nbSeconds) % gridWidth;
            int newPositionY = (robot.PositionY + robot.VelocityY * nbSeconds) % gridHeight;
            if (newPositionX < 0)
            {
                newPositionX += gridWidth;
            }
            if (newPositionY < 0)
            {
                newPositionY += gridHeight;
            }

            result.Add((newPositionX, newPositionY, robot.VelocityX, robot.VelocityY));
        }

        return result;
    }

    public List<string> GetDisplay(List<(int PositionX, int PositionY, int VelocityX, int VelocityY)> robots, int gridWidth, int gridHeight)
    {
        char[][] map = new char[gridHeight][];
        for (int row = 0; row < gridHeight; row++)
        {
            map[row] = new char[gridWidth];
            for (int column = 0; column < gridWidth; column++)
            {
                map[row][column] = ' ';
            }
        }

        foreach (var robot in robots)
        {
            map[robot.PositionY][robot.PositionX] = 'X';
        }

        List<string> result = new();
        for (int row = 0; row < gridHeight; row++)
        {
            result.Add(string.Join(string.Empty, map[row]));
        }
        return result;
    }

    #endregion
}
