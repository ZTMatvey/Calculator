using Calculator_BL;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private readonly CalculatorContext _calculatorContext;
        public Calculator()
        {
            InitializeComponent();
            _calculatorContext = new();
            _calculatorContext.BindText(new TextBoxField(TextTextBox));
            _calculatorContext.BindResult(new TextBoxField(ResultTextBox));
        }

        private void LeftBracketBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.LeftBracket);

        private void RightBracketBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.RightBracket);

        private void ClearBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Clear);

        private void DeleteBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Delete);

        private void SevenBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Seven);

        private void EightBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Eight);

        private void NineBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Nine);

        private void DivideBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Divide);

        private void FourBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Four);

        private void FiveBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Five);

        private void SixBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Six);

        private void MultiplyBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Multiply);

        private void OneBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.One);

        private void TwoBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Two);

        private void ThreeBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Three);

        private void PlusBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Plus);

        private void NegativeBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Negative);

        private void ZeroBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Zero);

        private void PointBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Point);

        private void MinusBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Minus);

        private void EqualBtn_Click(object sender, EventArgs e) => _calculatorContext.ApplySymbol(ChangeType.Equal);
    }
}