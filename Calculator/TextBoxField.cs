using Calculator_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class TextBoxField : ITextField
    {
        private readonly TextBox _field;

        public TextBoxField(TextBox field)
        {
            _field = field;
        }

        public void Update(string newText)
        {
            _field.Text = newText;
        }
    }
}
