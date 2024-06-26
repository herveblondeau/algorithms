//https://www.codingame.com/training/hard/order-of-oopserations

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Codingame.OrderOfOopserations;

// This puzzle is very similar to Dice Probability Calculator and has a similar implementation
// Some nuances:
// - the tokenization doesn't deal with parentheses or less/greater than operators, but we have to deal with the unary operator (negation) instead
// - because of the unary operator, the operators operate on the stack directly, because they don't always use the same number of elements
public class OrderOfOopserations
{
    public int ComputeExpression(string expression)
    {

        var tokens = _tokenize(expression);

        // After tokenizing the expression, we apply the Shunting Yard algorithm (https://brilliant.org/wiki/shunting-yard-algorithm/)
        // which is exactly designed for the purpose of parsing a mathematical expression,
        // converting it into a Reverse Polish Notation then interpreting that expression
        return _applyRpnExpression(_computeRpnExpression(tokens)).Value;
    }

    private List<Token> _tokenize(string input)
    {
        List<Token> tokens = new();
        Regex regex = new(@"\d+|\+|\-|\*|\/");
        bool previousTokenIsNumber = false;
        foreach (var match in regex.Matches(input))
        {
            string matchStr = match.ToString()!;
            switch (matchStr)
            {
                case "+":
                    tokens.Add(new PlusOperator());
                    previousTokenIsNumber = false;
                    break;

                case "-":
                    tokens.Add(previousTokenIsNumber ? new MinusOperator() : new NegateOperator());
                    previousTokenIsNumber = false;
                    break;

                case "*":
                    tokens.Add(new MultiplyOperator());
                    previousTokenIsNumber = false;
                    break;

                case "/":
                    tokens.Add(new DivideOperator());
                    previousTokenIsNumber = false;
                    break;

                default:
                    tokens.Add(new Number(int.Parse(matchStr)));
                    previousTokenIsNumber = true;
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
                case TokenType.Number:
                    output.Enqueue(token);
                    break;

                case TokenType.Operator:
                    // The next comparison uses ">=". Using ">" only leads to incorrect operation order for sequences of identical operators
                    // For instance, with a strict comparison, "18/6/3" has the "6/3" part computed first, leading to an incorrect result
                    // ">=" ensures that "18/6" is computed first
                    while (operators.TryPeek(out t) && t.Type == TokenType.Operator && ((Operator)t).Precedence >= ((Operator)token).Precedence)
                    {
                        output.Enqueue(operators.Pop());
                    }
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

    private Number _applyRpnExpression(Queue<Token> tokens)
    {
        Stack<Token> stack = new();
        Token? token;
        while(tokens.TryDequeue(out token))
        {
            if (token.Type == TokenType.Number)
            {
                stack.Push(token);
            }
            else if (token.Type == TokenType.Operator)
            {
                var result = ((Operator)token).Apply(stack);
                stack.Push(result);
            }
            // No 'else' as we know we are not expecting any other token type in this particular problem
        }

        return (Number)stack.Pop();
    }

    private abstract class Token
    {
        public abstract TokenType Type { get; }
    }

    private enum TokenType
    {
        Number,
        Operator,
    }

    private class Number : Token
    {
        public override TokenType Type => TokenType.Number;

        public int Value { get; set; }

        public Number(int value)
        {
            Value = value;
        }
    }

    #region Operators

    private abstract class Operator : Token
    {
        public abstract Number Apply(Stack<Token> stack);

        public override TokenType Type => TokenType.Operator;

        public abstract int Precedence { get; }
    }

    private class NegateOperator : Operator
    {
        public override int Precedence => 5;
        public override Number Apply(Stack<Token> stack)
        {
            var a = (Number)stack.Pop();
            return new Number(-a.Value);
        }
    }

    private class PlusOperator : Operator
    {
        public override int Precedence => 4;
        public override Number Apply(Stack<Token> stack)
        {
            var a = (Number)stack.Pop();
            var b = (Number)stack.Pop();
            return new Number(a.Value + b.Value);
        }
    }

    private class MinusOperator : Operator
    {
        public override int Precedence => 2;
        public override Number Apply(Stack<Token> stack)
        {
            var a = (Number)stack.Pop();
            var b = (Number)stack.Pop();
            return new Number(b.Value - a.Value);
        }
    }

    private class MultiplyOperator : Operator
    {
        public override int Precedence => 1;
        public override Number Apply(Stack<Token> stack)
        {
            var a = (Number)stack.Pop();
            var b = (Number)stack.Pop();
            return new Number(a.Value * b.Value);
        }
    }

    private class DivideOperator : Operator
    {
        public override int Precedence => 3;
        public override Number Apply(Stack<Token> stack)
        {
            var a = (Number)stack.Pop();
            var b = (Number)stack.Pop();
            return new Number((int)b.Value / a.Value);
        }
    }

    #endregion

}
