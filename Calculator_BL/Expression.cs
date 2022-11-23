using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator_BL
{
    internal static class Expression
    {
        private static readonly Dictionary<string, int> priorityMap = new();
        private static readonly Dictionary<string, Func<double, double, double>> operationMap = new();
        static Expression()
        {
            priorityMap.Add("+", 1);
            priorityMap.Add("-", 1);
            priorityMap.Add("*", 2);
            priorityMap.Add("/", 2);

            operationMap.Add("+", (a, b) => a + b);
            operationMap.Add("-", (a, b) => a - b);
            operationMap.Add("*", (a, b) => a * b);
            operationMap.Add("/", (a, b) => a / b);
        }
        public static double Solve(string input)
        {
            var tokens = GetTokens(input);
            var result = 0;
            if (tokens.Count == 0)
                return 0;
            var nums = new Stack<double>();
            var operations = new Stack<string>();
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double num))
                    nums.Push(num);
                else if (priorityMap.ContainsKey(token))
                {
                    while (operations.TryPeek(out string symbol) &&
                        symbol != "(" && symbol != ")" &&
                        priorityMap[symbol] >= priorityMap[token])
                        solveCurrent(symbol);
                    operations.Push(token);
                }
                else if (token == ")")
                {
                    var correct = false;
                    while (operations.TryPeek(out string symbol))
                    {
                        if (symbol == "(")
                        {
                            operations.Pop();
                            correct = true;
                            break;
                        }
                        solveCurrent(symbol);
                    }
                    if (!correct) throwException();
                }
                else operations.Push(token);
            }
            while (operations.TryPeek(out string symbol)) solveCurrent(symbol);
            if (operations.Count != 0 || nums.Count != 1) throwException();
            return nums.Pop();
            void solveCurrent(string symbol)
            {
                if (nums.Count < 2) throwException();
                var first = nums.Pop();
                var second = nums.Pop();
                nums.Push(operationMap[symbol](second, first));
                operations.Pop();
            }
            void throwException()
            {
                throw new ArgumentException("Input string does not correct");
            }
        }
        private static List<string> GetTokens(string input)
        {
            var result = new List<string>();
            var currentNum = string.Empty;
            var lastToken = TokenType.Empty;
            var hasPoint = false;
            for (var i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    lastToken = TokenType.Number;
                    currentNum += input[i];
                }
                else if (input[i] == '.')
                {
                    if (!hasPoint)
                        currentNum += '.';
                    else throwException();
                    hasPoint = true;
                    if (lastToken != TokenType.Number)
                        currentNum = "0.";
                    else lastToken = TokenType.Number;
                }
                else checkForNumber();
                if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    if ((input[i] == '*' || input[i] == '/') && lastToken == TokenType.Empty) throwException();
                    if ((lastToken == TokenType.Operation || lastToken == TokenType.OpenedBracket) && input[i] != '-')
                        throwException();
                    checkForNegative(i);
                    result.Add(input[i].ToString());
                    lastToken = TokenType.Operation;
                }
                if (input[i] == '(')
                {
                    if (lastToken == TokenType.Number || lastToken == TokenType.ClosedBracket)
                        result.Add("*");
                    result.Add(input[i].ToString());
                    lastToken = TokenType.OpenedBracket;
                }
                else if (input[i] == ')')
                {
                    if (lastToken == TokenType.Operation || lastToken == TokenType.OpenedBracket)
                        throwException();
                    result.Add(input[i].ToString());
                    lastToken = TokenType.ClosedBracket;
                }
            }
            checkForNumber();
            return result;
            void checkForNegative(int index)
            {
                if (input[index] == '-')
                {
                    if((index > 0 && (input[index - 1] == '(') || index == 0))
                        result.Add("0");
                }
            }
            void checkForNumber()
            {
                if (lastToken == TokenType.Number)
                {
                    result.Add(currentNum);
                    currentNum = string.Empty;
                    hasPoint = false;
                }
            }
            void throwException()
            {
                throw new ArgumentException("Input string does not correct");
            }
        }
    }
}
