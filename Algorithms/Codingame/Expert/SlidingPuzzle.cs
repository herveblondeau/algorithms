// https://www.codingame.com/training/expert/sliding-puzzle
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Expert.SlidingPuzzle;

public class SlidingPuzzle
{

    // The algorithm is basically a BFS
    // The 'end' parameter allows this algorithm to be more generic than the Codingame requirements, as it will find the minimum number of moves required to go from 'start' to 'end', with 'end' being any position.
    // Notes:
    // - the dot from the Codingame problem must be supplied as a zero
    // - for each array, the first coordinate is the row number (with the top row being 0) and the second coordinate is the column number (with the left column being 0)
    public int GetNumberOfMoves(int[,] start, int[,] end)
    {

        Position current;
        Position? next;
        Position target = new(end);
        var toProcess = new Queue<Position>();
        var visited = new Dictionary<Position, int>();

        next = new Position(start);
        toProcess.Enqueue(next);
        visited.Add(next, 0);
        int nbMoves = -1;

        while (toProcess.Count > 0)
        {
            current = toProcess.Dequeue();
            nbMoves = visited[current];

            // Exit condition
            if (current.Equals(target))
            {
                break;
            }

            // Enqueue the immediately reachable positions (BFS)
            next = current.SlideUp();
            if (next is not null && !visited.ContainsKey(next))
            {
                toProcess.Enqueue(next);
                visited.Add(next, nbMoves + 1);
            }

            next = current.SlideDown();
            if (next is not null && !visited.ContainsKey(next))
            {
                toProcess.Enqueue(next);
                visited.Add(next, nbMoves + 1);
            }

            next = current.SlideLeft();
            if (next is not null && !visited.ContainsKey(next))
            {
                toProcess.Enqueue(next);
                visited.Add(next, nbMoves + 1);
            }

            next = current.SlideRight();
            if (next is not null && !visited.ContainsKey(next))
            {
                toProcess.Enqueue(next);
                visited.Add(next, nbMoves + 1);
            }
        }

        return nbMoves;

    }

    private class Position
    {
        private int[,] _board;
        private int _column;
        private int _row;
        private int _width;
        private int _height;

        public Position(int[,] board)
        {
            _height = board.GetLength(0);
            _width = board.GetLength(1);
            _board = new int[_height, _width];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _board[i, j] = board[i, j];
                    if (_board[i, j] == 0)
                    {
                        _row = i;
                        _column = j;
                    }
                }
            }
        }

        // Returns a new position where the 0 has been exchanged with the piece above
        public Position? SlideUp()
        {
            if (_row == 0) return null; // 0 already on top => cannot move

            Position position = new(_board);
            (position._board[_row, _column], position._board[_row - 1, _column]) = (position._board[_row - 1, _column], position._board[_row, _column]);
            position._row--;

            return position;
        }

        // Returns a new position where the 0 has been exchanged with the piece below
        public Position? SlideDown()
        {
            if (_row == _height - 1) return null; // 0 already at the bottom => cannot move

            Position position = new(_board);
            (position._board[_row, _column], position._board[_row + 1, _column]) = (position._board[_row + 1, _column], position._board[_row, _column]);
            position._row++;

            return position;
        }

        // Returns a new position where the 0 has been exchanged with the piece on the left
        public Position? SlideLeft()
        {
            if (_column == 0) return null; // 0 already on the left => cannot move

            Position position = new(_board);
            (position._board[_row, _column], position._board[_row, _column - 1]) = (position._board[_row, _column - 1], position._board[_row, _column]);
            position._column--;

            return position;
        }

        // Returns a new position where the 0 has been exchanged with the piece on the right
        public Position? SlideRight()
        {
            if (_column == _width - 1) return null; // 0 already on the right => cannot move

            Position position = new(_board);
            (position._board[_row, _column], position._board[_row, _column + 1]) = (position._board[_row, _column + 1], position._board[_row, _column]);
            position._column++;

            return position;
        }

        public override int GetHashCode()
        {
            return string.Join("", _board.Cast<int>()).GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            return GetHashCode() == ((Position)obj).GetHashCode();
        }
    }
}
