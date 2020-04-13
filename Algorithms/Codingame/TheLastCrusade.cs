// 

using System;
using System.Collections.Generic;

namespace IndianaJones
{
    public class TheLastCrusade
    {
        private IRoom[,] _rooms { get; set; }

        public TheLastCrusade(IRoom[,] rooms)
        {
            _rooms = rooms;
        }

        public (int, int) FindNextRoom(int x, int y, Side entrance)
        {
            switch(_rooms[x, y].GetExitSide(entrance))
            {
                case Side.Top:
                    return (x, y - 1);

                case Side.Left:
                    return (x - 1, y);

                case Side.Bottom:
                    return (x, y + 1);

                case Side.Right:
                    return (x + 1, y);

                case Side.None:
                default:
                    return (x, y);
            }
        }

        static public IRoom ToRoom(int roomType)
        {
            switch (roomType)
            {
                case 0:
                    return new Type0Room();

                case 1:
                    return new Type1Room();

                case 2:
                    return new Type2Room();

                case 3:
                    return new Type3Room();

                case 4:
                    return new Type4Room();

                case 5:
                    return new Type5Room();

                case 6:
                    return new Type6Room();

                case 7:
                    return new Type7Room();

                case 8:
                    return new Type8Room();

                case 9:
                    return new Type9Room();

                case 10:
                    return new Type10Room();

                case 11:
                    return new Type11Room();

                case 12:
                    return new Type12Room();

                case 13:
                    return new Type13Room();

                default:
                    return new Type0Room();
            }
        }

        static public Side ToSide(string sideStr)
        {
            switch (sideStr.ToLower())
            {
                case "top":
                    return Side.Top;

                case "left":
                    return Side.Left;

                case "right":
                    return Side.Right;

                case "bottom":
                    return Side.Bottom;

                default:
                    return Side.None;
            }
        }
    }

    public enum Side
    {
        None,
        Top,
        Left,
        Bottom,
        Right,
    }

    public interface IRoom
    {
        Side GetExitSide(Side entrance);
    }

    public class Type0Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            return Side.None;
        }
    }

    public class Type1Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            return Side.Bottom;
        }
    }

    public class Type2Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Left) return Side.Right;
            else if (entrance == Side.Right) return Side.Left;
            else return Side.None;
        }
    }

    public class Type3Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type4Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Left;
            else if (entrance == Side.Right) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type5Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Right;
            else if (entrance == Side.Left) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type6Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Left) return Side.Right;
            else if (entrance == Side.Right) return Side.Left;
            else return Side.None;
        }
    }

    public class Type7Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Bottom;
            else if (entrance == Side.Right) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type8Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Left) return Side.Bottom;
            else if (entrance == Side.Right) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type9Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Bottom;
            else if (entrance == Side.Left) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type10Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Left;
            else return Side.None;
        }
    }

    public class Type11Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Top) return Side.Right;
            else return Side.None;
        }
    }

    public class Type12Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Right) return Side.Bottom;
            else return Side.None;
        }
    }

    public class Type13Room : IRoom
    {
        public Side GetExitSide(Side entrance)
        {
            if (entrance == Side.Left) return Side.Bottom;
            else return Side.None;
        }
    }
}