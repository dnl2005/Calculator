
using System.Data;

namespace ClassLibrary
{
    /// <summary>
    /// аналог функции eval для математических выражений
    /// </summary>
    /// <param name="expression">  выражение, с которым будет вестись работа</param>
    /// <returns> возвращает объект, содержащий int или double</returns>
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
