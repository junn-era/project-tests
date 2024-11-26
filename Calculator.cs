using System.Collections.Generic;

namespace CalculatorApp
{
    public class Calculator
    {
        private readonly List<string> _history = new List<string>();

        public double Add(double a, double b)
        {
            double result = a + b;
            AddToHistory($"Add: {a} + {b} = {result}");
            return result;
        }

        public double Subtract(double a, double b)
        {
            double result = a - b;
            AddToHistory($"Subtract: {a} - {b} = {result}");
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            AddToHistory($"Multiply: {a} * {b} = {result}");
            return result;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            
            double result = a / b;
            AddToHistory($"Divide: {a} / {b} = {result}");
            return result;
        }

        public List<string> GetHistory()
        {
            // Retorna apenas os últimos três cálculos
            return new List<string>(_history.TakeLast(3));
        }

        private void AddToHistory(string operation)
        {
            if (_history.Count == 3)
                _history.RemoveAt(0); // Remove o mais antigo
            
            _history.Add(operation);
        }
    }
}
