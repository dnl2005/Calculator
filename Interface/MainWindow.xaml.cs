using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ClassLibrary;

namespace Interface
{
    public partial class MainWindow : Window
    {
        private StringBuilder currentInput = new StringBuilder();
        private const int MaxDigits = 12; // ограничение на разрядность числа

        public MainWindow()
        {
            InitializeComponent();
        }

        // Проверка, последний ли символ — оператор
        private bool IsLastCharOperator()
        {
            if (currentInput.Length == 0) return false;
            char last = currentInput[currentInput.Length - 1];
            return "+-*/".Contains(last);
        }

        // Проверка, последний ли символ — запятая
        private bool IsLastCharComma()
        {
            if (currentInput.Length == 0) return false;
            return currentInput[currentInput.Length - 1] == ',';
        }

        // Проверка, есть ли запятая в текущем числе
        private bool HasCommaInCurrentNumber()
        {
            int i = currentInput.Length - 1;
            while (i >= 0 && char.IsDigit(currentInput[i]))
                i--;
            return (i >= 0 && currentInput[i] == ',');
        }

        // Подсчет длины последнего числа
        private int GetLastNumberLength()
        {
            int length = 0;
            for (int i = currentInput.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(currentInput[i]))
                    length++;
                else
                    break;
            }
            return length;
        }

        // Цифровые кнопки
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            // проверка ограничения на разрядность
            if (GetLastNumberLength() >= MaxDigits)
                return;

            currentInput.Append(button.Content.ToString());
            DisplayTextBox.Text = currentInput.ToString();
        }

        // Операторы
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (currentInput.Length == 0) return;

            if (IsLastCharOperator())
            {
                // заменяем оператор вместо добавления
                currentInput[currentInput.Length - 1] = button.Content.ToString()[0];
            }
            else
            {
                currentInput.Append(button.Content.ToString());
            }

            DisplayTextBox.Text = currentInput.ToString();
        }

        // Запятая
        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput.Length == 0) return;

            if (IsLastCharOperator()) return; // не ставим после оператора
            if (IsLastCharComma()) return;    // не дублируем
            if (HasCommaInCurrentNumber()) return; // только одна в числе

            currentInput.Append(",");
            DisplayTextBox.Text = currentInput.ToString();
        }

        // Backspace стереть последний символ
        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput.Remove(currentInput.Length - 1, 1);
                DisplayTextBox.Text = currentInput.Length > 0 ? currentInput.ToString() : "0";
            }
        }

        // AC полная очистка
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            currentInput.Clear();
            DisplayTextBox.Text = "0";
            OperationTextBox.Text = "";
        }

        // 00
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GetLastNumberLength() + 2 <= MaxDigits) // проверка лимита
            {
                currentInput.Append("00");
                DisplayTextBox.Text = currentInput.ToString();
            }
        }

        // Равно 
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            var result = Calculator.Calculate(currentInput.ToString().Replace(",", "."));

            OperationTextBox.Text = result.ToString();

            string expression = currentInput.ToString();

            // Добавляем запись
            HistoryTextBox.AppendText($"{expression} = {result}\n\n");
            HistoryTextBox.ScrollToEnd();
        }

        private void ClearHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryTextBox.Clear();
        }

        private void DisplayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //скобки
        private void Parenthesis_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (button.Name == "OpeningParenthesis")
            {
                // Автоматически добавляем оператор умножения, если перед скобкой цифра
                if (currentInput.Length > 0 &&
                   (char.IsDigit(currentInput[^1]) || currentInput[^1] == ')'))
                {
                    currentInput.Append("×");
                }
                currentInput.Append("(");
            }
            else if (button.Name == "ClosingParenthesis")
            {
                // Проверяем баланс скобок и что последний символ подходящий
                int openCount = currentInput.ToString().Count(c => c == '(');
                int closeCount = currentInput.ToString().Count(c => c == ')');

                if (openCount > closeCount && currentInput.Length > 0 &&
                   !IsOperator(currentInput[^1]) && currentInput[^1] != '(')
                {
                    currentInput.Append(")");
                }
            }

            DisplayTextBox.Text = currentInput.ToString();
        }

        private bool IsOperator(char c) => c == '+' || c == '-' || c == '×' || c == '÷';
    }
}
