using System.Data;

namespace ClassLibrary
{
    /// <summary>
    /// аналог функции eval для математических выражений
    /// </summary>
    /// <param name="expression">выражение, с которым будет вестись работа</param>
    /// <returns>возвращает double или строку ошибки</returns>
    public static class Calculator
    {
        public static Dictionary<string, double> history = new();

        public static object Calculate(string expression, object defaultValue = null)
        {
            try
            {
                var result = new DataTable().Compute(expression, null);

                // ✅ Приводим всё к double (чтобы не было Int64 Overflow)
                double value = Convert.ToDouble(result);

                // проверка деления на 0
                if (double.IsInfinity(value) || double.IsNaN(value))
                    return defaultValue ?? "Ошибка: деление на 0";

                return value;
            }
            catch (OverflowException)
            {
                return "Ошибка: слишком большое число"; // ✅ обработка переполнения
            }
            catch
            {
                return defaultValue ?? "Ошибка вычисления";
            }
        }
    }
}
