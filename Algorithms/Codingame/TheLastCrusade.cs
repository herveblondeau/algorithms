// 

using System;
using System.Collections.Generic;

namespace IndianaJones
{
    public class TheLastCrusade
    {
        private int[,] _rooms { get; set; }

        public TheLastCrusade(int[,] rooms)
        {
            _rooms = rooms;
        }

        public (int, int) FindNextRoom(int x, int y, string entrance)
        {
            switch(_rooms[x, y])
            {
                case 0:
                    break;

                case 1:
                    y++;
                    break;

                case 2:
                    if (entrance == "LEFT") x++;
                    else if (entrance == "RIGHT") x--;
                    break;

                case 3:
                    if (entrance == "TOP") y++;
                    break;

                case 4:
                    if (entrance == "TOP") x--;
                    else if (entrance == "RIGHT") y++;
                    break;

                case 5:
                    if (entrance == "TOP") x++;
                    else if (entrance == "LEFT") y++;
                    break;

                case 6:
                    if (entrance == "LEFT") x++;
                    else if (entrance == "RIGHT") x--;
                    break;

                case 7:
                    if (entrance == "TOP") y++;
                    else if (entrance == "RIGHT") y++;
                    break;

                case 8:
                    if (entrance == "LEFT") y++;
                    else if (entrance == "RIGHT") y++;
                    break;

                case 9:
                    if (entrance == "LEFT") y++;
                    else if (entrance == "TOP") y++;
                    break;

                case 10:
                    if (entrance == "TOP") x--;
                    break;

                case 11:
                    if (entrance == "TOP") x++;
                    break;

                case 12:
                    if (entrance == "RIGHT") y++;
                    break;

                case 13:
                    if (entrance == "LEFT") y++;
                    break;

                default:
                    break;
            }

            return (x, y);
        }
    }

}