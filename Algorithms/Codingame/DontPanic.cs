// https://www.codingame.com/training/medium/don't-panic-episode-1

using System.Collections.Generic;

namespace Codingame.DontPanic
{
    public class DontPanic
    {
        private int[] _floorExits { get; set; }
        private HashSet<int> _processedFloors { get; set; }

        public DontPanic(int[] floorExits)
        {
            _floorExits = floorExits;
            _processedFloors = new HashSet<int>();
        }

        public string GetAction(int floor, int position, string direction)
        {
            // Floor is negative if there are no active clones in the area
            if (floor < 0) return "WAIT";

            // We don't need more than one clone per floor. So, once a decision has been made for a given floor, no blocking is required
            if (_processedFloors.Contains(floor)) return "WAIT";
            _processedFloors.Add(floor);

            // If the clone is heading towards an elevator or an exit, wait, otherwise block it
            if (_floorExits[floor] < position && direction == "RIGHT") return "BLOCK";
            else if (position < _floorExits[floor] && direction == "LEFT") return "BLOCK";

            return "WAIT";
        }

    }
}
