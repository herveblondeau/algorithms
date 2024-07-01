// https://www.codingame.com/training/medium/3n-tiling
using System;

namespace Codingame.ThreeNTiling
{
    public class ThreeNTiling
    {
        private const int _modulo = 1000000007;

        public long GetNumberOfValidLayouts(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                return 0;
            }

            switch (height)
            {
                case 1:
                    return width % 3 == 0 ? 1 : 0;

                case 2:
                    return SolveForHeightTwo(width);

                case 3:
                    return SolveForHeightThree(width);

                default:
                    throw new NotImplementedException("Height " + height + " must be 1, 2 or 3");
            }
        }

        /*
            The number of layouts for a rectangle is defined recursively as the sum of the numbers of layouts of itself minus:
            - a 2x2 square -> rectangle of width minus two
            - two horizontal 3x1 -> rectangle of width minus three

            Visually:
            ┌────────────┄
            │
            └────────────┄
                  =
                ┌────────┄
                │
                └────────┄
                  +
                  ┌──────┄
                  │
                  └──────┄
          */
        private long SolveForHeightTwo(int width)
        {
            // Base cases
            if (width == 1)
                return 0;
            if (width == 2)
                return 1;
            if (width == 3)
                return 1;

            // Tabulation normally uses an array type of structure, but in this case we don't need to memorize all values, just the last three
            // That's quite a few variables but it saves space
            long nblayoutsForWidthMinusThree = 0;
            long nblayoutsForWidthMinusTwo = 1;
            long nblayoutsForWidthMinusOne = 1;
            long nbLayouts = 0;
            for (int i = 4; i <= width; i++)
            {
                nbLayouts = (nblayoutsForWidthMinusThree + nblayoutsForWidthMinusTwo) % _modulo;
                nblayoutsForWidthMinusThree = nblayoutsForWidthMinusTwo;
                nblayoutsForWidthMinusTwo = nblayoutsForWidthMinusOne;
                nblayoutsForWidthMinusOne = nbLayouts;
            }

            return nbLayouts;
        }

        /*
            We deal with three shapes:
            - rectangle
            ┌───────────┐
            │           │
            │           │
            └───────────┘
            - shape two
            ┌───────────┐
            │           │
            └─┐         │
              └─────────┘
            - shape three
              ┌─────────┐
              │         │
            ┌─┘         │
            └───────────┘
            We define the width of a shape as the width of its longest horizontal side (for all three shapes above, the width is 6)

            The number of layouts for a rectangle is the sum of the numbers of layouts of itself minus:
            - a vertical 1x3 -> rectangle of width minus one
            - three horizontal 3x1 -> rectangle of width minus three
            - a 2x2 square and a horizontal 1x3 (times 2, since the square can be removed at the top or the bottom, leading to two symmetrical configurations) -> shape two of width minus two
            Visually:
            ┌────────────┄
            │
            │
            └────────────┄
                  =
              ┌──────────┄
              │
              │
              └──────────┄
                  +
                  ┌──────┄
                  │
                  │
                  └──────┄
                  + 2x
              ┌──────────┄
              │
              └─┐
                └────────┄

            The number of layouts for a "shape two" is the sum of the numbers of layouts of itself minus:
            - three horizontal 3x1 -> shape two of width minus three
            - a 2x2 square -> shape three of width minus one
            Visually:
            ┌────────────┄
            │
            └─┐
              └──────────┄
                  =
                  ┌──────┄
                  │
                  └─┐
                    └────┄
                  +
                ┌────────┄
                │
              ┌─┘
              └──────────┄

            The number of layouts for a "shape three" is the sum of the numbers of layouts of itself minus:
            - a 2x2 square and a horizontal 3x1 -> rectangle of width minus three
            - three horizontal 3x1 -> shape three of width minus three
            Visually:
              ┌──────────┄
              │
            ┌─┘
            └────────────┄
                  =
                    ┌────┄
                    │
                  ┌─┘
                  └──────┄
                  +
                  ┌──────┄
                  │
                  │
                  └──────┄

            So we need to keep track of the number of layouts for each of our three shapes individually, each one using dynamic programming.
          */
        private long SolveForHeightThree(int width)
        {
            // Base cases
            if (width == 1)
                return 1;
            if (width == 2)
                return 1;
            if (width == 3)
                return 2;

            // Dynamic programming
            // Tabulation normally uses an array type of structure, but in this case we don't need to memorize all values, just the last three
            // That's quite a few variables but it saves space
            long nbLayoutsForRectangle = 0;
            long nbLayoutsForRectangleAndWidthMinusThree = 1;
            long nbLayoutsForRectangleAndWidthMinusTwo = 1;
            long nbLayoutsForRectangleAndWidthMinusOne = 2;

            long nbLayoutsForShapeTwo = 0;
            long nbLayoutsForShapeTwoAndWidthMinusThree = 0;
            long nbLayoutsForShapeTwoAndWidthMinusTwo = 0;
            long nbLayoutsForShapeTwoAndWidthMinusOne = 0;

            long nbLayoutsForShapeThree = 0;
            long nbLayoutsForShapeThreeAndWidthMinusThree = 0;
            long nbLayoutsForShapeThreeAndWidthMinusTwo = 0;
            long nbLayoutsForShapeThreeAndWidthMinusOne = 1;
            for (int i = 4; i <= width; i++)
            {
                // Compute the numbers of layouts for current width
                nbLayoutsForRectangle = (nbLayoutsForRectangleAndWidthMinusOne + nbLayoutsForRectangleAndWidthMinusThree + 2 * nbLayoutsForShapeTwoAndWidthMinusTwo) % _modulo;
                nbLayoutsForShapeTwo = (nbLayoutsForShapeTwoAndWidthMinusThree + nbLayoutsForShapeThreeAndWidthMinusOne) % _modulo;
                nbLayoutsForShapeThree = (nbLayoutsForRectangleAndWidthMinusThree + nbLayoutsForShapeThreeAndWidthMinusThree) % _modulo;

                // Update the memorized numbers of layouts
                nbLayoutsForRectangleAndWidthMinusThree = nbLayoutsForRectangleAndWidthMinusTwo;
                nbLayoutsForRectangleAndWidthMinusTwo = nbLayoutsForRectangleAndWidthMinusOne;
                nbLayoutsForRectangleAndWidthMinusOne = nbLayoutsForRectangle;
                nbLayoutsForShapeTwoAndWidthMinusThree = nbLayoutsForShapeTwoAndWidthMinusTwo;
                nbLayoutsForShapeTwoAndWidthMinusTwo = nbLayoutsForShapeTwoAndWidthMinusOne;
                nbLayoutsForShapeTwoAndWidthMinusOne = nbLayoutsForShapeTwo;
                nbLayoutsForShapeThreeAndWidthMinusThree = nbLayoutsForShapeThreeAndWidthMinusTwo;
                nbLayoutsForShapeThreeAndWidthMinusTwo = nbLayoutsForShapeThreeAndWidthMinusOne;
                nbLayoutsForShapeThreeAndWidthMinusOne = nbLayoutsForShapeThree;
            }

            return nbLayoutsForRectangle;
        }

    }
}