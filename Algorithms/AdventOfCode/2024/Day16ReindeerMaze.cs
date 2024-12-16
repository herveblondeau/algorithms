// https://adventofcode.com/2024/day/16

using System;

namespace Algorithms.AdventOfCode._2024;

public class Day16ReindeerMaze
{

    #region Part 1

    public int CalculateLowestScore(string[] maze)
    {
        int[][] scores = new int[maze.Length][];

        (int Row, int Columm) entrance = default!;
        (int Row, int Columm) exit = default!;
        for (int row = 0; row < maze.Length; row++)
        {
            scores[row] = new int[maze[0].Length];

            for (int column = 0; column < maze.Length; column++)
            {
                scores[row][column] = int.MaxValue;

                if (maze[row][column] == 'S')
                {
                    entrance = (row, column);
                }
                else if (maze[row][column] == 'E')
                {
                    exit = (row, column);
                }
            }
        }

        scores[entrance.Row][entrance.Columm] = 0;
        var position = (entrance.Row, entrance.Columm, '>');
        if (_canMoveForward(maze, position))
        {
            _computeScores(maze, _moveForward(position), 1, scores);
        }
        if (_canTurnLeft(maze, position))
        {
            _computeScores(maze, _turnLeft(position), 1001, scores);
        }
        if (_canTurnRight(maze, position))
        {
            _computeScores(maze, _turnRight(position), 1001, scores);
        }

        return scores[exit.Row][exit.Columm];
    }

    private void _computeScores(
        string[] maze,
        (int Row, int Column, char Orientation) position,
        int currentScore,
        int[][] scores)
    {
        if (currentScore >= scores[position.Row][position.Column])
        {
            return;
        }

        scores[position.Row][position.Column] = currentScore;

        if (_canMoveForward(maze, position))
        {
            _computeScores(maze, _moveForward(position), currentScore + 1, scores);
        }
        if (_canTurnLeft(maze, position))
        {
            _computeScores(maze, _turnLeft(position), currentScore + 1001, scores);
        }
        if (_canTurnRight(maze, position))
        {
            _computeScores(maze, _turnRight(position), currentScore + 1001, scores);
        }
    }

    private bool _canTurnLeft(string[] maze, (int Row, int Column, char Orientation) position)
    {
        return position.Orientation switch
        {
            '^' => position.Column > 0 && maze[position.Row][position.Column - 1] != '#',
            'v' => position.Column < maze[0].Length - 1 && maze[position.Row][position.Column + 1] != '#',
            '<' => position.Row < maze.Length - 1 && maze[position.Row + 1][position.Column] != '#',
            '>' => position.Row > 0 && maze[position.Row - 1][position.Column] != '#',
            _ => throw new Exception("invalid orientation")
        };
    }

    private (int Row, int Column, char Orientation) _turnLeft((int Row, int Column, char Orientation) position)
    {
        return position.Orientation switch
        {
            '^' => (position.Row, position.Column - 1, '<'),
            'v' => (position.Row, position.Column + 1, '>'),
            '<' => (position.Row + 1, position.Column, 'v'),
            '>' => (position.Row - 1, position.Column, '^'),
            _ => throw new Exception("invalid orientation")
        };
    }

    private bool _canTurnRight(string[] maze, (int Row, int Column, char Orientation) position)
    {
        return position.Orientation switch
        {
            '^' => position.Column < maze[0].Length - 1 && maze[position.Row][position.Column + 1] != '#',
            'v' => position.Column > 0 && maze[position.Row][position.Column - 1] != '#',
            '<' => position.Row > 0 && maze[position.Row - 1][position.Column] != '#',
            '>' => position.Row < maze.Length - 1 && maze[position.Row + 1][position.Column] != '#',
            _ => throw new Exception("invalid orientation")
        };
    }

    private (int Row, int Column, char Orientation) _turnRight((int Row, int Column, char Orientation) position)
    {
        return position.Orientation switch
        {
            '^' => (position.Row, position.Column + 1, '>'),
            'v' => (position.Row, position.Column - 1, '<'),
            '<' => (position.Row - 1, position.Column, '^'),
            '>' => (position.Row + 1, position.Column, 'v'),
            _ => throw new Exception("invalid orientation")
        };
    }

    private bool _canMoveForward(string[] maze, (int Row, int Column, char Orientation) position)
    {
        return position.Orientation switch
        {
            '^' => position.Row > 0 && maze[position.Row - 1][position.Column] != '#',
            'v' => position.Row < maze.Length - 1 && maze[position.Row + 1][position.Column] != '#',
            '<' => position.Column > 0 && maze[position.Row][position.Column - 1] != '#',
            '>' => position.Column < maze[0].Length - 1 && maze[position.Row][position.Column + 1] != '#',
            _ => throw new Exception("invalid orientation")
        };
    }

    private (int Row, int Column, char Orientation) _moveForward((int Row, int Column, char Orientation) position)
    {
        return position.Orientation switch
        {
            '^' => (position.Row - 1, position.Column, position.Orientation),
            'v' => (position.Row + 1, position.Column, position.Orientation),
            '<' => (position.Row, position.Column - 1, position.Orientation),
            '>' => (position.Row, position.Column + 1, position.Orientation),
            _ => throw new Exception("invalid orientation")
        };
    }

    #endregion
}
