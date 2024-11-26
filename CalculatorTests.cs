using Xunit;
using CalculatorApp;
using System;

namespace CalculatorApp.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            double result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            double result = _calculator.Subtract(10, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            double result = _calculator.Multiply(7, 3);
            Assert.Equal(21, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectQuotient()
        {
            double result = _calculator.Divide(8, 2);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
        }

        [Fact]
        public void GetHistory_ReturnsLastThreeOperations()
        {
            _calculator.Add(1, 1); // 1
            _calculator.Subtract(5, 2); // 2
            _calculator.Multiply(2, 3); // 3
            _calculator.Divide(9, 3); // 4
            
            var history = _calculator.GetHistory();
            
            Assert.Equal(3, history.Count);
            Assert.Contains("Subtract: 5 - 2 = 3", history);
            Assert.Contains("Multiply: 2 * 3 = 6", history);
            Assert.Contains("Divide: 9 / 3 = 3", history);
        }
    }
}
