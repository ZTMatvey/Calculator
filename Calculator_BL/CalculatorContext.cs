using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_BL
{
    public class CalculatorContext: IDisposable
    {
        private string _text = string.Empty;
        private string _result = string.Empty;
        public string Text => _text;
        public string Result => _result;
        private event Action<string> _textChanged;
        private event Action<string> _resultChanged;

        public CalculatorContext()
        {
            ChangeText(string.Empty);
            ChangeResult("0");
        }
        public void ApplySymbol(ChangeType changeType)
        {
            ChangeText(_text.ApplySymbol(changeType, _result));
            Solve();
        }
        private void Solve()
        {
            try
            {
                var result = Expression.Solve(_text);
                ChangeResult(result.ToString());
            }
            catch (Exception)
            {
                ChangeResult("Error");
            }
        }

        public void BindText(ITextField textField)
        {
            _textChanged += textField.Update;
            textField.Update(_text);
        }
        public void BindResult(ITextField textField)
        {
            _resultChanged += textField.Update;
            textField.Update(_result);
        }

        private void ChangeText(string text)
        {
            _text = text;
            _textChanged?.Invoke(_text);
        }

        private void ChangeResult(string result)
        {
            _result = result;
            _resultChanged?.Invoke(_result);
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~CalculatorContext()
        {
            _textChanged = null;
            _resultChanged = null;
        }
    }
}
