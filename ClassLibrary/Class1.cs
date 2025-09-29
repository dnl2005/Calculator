
using System.Data;

namespace ClassLibrary
{
    public static class Calculator
    {
        /// <summary>
        /// аналог функции eval для математических выражений
        /// </summary>
        /// <param name="expression">  выражение, с которым будет вестись работа</param>
        /// <returns> возвращает объект, содержащий int или double</returns>

        static object Calculate(string expression)
        {
            //.complete сам вычисляет все, крутой мужик

            var result = new DataTable().Compute(expression, null);

            // при принятии результата в переменную (?) необходимо работать через convert.
            return result; 
        }
    }
}
