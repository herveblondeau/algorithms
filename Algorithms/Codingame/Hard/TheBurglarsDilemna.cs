// https://www.codingame.com/training/hard/the-burglars-dilemna
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.TheBurglarsDilemna
{
    // TODO: better/more generic adjacency handling for edge cases (0 and 9)
    // TODO: simplify strategies (use Command pattern instead or basic mappings)
    public class TheBurglarsDilemna
    {
        public string Solve(int length, List<Guess> guesses)
        {
            // Prepare strategies
            List<IStrategy> strategies = new();
            strategies.Add(new ClickClackCluckStrategy());
            strategies.Add(new ClickCluckClackStrategy());
            strategies.Add(new ClackClickCluckStrategy());
            strategies.Add(new ClackCluckClickStrategy());
            strategies.Add(new CluckClackClickStrategy());
            strategies.Add(new CluckClickClackStrategy());

            string result = null; // stores the only allowed combination across all strategies
            string current; // stores the current combination

            // For each strategy,
            foreach (var strategy in strategies)
            {
                // Prepare workspace
                Workspace workspace = new(length);

                // Process all guesses
                foreach (var guess in guesses)
                {
                    workspace.ProcessGuess(guess, strategy);
                }

                // Get the combination
                current = workspace.GetCombination();
                if (current != null && current != result)
                {
                    // There can only be one combination across all strategies
                    if (result != null)
                    {
                        return null;
                    }
                    else
                    {
                        result = current;
                    }
                }
            }

            return result;
        }

        private class Workspace
        {
            public int Length => _possibilities.Length;
            private HashSet<int>[] _possibilities;

            public Workspace(int length)
            {
                _possibilities = new HashSet<int>[length];
                for (int p = 0; p < _possibilities.Length; p++)
                {
                    _possibilities[p] = new HashSet<int>();
                    for (int d = 0; d <= 9; d++)
                    {
                        _possibilities[p].Add(d);
                    }
                }
            }

            public void ProcessGuess(Guess guess, IStrategy strategy)
            {
                strategy.ProcessGuess(guess, this);
            }

            public void SetHit(int digit, int position)
            {
                // Remove all digits except the one selected
                for (int d = 0; d <= 9; d++)
                {
                    if (d != digit) _possibilities[position].Remove(d);
                }
            }

            public void SetClose(int digit, int position)
            {
                // Remove all digits except the direct neighbors
                if (digit == 0)
                {
                    for (int d = 0; d <= 9; d++)
                    {
                        if (d != 1 && d != 9) _possibilities[position].Remove(d);
                    }
                }
                else if (digit == 9)
                {
                    for (int d = 0; d <= 9; d++)
                    {
                        if (d != 0 && d != 8) _possibilities[position].Remove(d);
                    }
                }
                else
                {
                    for (int d = 0; d <= 9; d++)
                    {
                        if (Math.Abs(d - digit) != 1) _possibilities[position].Remove(d);
                    }
                }
            }

            public void SetMiss(int digit, int position)
            {
                if (digit == 0) _possibilities[position].Remove(9);
                _possibilities[position].Remove(digit - 1);
                _possibilities[position].Remove(digit);
                _possibilities[position].Remove(digit + 1);
                if (digit == 9) _possibilities[position].Remove(0);
            }

            public string GetCombination()
            {
                int[] combination = new int[Length];
                for (int i = 0; i < Length; i++)
                {
                    if (!IsSolved(i))
                    {
                        return null;
                    }
                    combination[i] = _possibilities[i].Single();
                }

                return string.Join(' ', combination);
            }

            public bool IsSolved(int position)
            {
                return _possibilities[position].Count() == 1;
            }
        }

        private interface IStrategy
        {
            void ProcessGuess(Guess guess, Workspace workspace);
        }

        private class ClickClackCluckStrategy : IStrategy
        {
            public void ProcessGuess(Guess guess, Workspace workspace)
            {
                switch (guess.Sound)
                {
                    case Sound.CLICK:
                        workspace.SetHit(guess.Digit, guess.Position);
                        break;

                    case Sound.CLACK:
                        workspace.SetClose(guess.Digit, guess.Position);
                        break;

                    case Sound.CLUCK:
                        workspace.SetMiss(guess.Digit, guess.Position);
                        break;
                }
            }
        }

        private class ClickCluckClackStrategy : IStrategy
        {
            public void ProcessGuess(Guess guess, Workspace workspace)
            {
                switch (guess.Sound)
                {
                    case Sound.CLICK:
                        workspace.SetHit(guess.Digit, guess.Position);
                        break;

                    case Sound.CLUCK:
                        workspace.SetClose(guess.Digit, guess.Position);
                        break;

                    case Sound.CLACK:
                        workspace.SetMiss(guess.Digit, guess.Position);
                        break;
                }
            }
        }

        private class ClackClickCluckStrategy : IStrategy
        {
            public void ProcessGuess(Guess guess, Workspace workspace)
            {
                switch (guess.Sound)
                {
                    case Sound.CLACK:
                        workspace.SetHit(guess.Digit, guess.Position);
                        break;

                    case Sound.CLICK:
                        workspace.SetClose(guess.Digit, guess.Position);
                        break;

                    case Sound.CLUCK:
                        workspace.SetMiss(guess.Digit, guess.Position);
                        break;
                }
            }
        }

        private class ClackCluckClickStrategy : IStrategy
        {
            public void ProcessGuess(Guess guess, Workspace workspace)
            {
                switch (guess.Sound)
                {
                    case Sound.CLACK:
                        workspace.SetHit(guess.Digit, guess.Position);
                        break;

                    case Sound.CLUCK:
                        workspace.SetClose(guess.Digit, guess.Position);
                        break;

                    case Sound.CLICK:
                        workspace.SetMiss(guess.Digit, guess.Position);
                        break;
                }
            }
        }

        private class CluckClackClickStrategy : IStrategy
        {
            public void ProcessGuess(Guess guess, Workspace workspace)
            {
                switch (guess.Sound)
                {
                    case Sound.CLUCK:
                        workspace.SetHit(guess.Digit, guess.Position);
                        break;

                    case Sound.CLACK:
                        workspace.SetClose(guess.Digit, guess.Position);
                        break;

                    case Sound.CLICK:
                        workspace.SetMiss(guess.Digit, guess.Position);
                        break;
                }
            }
        }

        private class CluckClickClackStrategy : IStrategy
        {
            public void ProcessGuess(Guess guess, Workspace workspace)
            {
                switch (guess.Sound)
                {
                    case Sound.CLUCK:
                        workspace.SetHit(guess.Digit, guess.Position);
                        break;

                    case Sound.CLICK:
                        workspace.SetClose(guess.Digit, guess.Position);
                        break;

                    case Sound.CLACK:
                        workspace.SetMiss(guess.Digit, guess.Position);
                        break;
                }
            }
        }
    }

    public class Guess
    {
        public int Digit { get; set; }
        public int Position { get; set; }
        public Sound Sound { get; set; }

        public Guess(int digit, int position, Sound sound)
        {
            Digit = digit;
            Position = position;
            Sound = sound;
        }

        public override int GetHashCode()
        {
            return Position * 10 + Digit; // we don't need to take the sound into account as it is consistent for give position and digit
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == ((Guess)obj).GetHashCode();
        }
    }

    public enum Sound
    {
        CLICK,
        CLACK,
        CLUCK,
    }
}
