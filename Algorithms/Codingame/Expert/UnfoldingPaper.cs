// https://www.codingame.com/training/expert/unfolding-paper

using System.Collections.Generic;
using System.Linq;

namespace Codingame.Expert.UnfoldingPaper;

public class UnfoldingPaper
{
    /*
     * Returns the number of parts after unfolding n times
     *
     * It would take too much space to actually draw and store the unfolded paper, then to compute the number of parts
     * Instead, we can notice that each part belongs to one of 15 types. Each type, when unfolded once, always results in the same output types
     * For instance, a top left corner, when unfolded once, ends up with a part in the center of the paper. The 15 types, with their results when unfolded, are listed below
     * To solve the problem, we proceed in two steps:
     * - first, we parse the initial folder paper representation, which allows us to store the number of parts of each type
     * - next, we unfold
     *
     */
    public int Unfold(string[] folded, int nbUnfoldings)
    {
        // Convert the string array input to a 2-dimensional char array
        char[,] paper = new char[folded[0].Length, folded.Length];
        for (int i = 0; i < folded.Length; i++)
        {
            for (int j = 0; j < folded[i].Length; j++)
            {
                paper[j, i] = folded[i][j];
            }
        }

        // Parse
        var current = _parse(paper);

        // Unfold
        for (int i = 0; i < nbUnfoldings; i++)
        {
            current = _unfold(current);
        }

        return current.Sum(x => x.Value);
    }

    // Parsing is done recursively
    // Every time we find a position that belongs to a part, we look through the neighbors to map the whole part
    // Each processed position is deleted so that it is not processed twice
    // The part type is determined based on which edges the part touches
    private Dictionary<PartType, int> _parse(char[,] paper)
    {
        Dictionary<PartType, int> parsed = new();

        var _width = paper.GetLength(0);
        var _height = paper.GetLength(1);

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (paper[i, j] == '#')
                {
                    Part part = new();
                    part.Parse(i, j, paper);
                    _add(parsed, part.Type, 1);
                }
            }
        }

        return parsed;
    }

    private class Part
    {
        public bool TouchesLeft { private get; set; }
        public bool TouchesTop { private get; set; }
        public bool TouchesRight { private get; set; }
        public bool TouchesDown { private get; set; }
        public PartType Type
        {
            get
            {
                if (TouchesLeft && TouchesTop && !TouchesRight && !TouchesDown) return PartType.TopLeftCorner;
                if (!TouchesLeft && TouchesTop && !TouchesRight && !TouchesDown) return PartType.TopCenterCorner;
                if (!TouchesLeft && TouchesTop && TouchesRight && !TouchesDown) return PartType.TopRightCorner;
                if (TouchesLeft && !TouchesTop && !TouchesRight && !TouchesDown) return PartType.MiddleLeftCorner;
                if (!TouchesLeft && !TouchesTop && !TouchesRight && !TouchesDown) return PartType.MiddleCenterCorner;
                if (!TouchesLeft && !TouchesTop && TouchesRight && !TouchesDown) return PartType.MiddleRightCorner;
                if (TouchesLeft && !TouchesTop && !TouchesRight && TouchesDown) return PartType.BottomLeftCorner;
                if (!TouchesLeft && !TouchesTop && !TouchesRight && TouchesDown) return PartType.BottomCenterCorner;
                if (!TouchesLeft && !TouchesTop && TouchesRight && TouchesDown) return PartType.BottomRightCorner;
                if (TouchesLeft && TouchesTop && TouchesRight && !TouchesDown) return PartType.TopStripe;
                if (TouchesLeft && !TouchesTop && TouchesRight && !TouchesDown) return PartType.MiddleStripe;
                if (TouchesLeft && !TouchesTop && TouchesRight && TouchesDown) return PartType.BottomStripe;
                if (TouchesLeft && TouchesTop && !TouchesRight && TouchesDown) return PartType.LeftStripe;
                if (!TouchesLeft && TouchesTop && !TouchesRight && TouchesDown) return PartType.CenterStripe;
                if (!TouchesLeft && TouchesTop && TouchesRight && TouchesDown) return PartType.RightStripe;
                return PartType.Full;
            }
        }

        public void Parse(int i, int j, char[,] paper)
        {
            if (i < 0 || i >= paper.GetLength(0) || j < 0 || j >= paper.GetLength(1) || paper[i, j] == '.')
            {
                return;
            }

            if (i == 0)
            {
                TouchesLeft = true;
            }
            if (j == 0)
            {
                TouchesTop = true;
            }
            if (i == paper.GetLength(0) - 1)
            {
                TouchesRight = true;
            }
            if (j == paper.GetLength(1) - 1)
            {
                TouchesDown = true;
            }

            paper[i, j] = '.';

            Parse(i - 1, j, paper);
            Parse(i + 1, j, paper);
            Parse(i, j - 1, paper);
            Parse(i, j + 1, paper);

            paper[i, j] = '.';
        }
    }

    /*
     * Performs one unfold
     * Here is the list of all part types and the resulting types after unfolding:
     *
     * TOP LEFT
     * The part touches the top and left borders
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │   │   │
     * │#  │    │  #│#  │
     * │   │ -> ├───┼───┤
     * │   │    │  #│#  │
     * └───┘    │   │   │
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle center
     *
     * TOP CENTER
     * The part only touches the top border
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │   │   │
     * │ # │    │ # │ # │
     * │   │ -> ├───┼───┤
     * │   │    │ # │ # │
     * └───┘    │   │   │
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle center x2
     *
     * TOP RIGHT
     * The part touches the top and right borders
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │   │   │
     * │  #│    │#  │  #│
     * │   │ -> ├───┼───┤
     * │   │    │#  │  #│
     * └───┘    │   │   │
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle left, middle right
     *
     * MIDDLE LEFT
     * The part only touches the left border
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │  #│#  │
     * │   │    │   │   │
     * │#  │ -> ├───┼───┤
     * │   │    │   │   │
     * └───┘    │  #│#  │
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle center x2
     *
     * MIDDLE CENTER
     * The part touches no border
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │ # │ # │
     * │   │    │   │   │
     * │ # │ -> ├───┼───┤
     * │   │    │   │   │
     * └───┘    │ # │ # │
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle center x4
     *
     * MIDDLE RIGHT
     * The part only touches the right border
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │#  │  #│
     * │   │    │   │   │
     * │  #│ -> ├───┼───┤
     * │   │    │   │   │
     * └───┘    │#  │  #│
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle left x2, middle right x2
     *
     * BOTTOM LEFT
     * The part touches the left and bottom borders
     *          ┌───┬───┐
     *          │  #│#  │
     * ┌───┐    │   │   │
     * │   │    │   │   │
     * │   │ -> ├───┼───┤
     * │#  │    │   │   │
     * └───┘    │   │   │
     *          │  #│#  │
     *          └───┴───┘
     * when unfolded => top center, bottom center
     *
     * BOTTOM CENTER
     * The part only touches the bottom border
     *          ┌───┬───┐
     *          │ # │ # │
     * ┌───┐    │   │   │
     * │   │    │   │   │
     * │   │ -> ├───┼───┤
     * │ # │    │   │   │
     * └───┘    │   │   │
     *          │ # │ # │
     *          └───┴───┘
     * when unfolded => top center x2, bottom center x2
     *
     * BOTTOM RIGHT
     * The part touches the right and bottom borders
     *          ┌───┬───┐
     *          │#  │  #│
     * ┌───┐    │   │   │
     * │   │    │   │   │
     * │   │ -> ├───┼───┤
     * │  #│    │   │   │
     * └───┘    │   │   │
     *          │#  │  #│
     *          └───┴───┘
     * when unfolded => top left, top right, bottom left, bottom right
     *
     * TOP STRIPE
     * The part touches the left, top and right borders
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │   │   │
     * │###│    │###│###│
     * │   │ -> ├───┼───┤
     * │   │    │###│###│
     * └───┘    │   │   │
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle stripe
     *
     * CENTER STRIPE
     * The part touches the left and right borders
     *          ┌───┬───┐
     *          │   │   │
     * ┌───┐    │###│###│
     * │   │    │   │   │
     * │###│ -> ├───┼───┤
     * │   │    │   │   │
     * └───┘    │###│###│
     *          │   │   │
     *          └───┴───┘
     * when unfolded => middle stripe x2
     *
     * BOTTOM STRIPE
     * The part touches the left, bottom and right borders
     *          ┌───┬───┐
     *          │###│###│
     * ┌───┐    │   │   │
     * │   │    │   │   │
     * │   │ -> ├───┼───┤
     * │###│    │   │   │
     * └───┘    │   │   │
     *          │###│###│
     *          └───┴───┘
     * when unfolded => top stripe, bottom stripe
     *
     * LEFT STRIPE
     * The part touches the top, left and bottom borders
     *          ┌───┬───┐
     *          │  #│#  │
     * ┌───┐    │  #│#  │
     * │#  │    │  #│#  │
     * │#  │ -> ├───┼───┤
     * │#  │    │  #│#  │
     * └───┘    │  #│#  │
     *          │  #│#  │
     *          └───┴───┘
     * when unfolded => center stripe
     *
     * CENTER STRIPE
     * The part touches the top and bottom borders
     *          ┌───┬───┐
     *          │ # │ # │
     * ┌───┐    │ # │ # │
     * │ # │    │ # │ # │
     * │ # │ -> ├───┼───┤
     * │ # │    │ # │ # │
     * └───┘    │ # │ # │
     *          │ # │ # │
     *          └───┴───┘
     * when unfolded => center stripe x2
     *
     * RIGHT STRIPE
     * The part touches the top, right and bottom borders
     *          ┌───┬───┐
     *          │#  │  #│
     * ┌───┐    │#  │  #│
     * │  #│    │#  │  #│
     * │  #│ -> ├───┼───┤
     * │  #│    │#  │  #│
     * └───┘    │#  │  #│
     *          │#  │  #│
     *          └───┴───┘
     * when unfolded => left stripe, right stripe
     *
     * FULL
     * The part touches all four borders
     *          ┌───┬───┐
     *          │ # │ # │
     * ┌───┐    │###│###│
     * │ # │    │ # │ # │
     * │###│ -> ├───┼───┤
     * │ # │    │ # │ # │
     * └───┘    │###│###│
     *          │ # │ # │
     *          └───┴───┘
     * when unfolded => full
     */
    private Dictionary<PartType, int> _unfold(Dictionary<PartType, int> folded)
    {
        Dictionary<PartType, int> unfolded = new();
        foreach (var part in folded)
        {
            switch (part.Key)
            {
                case PartType.TopRightCorner:
                    _add(unfolded, PartType.MiddleLeftCorner, part.Value);
                    _add(unfolded, PartType.MiddleRightCorner, part.Value);
                    break;

                case PartType.TopCenterCorner:
                    _add(unfolded, PartType.MiddleCenterCorner, part.Value * 2);
                    break;

                case PartType.TopLeftCorner:
                    _add(unfolded, PartType.MiddleCenterCorner, part.Value);
                    break;

                case PartType.TopStripe:
                    _add(unfolded, PartType.MiddleStripe, part.Value);
                    break;

                case PartType.MiddleRightCorner:
                    _add(unfolded, PartType.MiddleLeftCorner, part.Value * 2);
                    _add(unfolded, PartType.MiddleRightCorner, part.Value * 2);
                    break;

                case PartType.MiddleCenterCorner:
                    _add(unfolded, PartType.MiddleCenterCorner, part.Value * 4);
                    break;

                case PartType.MiddleLeftCorner:
                    _add(unfolded, PartType.MiddleCenterCorner, part.Value * 2);
                    break;

                case PartType.MiddleStripe:
                    _add(unfolded, PartType.MiddleStripe, part.Value * 2);
                    break;

                case PartType.BottomRightCorner:
                    _add(unfolded, PartType.TopLeftCorner, part.Value);
                    _add(unfolded, PartType.TopRightCorner, part.Value);
                    _add(unfolded, PartType.BottomLeftCorner, part.Value);
                    _add(unfolded, PartType.BottomRightCorner, part.Value);
                    break;

                case PartType.BottomCenterCorner:
                    _add(unfolded, PartType.TopCenterCorner, part.Value * 2);
                    _add(unfolded, PartType.BottomCenterCorner, part.Value * 2);
                    break;

                case PartType.BottomLeftCorner:
                    _add(unfolded, PartType.TopCenterCorner, part.Value);
                    _add(unfolded, PartType.BottomCenterCorner, part.Value);
                    break;

                case PartType.BottomStripe:
                    _add(unfolded, PartType.TopStripe, part.Value);
                    _add(unfolded, PartType.BottomStripe, part.Value);
                    break;

                case PartType.LeftStripe:
                    _add(unfolded, PartType.CenterStripe, part.Value);
                    break;

                case PartType.CenterStripe:
                    _add(unfolded, PartType.CenterStripe, part.Value * 2);
                    break;

                case PartType.RightStripe:
                    _add(unfolded, PartType.LeftStripe, part.Value);
                    _add(unfolded, PartType.RightStripe, part.Value);
                    break;

                case PartType.TopRightL:
                case PartType.TopLeftL:
                case PartType.BottomRightL:
                case PartType.BottomLeftL:
                case PartType.Full:
                    _add(unfolded, PartType.Full, part.Value);
                    break;
            }
        }

        return unfolded;
    }

    private void _add(Dictionary<PartType, int> current, PartType partType, int nb)
    {
        if (current.ContainsKey(partType))
        {
            current[partType] += nb;
        }
        else
        {
            current.Add(partType, nb);
        }
    }

    private enum PartType
    {
        TopRightCorner,
        TopCenterCorner,
        TopLeftCorner,
        TopStripe,
        MiddleRightCorner,
        MiddleCenterCorner,
        MiddleLeftCorner,
        MiddleStripe,
        BottomRightCorner,
        BottomCenterCorner,
        BottomLeftCorner,
        BottomStripe,
        RightStripe,
        CenterStripe,
        LeftStripe,
        TopRightL,
        TopLeftL,
        BottomRightL,
        BottomLeftL,
        Full,
    }

}