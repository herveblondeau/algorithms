// https://www.codingame.com/training/hard/hanoi-tower

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codingame.HanoiTower
{
    public class HanoiTower
    {
        private Stack<int>[] _stacks;
        private int _nbDisks;
        private int _smallestDiskPosition = 0;

        public int GetNumberOfMovesToSolve(int nbDisks)
        {
            // The number of moves required for n disks is 2^n-1
            // This can easily be demonstrated iteratively:
            // - It is obviously true for n=1
            // - Let's assume it is true for n. Let's now compute the number of moves required for n+1 disks.
            // The n+1 disks pyramid is basically a large disk below a n disk pyramid.
            // To solve it, we move:
            // - the n disk pyramid to the center axis (2^n-1 moves)
            // - then the largest disk to the right axis (1 move)
            // - then the n disk pyramid to the right axis (2^n-1 moves)
            // The total number of moves required for n+1 disks is therefore 2*(2^n-1)+1, i.e. 2^(n+1)-1
            return (int)Math.Pow(2, nbDisks) - 1;
        }

        public Stack<int>[] GetPosition(int nbDisks, int nbMoves)
        {
            // Initialize the axis
            _nbDisks = nbDisks;
            _stacks = new Stack<int>[3];
            for (int i = 0; i < _stacks.Length; i++)
            {
                _stacks[i] = new Stack<int>();
            }

            // Load the first stack with all the disks
            // Each disk is represented by a number indicating its radius
            for (int i = 0; i < _nbDisks; i++)
            {
                _stacks[0].Push(_nbDisks - i);
            }

            // Play the game
            int currentMove = 0;
            while (!_isSolved() && currentMove < nbMoves)
            {
                _performMove(currentMove);
                currentMove++;
            }

            return _stacks;
        }

        private bool _isSolved()
        {
            return _stacks[0].Count == 0 && _stacks[1].Count == 0 && _stacks[2].Count == _nbDisks;
        }

        private void _performMove(int step)
        {
            // As per the supplied algorithm, the moves alternate between moving the smallest disk and making the only other possible move

            // Move the smallest disk
            if (step % 2 == 0)
            {
                // One axis right if the number of disks is even, one axis left otherwise
                int to = (_nbDisks % 2 == 0 ? _smallestDiskPosition + 1 : _smallestDiskPosition - 1);
                to = (to + 3) % 3;
                _move(_smallestDiskPosition, to);
                _smallestDiskPosition = to;
            }
            // Make the only other possible move
            else
            {
                // Find the two positions that don't contain the smallest disk
                int position1 = (_smallestDiskPosition - 1 + 3) % 3;
                int position2 = (_smallestDiskPosition + 1 + 3) % 3;

                // Make the only possible move
                if (!_move(position1, position2))
                {
                    _move(position2, position1);
                }
            }
        }

        private bool _move(int from, int to)
        {
            // No disk at source position
            if (_stacks[from].Count == 0)
            {
                return false;
            }

            // Smaller disk at target position
            if (_stacks[to].Count != 0 && _stacks[from].Peek() > _stacks[to].Peek())
            {
                return false;
            }

            // Perform the move
            _stacks[to].Push(_stacks[from].Pop());
            return true;
        }

        // Builds the expected graphical representation
        public static string[] Draw(Stack<int>[] stacks)
        {
            int nbDisks = stacks.Sum(s => s.Count);
            int axisWidth = nbDisks * 2 + 1; // every axis must be wide enough for the largest disk (2 times the disk radius + 1 for the axis itself)

            string[] rows = new string[nbDisks];

            // For each axis
            for (int i = 0; i < 3; i++)
            {
                // For each row, starting from the top
                for (int j = 0; j < nbDisks; j++)
                {
                    // Space between each pair of axis
                    if (i > 0)
                    {
                        rows[j] += " ";
                    }

                    // If there are 5 disks but only 3 on the current axis, the first two rows muts be drawn empty
                    if (j + stacks[i].Count < nbDisks)
                    {
                        rows[j] += _drawEmptyAxis(axisWidth);
                    }
                    else
                    {
                        rows[j] += _drawDisk(stacks[i].Pop(), axisWidth);
                    }
                }
            }

            return rows;
        }

        private static string _drawEmptyAxis(int axisWidth)
        {
            StringBuilder row = new();
            for (int i = 0; i < axisWidth; i++)
            {
                row.Append(i == axisWidth / 2 ? '|' : ' ');
            }

            return row.ToString();
        }

        private static string _drawDisk(int diskRadius, int axisWidth)
        {
            StringBuilder row = new();
            int axisCenter = axisWidth / 2;
            for (int i = 0; i < axisWidth; i++)
            {
                row.Append(i < axisCenter - diskRadius || i > axisCenter + diskRadius ? ' ' : '#');
            }

            return row.ToString();
        }
    }
}
