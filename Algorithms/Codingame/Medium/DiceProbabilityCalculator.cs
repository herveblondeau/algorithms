// https://www.codingame.com/training/medium/dice-probability-calculator

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codingame.DiceProbabilityCalculator;

public class DiceProbabilityCalculator
{
    public Dictionary<int, double> ComputeProbabilities(string input)
    {

        var tokens = _tokenize(input);

        // After tokenizing the expression, we apply the Shunting Yard algorithm (https://brilliant.org/wiki/shunting-yard-algorithm/)
        // which is exactly designed for the purpose of parsing a mathematical expression,
        // converting it into a Reverse Polish Notation then interpreting that expression
        var result = _applyRpnExpression(_computeRpnExpression(tokens));

        return result.GetProbabilities();
    }

    private List<Token> _tokenize(string input)
    {
        List<Token> tokens = new();
        Regex regex = new(@"\d+|d\d+|\+|\-|\*|\<|\>|\(|\)");
        foreach (var match in regex.Matches(input))
        {
            string matchStr = match.ToString()!;
            switch (matchStr)
            {
                case "+":
                    tokens.Add(new PlusOperator());
                    break;

                case "-":
                    tokens.Add(new MinusOperator());
                    break;

                case "*":
                    tokens.Add(new MultiplyOperator());
                    break;

                case ">":
                    tokens.Add(new GreaterThanOperator());
                    break;

                case "<":
                    tokens.Add(new LessThanOperator());
                    break;

                case "(":
                    tokens.Add(new LeftParenthesis());
                    break;

                case ")":
                    tokens.Add(new RightParenthesis());
                    break;

                default:
                    if (matchStr.StartsWith("d"))
                    {
                        tokens.Add(Die.CreateNSided(int.Parse(matchStr.Substring(1))));
                    }
                    else
                    {
                        tokens.Add(Die.CreateSingleSide(int.Parse(matchStr)));
                    }
                    break;
            }
        }

        return tokens;
    }

    private Queue<Token> _computeRpnExpression(List<Token> tokens)
    {
        Queue<Token> output = new();
        Stack<Token> operators = new();

        Token? t;
        foreach (var token in tokens)
        {
            switch (token.Type)
            {
                case TokenType.Die:
                    output.Enqueue(token);
                    break;

                case TokenType.Operator:
                    while (operators.TryPeek(out t) && ((t.Type == TokenType.Operator && ((Operator)t).Precedence >= ((Operator)token).Precedence) || t.Type == TokenType.RightParenthesis))
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Push(token);
                    break;

                case TokenType.LeftParenthesis:
                    operators.Push(token);
                    break;

                case TokenType.RightParenthesis:
                    while (operators.TryPeek(out t) && t.Type != TokenType.LeftParenthesis)
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Pop(); // discard the left parenthesis
                    operators.Push(token);
                    break;

                default:
                    break;
            }
        }
        foreach (var o in operators)
        {
            output.Enqueue(o);
        }

        return output;
    }

    private Die _applyRpnExpression(Queue<Token> tokens)
    {
        Stack<Token> stack = new();
        Token? token;
        while(tokens.TryDequeue(out token))
        {
            if (token.Type == TokenType.Die)
            {
                stack.Push(token);
            }
            else if (token.Type == TokenType.Operator)
            {
                var die2 = (Die)stack.Pop();
                var die1 = (Die)stack.Pop();
                var result = ((Operator)token).Apply(die1, die2);
                stack.Push(result);
            }
            // No 'else' as we know we are not expecting any other token type in this particular problem
        }

        return (Die)stack.Pop();
    }

    private abstract class Token
    {
        public abstract TokenType Type { get; }
    }

    private enum TokenType
    {
        Die,
        LeftParenthesis,
        RightParenthesis,
        Operator,
    }

    #region Die

    private class Die : Token
    {
        public override TokenType Type => TokenType.Die;

        // A die is defined here more generically than the actual object. We define it by its distribution, i.e. the number of possible occurrences of each number
        // This means that any combination of dice is also a die, since it has a distribution.
        // The puzzle therefore consists in computing the resulting die from a whole expression.
        public Dictionary<int, int> Distribution { get; set; } = null!;

        private Die(Dictionary<int, int> distribution)
        {
            Distribution = distribution;
        }

        public static Die CreateCustom(Dictionary<int, int> distribution)
        {
            return new Die(distribution);
        }

        public static Die CreateNSided(int nbSides)
        {
            Dictionary<int, int> distribution = new();
            for (int i = 0; i < nbSides; i++)
            {
                distribution[i + 1] = 1;
            }

            return new Die(distribution);
        }

        public static Die CreateSingleSide(int value)
        {
            Dictionary<int, int> distribution = new()
            {
                { value, 1 },
            };

            return new Die(distribution);
        }

        public Dictionary<int, double> GetProbabilities()
        {
            Dictionary<int, double> probabilities = new();
            int nbTotal = Distribution.Values.Sum();

            foreach (var kvp in Distribution)
            {
                probabilities[kvp.Key] = (double)kvp.Value / nbTotal;
            }
            return probabilities;
        }
    }

    #endregion

    #region Operators

    private abstract class Operator : Token
    {
        // Calculates the die resulting from applying the operator to combine two dice
        public Die Apply(Die die1, Die die2)
        {
            Dictionary<int, int> combinedDistribution = new();

            foreach (var die1Value in die1.Distribution.Keys)
            {
                foreach (var die2Value in die2.Distribution.Keys)
                {
                    var combinedDieValue = CombineValues(die1Value, die2Value);
                    if (!combinedDistribution.ContainsKey(combinedDieValue))
                    {
                        combinedDistribution[combinedDieValue] = 0;
                    }

                    combinedDistribution[combinedDieValue] += die1.Distribution[die1Value] * die2.Distribution[die2Value];
                }
            }

            return Die.CreateCustom(combinedDistribution);
        }

        public override TokenType Type => TokenType.Operator;

        public abstract int Precedence { get; }

        public abstract int CombineValues(int a, int b);
    }

    private class PlusOperator : Operator
    {
        public override int Precedence => 2;
        public override int CombineValues(int a, int b)
        {
            return a + b;
        }
    }

    private class MinusOperator : Operator
    {
        public override int Precedence => 2;
        public override int CombineValues(int a, int b)
        {
            return a - b;
        }
    }

    private class MultiplyOperator : Operator
    {
        public override int Precedence => 3;
        public override int CombineValues(int a, int b)
        {
            return a * b;
        }
    }

    private class GreaterThanOperator : Operator
    {
        public override int Precedence => 1;
        public override int CombineValues(int a, int b)
        {
            return a > b ? 1 : 0;
        }
    }

    private class LessThanOperator : Operator
    {
        public override int Precedence => 1;
        public override int CombineValues(int a, int b)
        {
            return a < b ? 1 : 0;
        }
    }

    #endregion

    private class LeftParenthesis : Token
    {
        public override TokenType Type => TokenType.LeftParenthesis;
    }

    private class RightParenthesis : Token
    {
        public override TokenType Type => TokenType.RightParenthesis;
    }
}

