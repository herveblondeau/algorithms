// 
using System.Collections.Generic;
using System.Linq;

namespace Codingame.SlidingPuzzle
{
    public class SlidingPuzzle
    {

        public int GetNumberOfMoves(int[,] start, int[,] end)
        {

            Position current;
            Position next = new Position(start);
            Position target = new Position(end);
            var toProcess = new Queue<Position>();
            toProcess.Enqueue(next);
            var visited = new Dictionary<Position, int>();
            visited.Add(next, 0);

            int nbMoves = -1;

            while (toProcess.Count > 0)
            {
                current = toProcess.Dequeue();
                nbMoves = visited[current];

                if (current.Equals(target))
                {
                    break;
                }

                next = current.SlideUp();
                if (next != null && !visited.ContainsKey(next))
                {
                    toProcess.Enqueue(next);
                    visited.Add(next, nbMoves + 1);
                }

                next = current.SlideDown();
                if (next != null && !visited.ContainsKey(next))
                {
                    toProcess.Enqueue(next);
                    visited.Add(next, nbMoves + 1);
                }

                next = current.SlideLeft();
                if (next != null && !visited.ContainsKey(next))
                {
                    toProcess.Enqueue(next);
                    visited.Add(next, nbMoves + 1);
                }

                next = current.SlideRight();
                if (next != null && !visited.ContainsKey(next))
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

            public Position SlideUp()
            {
                if (_row == _height - 1) return null;

                Position position = new Position(_board);
                (position._board[_row, _column], position._board[_row + 1, _column]) = (position._board[_row + 1, _column], position._board[_row, _column]);
                position._row++;

                return position;
            }

            public Position SlideDown()
            {
                if (_row == 0) return null;

                Position position = new Position(_board);
                (position._board[_row, _column], position._board[_row - 1, _column]) = (position._board[_row - 1, _column], position._board[_row, _column]);
                position._row--;

                return position;
            }

            public Position SlideLeft()
            {
                if (_column == _width - 1) return null;

                Position position = new Position(_board);
                (position._board[_row, _column], position._board[_row, _column + 1]) = (position._board[_row, _column + 1], position._board[_row, _column]);
                position._column++;

                return position;
            }

            public Position SlideRight()
            {
                if (_column == 0) return null;

                Position position = new Position(_board);
                (position._board[_row, _column], position._board[_row, _column - 1]) = (position._board[_row, _column - 1], position._board[_row, _column]);
                position._column--;

                return position;
            }

            public override int GetHashCode()
            {
                return string.Join("", _board.Cast<int>()).GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return GetHashCode() == ((Position)obj).GetHashCode();
            }
        }

    }
}
