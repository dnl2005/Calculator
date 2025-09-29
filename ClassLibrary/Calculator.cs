
using System.Data;

namespace ClassLibrary
{
    public static class Calculator
    {
        public static Dictionary<string, double> history = [];


        public static object Calculate(string expression, object defaultValue = null)
        {


            var result = new DataTable().Compute(expression, null);

            // проверка деления на 0
            if (result is double doubleResult && double.IsInfinity(doubleResult))
                return defaultValue ?? "Ошибка: деление на 0";

            return result;
        }
    }
}
