using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_BL
{
    internal static class OperationExtensions
    {
        public static string ApplySymbol(this string input, ChangeType changeType, string result)
        {
            return changeType switch
            {
                ChangeType.Zero => input + '0',
                ChangeType.One => input + '1',
                ChangeType.Two => input + '2',
                ChangeType.Three => input + '3',
                ChangeType.Four => input + '4',
                ChangeType.Five => input + '5',
                ChangeType.Six => input + '6',
                ChangeType.Seven => input + '7',
                ChangeType.Eight => input + '8',
                ChangeType.Nine => input + '9',
                ChangeType.Minus => input + '-',
                ChangeType.Plus => input + '+',
                ChangeType.Multiply => input + '*',
                ChangeType.Divide => input + '/',
                ChangeType.Equal => equal(),
                ChangeType.Delete => delete(),
                ChangeType.Clear => string.Empty,
                ChangeType.Point => input + '.',
                ChangeType.Negative => $"-({input})",
                ChangeType.LeftBracket => input + '(',
                ChangeType.RightBracket => input + ')'
            };
            string equal()
            {
                if (double.TryParse(result, out double num))
                    return num.ToString();
                else return string.Empty;
            }
            string delete()
            {
                if (input.Length <= 0)
                    return string.Empty;
                return input.Substring(0,input.Length - 1);
            }
        }
    }
}
