// https://www.codingame.com/training/medium/blunder-episode-1

using System.Collections.Generic;
using System.Linq;

namespace Codingame.Medium.Blunder1;

public class Blunder1
{
    // Environment
    private Map _map { get; set; }

    // State
    private State _state { get; set; }
    private HashSet<Snapshot> _history { get; set; }
    private bool _isStuckInInfiniteLoop { get; set; }

    public BlunderResult Traverse(string[] rows)
    {
        _map = Map.Parse(rows);
        _state = new State();
        _history = new HashSet<Snapshot>();
        _isStuckInInfiniteLoop = false;
        List<Direction> _path = new();

        _state.SetPosition(_map.StartPosition);
        int n = 0;
        while (_canMove())
        {
            _updateState();
            _saveSnapshot();
            _path.Add(_move());
        }

        return new BlunderResult
        {
            IsStuckInInfiniteLoop = _isStuckInInfiniteLoop,
            Path = _path.Select(d => d.ToString().ToUpper()).ToArray(),
        };
    }

    private bool _canMove()
    {
        return !_isOnSuicideBooth() && !_isStuckInInfiniteLoop;
    }

    private bool _isOnSuicideBooth()
    {
        // Codingame doesn't handle tuple comparisons, so we need to compare both elements individually
        return _state.Position.Item1 == _map.SuicideBoothPosition.Item1
            && _state.Position.Item2 == _map.SuicideBoothPosition.Item2;
    }

    private void _updateState()
    {
        // State change according to current spot
        switch (_map.Spots[_state.Position])
        {
            case Spot.Inverter:
                _state.ToggleDirectionPriorities();
                break;

            case Spot.Beer:
                _state.ToggleBreakerMode();
                break;

            case Spot.SouthModifier:
                _state.SetDirection(Direction.South);
                break;

            case Spot.EastModifier:
                _state.SetDirection(Direction.East);
                break;

            case Spot.NorthModifier:
                _state.SetDirection(Direction.North);
                break;

            case Spot.WestModifier:
                _state.SetDirection(Direction.West);
                break;

            case Spot.Teleporter:
                // Codingame doesn't handle tuple comparisons, so we need to compare both elements individually
                if (_state.Position.Item1 == _map.Teleporter1Position.Item1 && _state.Position.Item2 == _map.Teleporter1Position.Item2) _state.SetPosition(_map.Teleporter2Position);
                else _state.SetPosition(_map.Teleporter1Position);
                break;

            case Spot.Obstacle:
                if (_state.BreakerMode) _map.DestroyObstacle(_state.Position);
                break;

            default:
                break;
        }

        // State change according to nearby walls or obstacles
        bool isFirstDirectionChange = true;
        while (_hasReachedObstacleOrWall())
        {
            _state.ChangeDirection(isFirstDirectionChange);
            isFirstDirectionChange = false;
        }
    }

    private void _saveSnapshot()
    {
        Snapshot snapshot = new()
        {
            Position = _state.Position,
            Direction = _state.Direction,
            NbObstacles = _map.NbObstacles,
            BreakerMode = _state.BreakerMode,
            ArePrioritiesInverted = _state.ArePrioritiesInverted,
        };
        if (_history.Contains(snapshot))
        {
            _isStuckInInfiniteLoop = true;
        }
        else
        {
            _history.Add(snapshot);
        }
    }

    private bool _hasReachedObstacleOrWall()
    {
        // Codingame doesn't handle tuples well, so we can't just declare and use something like '(int, int) position = (0, 0);'
        int x = 0;
        int y = 0; ;
        switch (_state.Direction)
        {
            case Direction.South:
                x = _state.Position.Item1;
                y = _state.Position.Item2 + 1;
                break;

            case Direction.East:
                x = _state.Position.Item1 + 1;
                y = _state.Position.Item2;
                break;

            case Direction.North:
                x = _state.Position.Item1;
                y = _state.Position.Item2 - 1;
                break;

            case Direction.West:
                x = _state.Position.Item1 - 1;
                y = _state.Position.Item2;
                break;

        }
        return _map.Spots[(x, y)] == Spot.Wall
            || !_state.BreakerMode && _map.Spots[(x, y)] == Spot.Obstacle;
    }

    private Direction _move()
    {
        switch (_state.Direction)
        {
            case Direction.South:
                _state.SetPosition((_state.Position.Item1, _state.Position.Item2 + 1));
                break;

            case Direction.East:
                _state.SetPosition((_state.Position.Item1 + 1, _state.Position.Item2));
                break;

            case Direction.North:
                _state.SetPosition((_state.Position.Item1, _state.Position.Item2 - 1));
                break;

            case Direction.West:
                _state.SetPosition((_state.Position.Item1 - 1, _state.Position.Item2));
                break;
        }

        return _state.Direction;
    }

    private class Map
    {
        public Dictionary<(int, int), Spot> Spots { get; private set; }
        public (int, int) StartPosition { get; private set; }
        public (int, int) SuicideBoothPosition { get; private set; }
        public (int, int) Teleporter1Position { get; private set; }
        public (int, int) Teleporter2Position { get; private set; }
        public int NbObstacles { get; private set; }

        public void DestroyObstacle((int, int) position)
        {
            if (Spots.ContainsKey(position) && Spots[position] == Spot.Obstacle)
            {
                Spots[position] = Spot.Empty;
                NbObstacles--;
            }
        }

        public static Map Parse(string[] rows)
        {
            Map map = new();
            int nbTeleporters = 0;
            map.NbObstacles = 0;

            Dictionary<(int, int), Spot> spots = new();

            for (int i = 0; i < rows[0].Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    switch (rows[j][i])
                    {
                        case '@':
                            spots.Add((i, j), Spot.Start);
                            map.StartPosition = (i, j);
                            break;

                        case '$':
                            spots.Add((i, j), Spot.SuicideBooth);
                            map.SuicideBoothPosition = (i, j);
                            break;

                        case ' ':
                            spots.Add((i, j), Spot.Empty);
                            break;

                        case '#':
                            spots.Add((i, j), Spot.Wall);
                            break;

                        case 'X':
                            spots.Add((i, j), Spot.Obstacle);
                            map.NbObstacles++;
                            break;

                        case 'T':
                            spots.Add((i, j), Spot.Teleporter);
                            if (nbTeleporters++ == 0) map.Teleporter1Position = (i, j);
                            else map.Teleporter2Position = (i, j);
                            break;

                        case 'I':
                            spots.Add((i, j), Spot.Inverter);
                            break;

                        case 'S':
                            spots.Add((i, j), Spot.SouthModifier);
                            break;

                        case 'E':
                            spots.Add((i, j), Spot.EastModifier);
                            break;

                        case 'N':
                            spots.Add((i, j), Spot.NorthModifier);
                            break;

                        case 'W':
                            spots.Add((i, j), Spot.WestModifier);
                            break;

                        case 'B':
                            spots.Add((i, j), Spot.Beer);
                            break;

                    }
                }
            }

            map.Spots = spots;

            return map;
        }
    }

    private enum Spot
    {
        Start,
        Empty,
        Wall,
        Obstacle,
        Teleporter,
        Inverter,
        SouthModifier,
        EastModifier,
        NorthModifier,
        WestModifier,
        Beer,
        SuicideBooth,
    }

    private class State
    {
        public (int, int) Position { get; private set; }
        public Direction Direction { get; private set; }
        public Direction[] DirectionChangePriorities { get; set; }
        public bool BreakerMode { get; private set; }
        public bool ArePrioritiesInverted { get; private set; }

        private int _currentDirectionIndex;
        private readonly Direction[] NormalPriorities = new Direction[] { Direction.South, Direction.East, Direction.North, Direction.West };
        private readonly Direction[] InvertedPriorities = new Direction[] { Direction.West, Direction.North, Direction.East, Direction.South };

        public State()
        {
            Position = (0, 0);
            DirectionChangePriorities = NormalPriorities;
            Direction = DirectionChangePriorities[0];
            BreakerMode = false;
            _currentDirectionIndex = 0;
        }

        public void SetPosition((int, int) position)
        {
            Position = position;
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        public void ChangeDirection(bool isFirstDirectionChange)
        {
            if (isFirstDirectionChange) _currentDirectionIndex = 0;
            else _currentDirectionIndex = (_currentDirectionIndex + 1) % DirectionChangePriorities.Length;

            Direction = DirectionChangePriorities[_currentDirectionIndex];
        }

        public void ToggleDirectionPriorities()
        {
            ArePrioritiesInverted = !ArePrioritiesInverted;
            if (ArePrioritiesInverted) DirectionChangePriorities = InvertedPriorities;
            else DirectionChangePriorities = NormalPriorities;
        }

        public void ToggleBreakerMode()
        {
            BreakerMode = !BreakerMode;
        }
    }

    private enum Direction
    {
        South,
        East,
        North,
        West,
    }

    private class Snapshot
    {
        public (int, int) Position { get; set; }
        public Direction Direction { get; set; }
        public int NbObstacles { get; set; }
        public bool BreakerMode { get; set; }
        public bool ArePrioritiesInverted { get; set; }

        public override bool Equals(object obj)
        {
            return GetHashCode() == ((Snapshot)obj).GetHashCode();
        }

        public override int GetHashCode()
        {
            int hashCode = 1000000 * Position.Item1 + 10000 * Position.Item2 + 100 * NbObstacles;
            switch (Direction)
            {
                case Direction.South:
                    hashCode += 12;
                    break;

                case Direction.East:
                    hashCode += 8;
                    break;

                case Direction.North:
                    hashCode += 4;
                    break;

                case Direction.West:
                default:
                    break;

            }

            if (BreakerMode) hashCode += 2;
            if (ArePrioritiesInverted) hashCode += 1;

            return hashCode;
        }
    }
}

public class BlunderResult
{
    public bool IsStuckInInfiniteLoop { get; set; }
    public string[] Path { get; set; }
}