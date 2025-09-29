using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface
{
    public partial class MainWindow : Window
    {
        private StringBuilder currentInput = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Цифровые кнопки
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentInput.Append(button.Content.ToString());
            DisplayTextBox.Text = currentInput.ToString();
        }

        // Операторы
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentInput.Append($" {button.Content} ");
            DisplayTextBox.Text = currentInput.ToString();
        }

        // Запятая
        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput.Append(",");
            DisplayTextBox.Text = currentInput.ToString();
        }

        // Backspace стереть поледнее чило или знак
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

        // C очистка
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            currentInput.Clear();
            DisplayTextBox.Text = "0";
        }

        // Процент
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput.Append("%");
            DisplayTextBox.Text = currentInput.ToString();
        }

        // Равно 
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            OperationTextBox.Text = currentInput.ToString() + " =";
        }

        // История 
        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            // сюда новую xaml бахните подключение к истории пж типо как создадите;
        }

        private void DisplayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}