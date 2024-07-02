// https://www.codingame.com/training/hard/elevator

namespace Codingame.Hard.Elevator;

public class Elevator
{
    // Complexity: O(n) time, O(1) space
    public int GetNumberOfPresses(int nbFloors, int start, int target, int up, int down)
    {
        // If the target floor is lower than the starting floor, we flip the elevator upside down so that the algorithm below always works with a higher target floor
        if (target < start)
        {
            (up, down) = (down, up);
            (start, target) = (nbFloors - start + 1, nbFloors - target + 1);
        }

        int nbPresses = 0;
        bool canMoveUp;
        bool canMoveDown;
        int current = start;
        int snapshot = 0;
        while (true)
        {
            // Target floor reached -> success
            if (current == target)
            {
                return nbPresses;
            }

            // Cannot move -> failure
            canMoveUp = (current + up) <= nbFloors;
            canMoveDown = (current - down) >= 1;
            if (!canMoveUp && !canMoveDown)
            {
                return -1;
            }

            // Perform a move
            // We always move towards the target, except when the corresponding button doesn't allow it (too close to the top floor to move up, or too close to the ground floor to move down)
            if (current < target)
            {
                if (canMoveUp)
                {
                    current += up;
                    nbPresses++;
                }
                else
                {
                    current -= down;
                    nbPresses++;
                }
            }
            else
            {
                if (canMoveDown)
                {
                    current -= down;
                    nbPresses++;
                }
                else
                {
                    current += up;
                    nbPresses++;
                }
            }

            // The main algorithm above may end up in infinite loops, where we continously cross the target back and forth
            // For instance, if we can only go up 4 floors and down 2 floors, we can never reach an odd floor from an even floor. We will keep moving up and down around the target floor
            // In order to prevent that, we store the closest floor below the target that has been visited (it could be another one, as long as it's a floor that will repeatedly be reached in the infinite loop) and fail if we reach it again
            if (current == snapshot)
            {
                return -1;
            }
            if (current < target && current > snapshot)
            {
                snapshot = current;
            }
        }
    }
}