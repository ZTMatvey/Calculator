namespace Calculator_Tests
{
    public class Tests
    {
        private CalculatorContext GetFirstContext()
        {
            var calculator = new CalculatorContext();
            calculator.ApplySymbol(ChangeType.One);
            calculator.ApplySymbol(ChangeType.Seven);
            calculator.ApplySymbol(ChangeType.Plus);
            calculator.ApplySymbol(ChangeType.Two);
            calculator.ApplySymbol(ChangeType.Multiply);
            calculator.ApplySymbol(ChangeType.LeftBracket);
            calculator.ApplySymbol(ChangeType.Three);
            calculator.ApplySymbol(ChangeType.Zero);
            calculator.ApplySymbol(ChangeType.Minus);
            calculator.ApplySymbol(ChangeType.Four);
            calculator.ApplySymbol(ChangeType.LeftBracket);
            calculator.ApplySymbol(ChangeType.Five);
            calculator.ApplySymbol(ChangeType.Divide);
            calculator.ApplySymbol(ChangeType.Two);
            calculator.ApplySymbol(ChangeType.RightBracket);
            calculator.ApplySymbol(ChangeType.RightBracket);
            return calculator;
        }

        private CalculatorContext GetSecondContext()
        {
            var calculator = new CalculatorContext();
            calculator.ApplySymbol(ChangeType.Two);
            calculator.ApplySymbol(ChangeType.Plus);
            calculator.ApplySymbol(ChangeType.Two);
            return calculator;
        }

        private CalculatorContext GetThirdContext()
        {
            var calculator = new CalculatorContext();
            calculator.ApplySymbol(ChangeType.Five);
            calculator.ApplySymbol(ChangeType.Negative);
            calculator.ApplySymbol(ChangeType.Negative);
            return calculator;
        }

        [Test]
        public void ResultCorrect()
        {
            Assert.AreEqual(GetFirstContext().Result, "57");
        }

        [Test]
        public void ResultNotCorrect()
        {
            Assert.AreNotEqual(GetSecondContext().Result, "5");
        }

        [Test]
        public void ResultTwiceNegative()
        {
            Assert.AreEqual(GetThirdContext().Result, "5");
        }

        [Test]
        public void TextCorrect()
        {
            Assert.AreEqual(GetFirstContext().Text, "17+2*(30-4(5/2))");
        }
    }
}