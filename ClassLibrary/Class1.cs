
using System.Data;

namespace ClassLibrary
{
    public static class Calculator
    {
        /// <summary>
        /// ������ ������� eval ��� �������������� ���������
        /// </summary>
        /// <param name="expression">  ���������, � ������� ����� ������� ������</param>
        /// <returns> ���������� ������, ���������� int ��� double</returns>

        static object Calculate(string expression)
        {
            //.complete ��� ��������� ���, ������ �����

            var result = new DataTable().Compute(expression, null);

            // ��� �������� ���������� � ���������� (?) ���������� �������� ����� convert.
            return result; 
        }
    }
}
